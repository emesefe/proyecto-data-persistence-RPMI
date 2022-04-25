using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceX : MonoBehaviour
{
    // Instancia compartida
    public static DataPersistenceX sharedInstance;
    
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
        PlayerPrefs.SetInt("COLOR_SELECTED_X", colorSelected);
        PlayerPrefs.SetFloat("R_X", color[0]);
        PlayerPrefs.SetFloat("G_X", color[1]);
        PlayerPrefs.SetFloat("B_X", color[2]);
        
        // Nivel
        PlayerPrefs.SetInt("LEVEL_X", level);
        
        // Nombre de usuario
        PlayerPrefs.SetString("USERNAME_X", username);
    }
}
