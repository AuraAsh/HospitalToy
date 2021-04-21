using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public List<ChangerPlayer> changer;

    private void Awake()
    {
        Load();
    }
    public void Save()
    {
        Debug.Log("SAVING");
        //Se crea un archivo para guardar
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.OpenOrCreate);
        //Binary Formmater. Nos permite escribir datos en un archivo
        BinaryFormatter formatter = new BinaryFormatter();
        
        foreach (var item in changer)
        {
            formatter.Serialize(file, item.parameter); //Guarda toda la clase
        }

        file.Close(); //Evita errores o fugas de memoria
        
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/Player.dat";

        if (File.Exists(path))
        {
            Debug.Log("LOADING");
            FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            
            foreach (var item in changer)
            {
                item.parameter = formatter.Deserialize(file) as Parameter;
                item.LoadCurrentSprite();
            }

            file.Close(); 
        }
    }
}
