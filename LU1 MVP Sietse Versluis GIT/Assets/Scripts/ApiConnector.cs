using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ApiConnector : MonoBehaviour
{
    public InputHandler inputHandler;
    public ScreenHandler screenHandler;
    public NotificationHandler notificationHandler;
    public DraggableHandler draggableHandler;
    public LoadPrefabsHandler loadPrefabsHandler;
    public WorldLoadingHandler worldLoadingHandler;

    public GameObject confirmPopUp;

    //public List<string> worldNames;
    //public List<string> worldIds;

    public List<EnvironmentNameId> environmentNameIds = new List<EnvironmentNameId>();
    public List<Object2D> publicObject2Ds = new List<Object2D>();
    //public EnvironmentNameId environmentNameId;

    public int currentEnvironment;



    [Header("Test data")]
    public User user;
    public Environment2D environment2D;
    public Object2D object2D;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public Environment2DApiClient enviroment2DApiClient;
    public Object2DApiClient object2DApiClient;

    #region Login

    [ContextMenu("User/Register")]
    public async void Register()
    {
        user.email = inputHandler.returnRegistrationEmailInput();
        user.password = inputHandler.returnRegistrationPasswordInput();

        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Register succes!");
                notificationHandler.NotificationCorrectRegister();
                screenHandler.GoToLoginScreen();
                break;
            case WebRequestError errorResponse:
                notificationHandler.NotificationUserAlreadyExistsOrNoSpecialCharacter();
                Debug.Log("usernamealreadyexistsorno@usedinusernameornotekstafter@"); //in plaats van de gebruikelijke validators
                break;
            default:
                notificationHandler.NotificationServerError();
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("User/Login")]
    public async void Login()
    {
        inputHandler.setLoginCredentials(); //moet weg na nieuwe validatiemethode
        user.email = inputHandler.returnLoginEmailInput();
        user.password = inputHandler.returnLoginPasswordInput();

        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Login succes!");
                notificationHandler.NotificationCorrectLogin();
                screenHandler.LoadWorldSelectionScreen();
                break;
            case WebRequestError errorResponse:
                Debug.Log("Combinatiew8woordgebruiksersnaambestaatniet");
                notificationHandler.NotificationInvalidLogin();
                break;
            default:
                notificationHandler.NotificationServerError();
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

    #region Environment

    [ContextMenu("Environment2D/Read all")]
    public async Task ReadEnvironment2Ds()
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.ReadEnvironment2Ds();

        switch (webRequestResponse)
        {
            case WebRequestData<List<Environment2D>> dataResponse:
                List<Environment2D> environment2Ds = dataResponse.Data;
                environmentNameIds.Clear();
                foreach (var environment2D in environment2Ds)
                {
                    if (environment2D.usermail == user.email)
                    {
                        EnvironmentNameId environmentNameId = new EnvironmentNameId();
                        environmentNameId.name = environment2D.name;
                        environmentNameId.id = environment2D.id;
                        environmentNameIds.Add(environmentNameId);

                        //worldNames.Add(environment2D.name);
                        //worldIds.Add(environment2D.id);
                    }
                }
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read environment2Ds error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Environment2D/Create")]
    public async void CreateEnvironment2D()
    {
        environment2D.name = inputHandler.returnWorldNameInput();
        environment2D.maxLength = 1080;
        environment2D.maxHeight = 1080;
        environment2D.usermail = user.email;

        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.CreateEnvironment(environment2D);

        switch (webRequestResponse)
        {
            case WebRequestData<Environment2D> dataResponse:
                //environment2D.id = dataResponse.Data.id;
                notificationHandler.NotificationCorrectWorldCreated();
                screenHandler.LoadWorldSelectionScreen();
                inputHandler.resetWorldNameInput();
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create environment2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Environment2D/Delete")]
    public async void DeleteEnvironment2D(string givenEnvironmentId)
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.DeleteEnvironment(givenEnvironmentId);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;

                Debug.Log("Deletion confimed, loading worlds");
                environmentNameIds.Clear();
                worldLoadingHandler.LoadWorlds();
                screenHandler.LoadWorldSelectionScreen();
                confirmPopUp.SetActive(false);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete environment error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion Environment

    #region Object2D

    [ContextMenu("Object2D/Read all")]
    public async Task ReadObject2Ds(bool showPrefabs)
    {

        IWebRequestReponse webRequestResponse = await object2DApiClient.ReadObject2Ds(environmentNameIds[currentEnvironment - 1].id); //dit stond er eerst in: object2D.environmentId

        switch (webRequestResponse)
        {
            case WebRequestData<List<Object2D>> dataResponse:
                publicObject2Ds.Clear();
                List<Object2D> object2Ds = dataResponse.Data;
                Debug.Log("List of object2Ds: " + object2Ds);

                foreach (var object2d in object2Ds)
                {
                    Debug.Log(object2d.id);
                    publicObject2Ds.Add(object2d);
                    if (showPrefabs)
                    {
                        loadPrefabsHandler.LoadPrefab(object2d);
                    }
                }

                //object2Ds.ForEach(object2D => Debug.Log(object2D.id));
                // TODO: Succes scenario. Show the enviroments in the UI
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read object2Ds error: " + errorMessage);
                // TODO: Error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Create")]
    public async Task CreateObject2D()
    {
        //object2D.environmentId = environment2D.id;
        //object2D.prefabId = draggableHandler.ReturnObject2DPrefabId();
        //object2D.positionX = draggableHandler.ReturnObject2DPositionX();
        //object2D.positionY = draggableHandler.ReturnObject2DPositionY();
        //object2D.scaleX = 1;
        //object2D.scaleY = 1;
        //object2D.sortingLayer = 1;

        IWebRequestReponse webRequestResponse = await object2DApiClient.CreateObject2D(object2D);

        switch (webRequestResponse)
        {
            case WebRequestData<Object2D> dataResponse:
                //object2D.id = dataResponse.Data.id;
                // TODO: Handle succes scenario.
                Debug.Log("HETISGELUKTOMDIESTOMMEOBJECTOPTESLAAN");
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create Object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Update")]
    public async void UpdateObject2D()
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.UpdateObject2D(object2D);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Update object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    //zelf toegevoegd:
    [ContextMenu("Object2D/Delete")]
    
    public async Task DeleteObject2D(Object2D givenObject2D, Environment2D givenEnvironment2D)
    {
        IWebRequestReponse webRequestReponse = await object2DApiClient.DeleteObject2D(givenObject2D, givenEnvironment2D);

        switch(webRequestReponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Object verwijderd");
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete object2D error: " + errorMessage);
                break;
            default:
                Debug.Log("Er is iets dramatisch fout gegaan");
                //throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
                break;
        }
    }

    #endregion

}
