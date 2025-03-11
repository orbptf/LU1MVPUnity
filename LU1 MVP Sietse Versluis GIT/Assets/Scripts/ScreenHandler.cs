using UnityEngine;

public class ScreenHandler : MonoBehaviour
{
    public GameObject loginScreen;
    public GameObject registerScreen;
    public GameObject worldSelectionScreen;
    public GameObject worldCreationScreen;
    public GameObject playScreen;
    public GameObject notificationPopUpScreen;

    public WorldLoadingHandler worldLoadingHandler;

    public void Start()
    {
        registerScreen.SetActive(false);
        worldSelectionScreen.SetActive(false);
        worldCreationScreen.SetActive(false);
        playScreen.SetActive(false);

        notificationPopUpScreen.SetActive(true);
        loginScreen.SetActive(true);
    }

    public void GoToLoginScreen()
    {
        registerScreen.SetActive(false);
        worldSelectionScreen.SetActive(false);
        worldCreationScreen.SetActive(false);
        playScreen.SetActive(false);

        loginScreen.SetActive(true);
    }

    public void GoToRegistrationScreen()
    {
        loginScreen.SetActive(false);
        worldSelectionScreen.SetActive(false);
        worldCreationScreen.SetActive(false);
        playScreen.SetActive(false);

        registerScreen.SetActive(true);
    }

    public void LoadWorldSelectionScreen()
    {
        loginScreen.SetActive(false);
        registerScreen.SetActive(false);
        worldCreationScreen.SetActive(false);
        playScreen.SetActive(false);

        worldLoadingHandler.LoadWorlds();
    }

    public void GoToWorldSelectionScreen()
    {
        worldCreationScreen.SetActive(false);
        worldSelectionScreen.SetActive(true);
    }

    public void GoToWorldCreationScreen()
    {
        loginScreen.SetActive(false);
        registerScreen.SetActive(false);
        worldSelectionScreen.SetActive(false);
        playScreen.SetActive(false);

        worldCreationScreen.SetActive(true);
    }

    public void GoToPlayScreen()
    {
        loginScreen.SetActive(false);
        registerScreen.SetActive(false);
        worldSelectionScreen.SetActive(false);
        worldCreationScreen.SetActive(false);

        playScreen.SetActive(true);
    }
}
