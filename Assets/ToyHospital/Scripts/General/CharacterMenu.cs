using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    private SaveManager save;
    public GameObject character;
    public List<ChangerPlayer> outfitChangers = new List<ChangerPlayer>(); //Lista cambio de outfits pero que sea aleatoria

    private void Awake()
    {
        save = FindObjectOfType<SaveManager>();
    }
    public void RandomizeCharacter() //Funcion aleatoria para multiples cambios de atuendos
    {
        foreach(ChangerPlayer changer in outfitChangers)
        {
            changer.Randomize();
        }
    }

    public void Submit()
    {
        save.Save();
        //PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab"); //Guardar cambios de la anterior escena, sobreescribe al personaje
        SceneManager.LoadScene(2);
    }
}
