using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public MeshRenderer player;
    public TextMeshProUGUI level;
    public TextMeshProUGUI username;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    void Start()
    {
        // Aplicamos los cambios guardados en la escena Menu
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {
        player.material.color = DataPersistence.sharedInstance.color;
        level.text = DataPersistence.sharedInstance.level.ToString();
        username.text = DataPersistence.sharedInstance.username;
    }
}
