using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListRandomizerEN : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public DetectObject validator; // Drag your hitbox's script here in the Inspector

    void Start()
    {
        ShowRandomItems();
    }

    void ShowRandomItems()
    {
        List<string> myList = new List<string>()
        {
            "Eggs",
            "Soda",
            "Milk",
            "Water",
            "Purple_Cereal_Box",
            "Yellow_Cereal_Box"
        };

        int randomIndex = Random.Range(0, myList.Count);
        string item = myList[randomIndex];

        textoUI.text = item;


        validator.SetTargetItem(item);
    }
}

/*
using System.Collections.Generic;
using TMPro;
using UnityEngine;

uusing System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListRandomizerES : MonoBehaviour
{
    public TextMeshProUGUI textoUI;

    void Start()
    {
        MostrarItensAleatorios();
    }

    void MostrarItensAleatorios()
    {
        List<string> myList = new List<string>()
        {
            "huevos",
            "Gasosa",
            "Leche",
            "Agua",
            "Caja de cereales morada",
            "Caja de cereales amarilla"
        };

        string resultadoFinal = "Trae los artículos aquí en orden:\n";

        for (int i = 1; i <= 5; i++)
        {
            int randomIndex = Random.Range(0, myList.Count);
            string item = myList[randomIndex];
            resultadoFinal += $"{i}. {item}\n";
            myList.RemoveAt(randomIndex);
        }

        textoUI.text = resultadoFinal;
    }
}*/