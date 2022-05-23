using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject[] colors;
    public TextMeshProUGUI levelText;
    public TMP_InputField username;

    private int _level;
    private int minLevel = 1;
    private int maxLevel = 10;

    private int _colorSelected;

    private void Start()
    {
        _level = int.Parse(levelText.text);
        LoadUserOptions();
    }

    private void Update()
    {
        ColorSelection();
    }

    public void SaveUserOptions()
    {
        #region PERSISTENCIA DE DATOS ENTRE ESCENAS
        
        DataPersistence.sharedInstance.colorSelected = _colorSelected;
        DataPersistence.sharedInstance.color = colors[_colorSelected].GetComponent<Image>().color;
        
        DataPersistence.sharedInstance.level = _level;
        
        DataPersistence.sharedInstance.username = username.text;
        #endregion
        
        #region PERSISTENCIA DE DATOS ENTRE PARTIDAS
        
        // DataPersistence.sharedInstance.SaveForFutureGames();
        
        Color color = colors[_colorSelected].GetComponent<Image>().color;
        PlayerPrefs.SetInt("COLOR_SELECTED", _colorSelected);
        PlayerPrefs.SetFloat("R", color[0]);
        PlayerPrefs.SetFloat("G", color[1]);
        PlayerPrefs.SetFloat("B", color[2]);
        
        // Nivel
        PlayerPrefs.SetInt("LEVEL", _level);
        
        // Nombre de usuario
        PlayerPrefs.SetString("USERNAME", username.text);
        #endregion
    }

    public void LoadUserOptions()
    {
        // Tal y como lo hemos configurado, si tiene esta clave, entonces tiene todas
        if (PlayerPrefs.HasKey("COLOR_SELECTED"))
        {
            _colorSelected = PlayerPrefs.GetInt("COLOR_SELECTED");
            
            _level = PlayerPrefs.GetInt("LEVEL");
            UpdateLevel();

            username.text = PlayerPrefs.GetString("USERNAME");
        }
    }

    #region Level Settings

    public void PlusLevel()
    {
        _level++;
        _level = Mathf.Clamp(_level, minLevel, maxLevel);
        UpdateLevel();
    }

    public void MinusLevel()
    {
        _level--;
        _level = Mathf.Clamp(_level, minLevel, maxLevel);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        levelText.text = _level.ToString();
    }
    #endregion

    #region Color Settings

    private void ColorSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _colorSelected++;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _colorSelected--;
        }

        _colorSelected %= 3;
        ChangeColorSelection();
    }

    private void ChangeColorSelection()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].transform.GetChild(0).gameObject.SetActive(i == _colorSelected);
        }
    }

    #endregion
}
