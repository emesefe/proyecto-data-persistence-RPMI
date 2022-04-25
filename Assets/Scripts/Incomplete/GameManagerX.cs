using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    public static GameManagerX sharedInstance;
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
        player.material.color = DataPersistenceX.sharedInstance.color;
        level.text = DataPersistenceX.sharedInstance.level.ToString();
        username.text = DataPersistenceX.sharedInstance.username;
    }
}
