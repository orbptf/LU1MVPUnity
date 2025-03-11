using System;
using TMPro;
using UnityEngine;

public class WorldButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;

    public GameObject deleteButton1;
    public GameObject deleteButton2;
    public GameObject deleteButton3;
    public GameObject deleteButton4;
    public GameObject deleteButton5;

    public TextMeshProUGUI worldPlayTekst;



    public ScreenHandler screenHandler;
    public ApiConnector apiConnector;
    public PlayHandler playHandler;

    public string choosenWorld;

    public void Button1DirectUser()
    {
        string buttonText = text1.text;
        apiConnector.currentEnvironment = 1;
        Navigate(buttonText, 1);
    }

    public void Button2DirectUser()
    {
        string buttonText = text2.text;
        apiConnector.currentEnvironment = 2;
        Navigate(buttonText, 2);
    }

    public void Button3DirectUser()
    {
        string buttonText = text3.text;
        apiConnector.currentEnvironment = 3;
        Navigate(buttonText, 3);
    }

    public void Button4DirectUser()
    {
        string buttonText = text4.text;
        apiConnector.currentEnvironment = 4;
        Navigate(buttonText, 4);
    }

    public void Button5DirectUser()
    {
        string buttonText = text5.text;
        apiConnector.currentEnvironment = 5;
        Navigate(buttonText, 5);
    }

    public void Navigate(string buttonText, int button)
    {
        DeleteDeleteButtons();
        if (buttonText == "+")
        {
            screenHandler.GoToWorldCreationScreen();
        }
        else if (buttonText == apiConnector.environmentNameIds[button - 1].name)
        {
            choosenWorld = buttonText;
            worldPlayTekst.text = choosenWorld;
            playHandler.LoadPrefabsInWorld();
            screenHandler.GoToPlayScreen();
        }
        else
        {
            Debug.Log("PROGRAMMA: Navigatie werkt niet");
        }
    }

    public void DeleteDeleteButtons()
    {
        deleteButton1.SetActive(false);
        deleteButton2.SetActive(false);
        deleteButton3.SetActive(false);
        deleteButton4.SetActive(false);
        deleteButton5.SetActive(false);
    }
}
