using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public Changer changer;
    private void Awake()
    {
        Load();
       //changer = FindObjectOfType<Changer>();
    }
    public void Save()
    {
        Debug.Log("SAVING");
        //Se crea un archivo para guardar
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.OpenOrCreate);
        //Binary Formmater. Nos permite escribir datos en un archivo
        BinaryFormatter formatter = new BinaryFormatter();
        //Serializamos
        formatter.Serialize(file, changer.parameter);

        file.Close(); //Evita errores o fugas de memoria
        
    }

    public void Load()
    {
        Debug.Log("LOADING");
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        changer.parameter = formatter.Deserialize(file) as Parameter;
        file.Close();
    }
}
