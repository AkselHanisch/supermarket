using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ListRandomizerEN : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public DetectObject validator; // Drag your hitbox's script here in the Inspector

    public List<string> doneItems = new List<string>(); // Made public

    void Start()
    {
        ShowRandomItems();
    }

    void ShowRandomItems()
    {

        if (doneItems.Count >= 6)
        {
            textoUI.text = "You have completed the list! Congratulations on your english skills! Feel free to hang around the supermarket.";
            validator.SetTargetItem(""); // Clear the target to prevent further processing
            return;
        }

        List<string> myList = new List<string>()
        {
            "Eggs",
            "Soda",
            "Milk",
            "Water",
            "Purple_Cereal_Box",
            "Yellow_Cereal_Box"
        };

        string item = myList[Random.Range(0, myList.Count)];

        while (doneItems.Contains(item))
        {
            item = myList[Random.Range(0, myList.Count)];
        }

        string textToSet = item;
        if (item == "Purple_Cereal_Box")
        {
            textToSet = "Purple Cereal Box";
        }
        else if (item == "Yellow_Cereal_Box")
        {
            textToSet = "Yellow Cereal Box";
        }

        textoUI.text = textToSet;


        validator.SetTargetItem(item);
    }

    public void nextItem()
    {
        Debug.Log("nextItem: " + textoUI.text + " doneItems: " + doneItems.Count);
        if (textoUI.text == "Yellow Cereal Box")
            doneItems.Add("Yellow_Cereal_Box");
        else if (textoUI.text == "Purple Cereal Box")
            doneItems.Add("Purple_Cereal_Box");
        else
            doneItems.Add(textoUI.text);
        ShowRandomItems();
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

        string resultadoFinal = "Trae los art�culos aqu� en orden:\n";

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