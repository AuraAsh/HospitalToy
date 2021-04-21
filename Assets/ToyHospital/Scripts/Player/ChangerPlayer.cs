using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Parameter
{
    public int currentOption; //Opcion actual
}
public class ChangerPlayer : MonoBehaviour
{
    public Parameter parameter;

    [Header ("Sprite To Change")] //Declarar una lista
    public SpriteRenderer bodyPart;

    [Header("Sprite To Cycle Through")]
    public List<Sprite> options = new List<Sprite>(); //Lista de sprites

    public void NextOption()
    {
        parameter.currentOption++; //Aumentar la opcion actual en 1
        if (parameter.currentOption >= options.Count) //Verificar si hemos excedido el tamaño de la lista 
        {
            parameter.currentOption = 0; //y si es asi reestablecer
        }

        bodyPart.sprite = options[parameter.currentOption];
    }

    public void PreviousOption() //Funciona como backbutton, hacia atras
    {
        parameter.currentOption--;
        if (parameter.currentOption <= 0)
        {
            parameter.currentOption = options.Count - 1;
        }

        bodyPart.sprite = options[parameter.currentOption];
    }

    public void Randomize() //Opciones random para personalizar el personaje
    {
        parameter.currentOption = UnityEngine.Random.Range(0, options.Count - 1);
        bodyPart.sprite = options[parameter.currentOption];
    }

    internal void LoadCurrentSprite()
    {
        bodyPart.sprite = options[parameter.currentOption]; //Cargar Opcion Actual
    }
}
