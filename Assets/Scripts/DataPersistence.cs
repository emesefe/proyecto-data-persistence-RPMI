using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    // Instancia compartida
    public static DataPersistence sharedInstance;
    
    // Variables cuyo valor queremos conservar entre escenas:
    public int colorSelected;
    public Color color;
    public int level;
    public string username;
    

    // Nos aseguramos de que la instancia sea única
    private void Awake()
    {
        // Si la instancia no existe
        if (sharedInstance == null)
        {
            // Configuramos la instancia
            sharedInstance = this;
            // Nos aseguramos de que no sea destruida con el cambio de escena
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            // Como ya existe una instancia, destruimos la copia
            Destroy(this);
        }
    }

    public void SaveForFutureGames()
    {
        // Color
        PlayerPrefs.SetInt("COLOR_SELECTED", colorSelected);
        PlayerPrefs.SetFloat("R", color[0]);
        PlayerPrefs.SetFloat("G", color[1]);
        PlayerPrefs.SetFloat("B", color[2]);
        
        // Nivel
        PlayerPrefs.SetInt("LEVEL", level);
        
        // Nombre de usuario
        PlayerPrefs.SetString("USERNAME", username);
    }
}
