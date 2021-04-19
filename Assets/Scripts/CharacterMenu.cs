using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharacterMenu : MonoBehaviour
{
    public GameObject character;
    public List<Changer> outfitChangers = new List<Changer>(); //Lista cambio de outfits pero que sea aleatoria
    public void RandomizeCharacter() //Funcion aleatoria para multiples cambios de atuendos
    {
        foreach(Changer changer in outfitChangers)
        {
            changer.Randomize();
        }
    }

    public void Submit()
    {
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab"); //Guardar cambios de la anterior escena, sobreescribe al personaje
        SceneManager.LoadScene(2);
    }
}
