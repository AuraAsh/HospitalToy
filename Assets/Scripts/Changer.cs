using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Parameter
{
    public int currentOption;
}
public class Changer : MonoBehaviour
{
    public Parameter parameter;

    [Header ("Sprite To Change")] //Declarar una lista
    public SpriteRenderer bodyPart;

    [Header("Sprite To Cycle Through")]
    public List<Sprite> options = new List<Sprite>(); //Lista de sprites

    [SerializeField] internal int currentOption = 0; //Opcion actual

   
    public void NextOption()
    {
        currentOption++; //Aumentar la opcion actual en 1
        if (currentOption >= options.Count) //Verificar si hemos excedido el tamaño de la lista 
        {
            currentOption = 0; //y si es asi reestablecer
        }

        bodyPart.sprite = options[currentOption];
    }

    public void PreviousOption() //Funciona como backbutton, hacia atras
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }

        bodyPart.sprite = options[currentOption];
    }

    public void Randomize() //Opciones random para personalizar el personaje
    {
        currentOption = Random.Range(0, options.Count - 1);
        bodyPart.sprite = options[currentOption];
    }
}
