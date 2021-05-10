using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public List<ChangerPlayer> changer;
    //public GameObject canvas;

    private void Awake()
    {
        Load();
        //canvas.SetActive(true);
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

        //GetScreenshot();

        file.Close(); //Evita errores o fugas de memoria
        
    }

    /*private void GetScreenshot()
    {
        //Desactivar el canvas
        canvas.SetActive(false);
        //Tomar Screenshot
        Screenshot();
        //DelayCanvas
        StartCoroutine(DelayCanvas());
        //Guardar el screenshot
        SaveScreenshot();
    }

    private void Screenshot()
    {
        StartCoroutine(CaptureIt());
    }

    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("SCREENSHOT");
    }

    private void SaveScreenshot()
    {

    }


    IEnumerator DelayCanvas()
    {
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
    }*/

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
