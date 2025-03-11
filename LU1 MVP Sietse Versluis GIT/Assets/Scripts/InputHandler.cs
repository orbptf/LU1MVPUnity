using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{
    //login
    [SerializeField] TMP_InputField emailInputField;
    [SerializeField] TMP_InputField passwordInputField;
    string emailInput;
    string passwordInput;

    //register
    [SerializeField] TMP_InputField registrationEmailInputField;
    [SerializeField] TMP_InputField registrationPasswordInputField;
    string registrationEmailInput;
    string registrationPasswordInput;

    //worldcreation
    [SerializeField] TMP_InputField worldNameInputField;
    string worldNameInput;

    //validation
    public ValidateWorldCreationCredentials validateWorldCreationCredentials;
    public ValidateRegisterCredentials validateRegisterCredentials;

    //external code
    public ApiConnector apiConnector;
    public NotificationHandler notificationHandler;


    #region Set and validate credentials

    public void setLoginCredentials()
    {
        emailInput = emailInputField.text;
        passwordInput = passwordInputField.text;
    }

    public void setRegistrationCredentials()
    {
        string validatorOutcome = validateRegisterCredentials.outcome(registrationPasswordInputField.text);
        switch (validatorOutcome)
        {
            case "correct":
                registrationEmailInput = registrationEmailInputField.text;
                registrationPasswordInput = registrationPasswordInputField.text;
                apiConnector.Register();
                break;
            case "passwordtoshort":
                notificationHandler.NotificationPasswordToShort();
                Debug.Log("passwordtoshort");
                break;
            case "nouppercase":
                notificationHandler.NotificationNoUpperCase();
                Debug.Log("nouppercase");
                break;
            case "nolowercase":
                notificationHandler.NotificationNoLowerCase();
                Debug.Log("nolowercase");
                break;
            case "nodigit":
                notificationHandler.NotificationNoDigit();
                Debug.Log("nodigit");
                break;
            case "nospecial":
                notificationHandler.NotificationNoSpecial();
                Debug.Log("nospecial");
                break;
        }  
    }

    public void SetWorldCreationCredentials()
    {
        string validatorOutcome = validateWorldCreationCredentials.Outcome(worldNameInputField.text);
        switch (validatorOutcome)
        {
            case "correct":
                worldNameInput = worldNameInputField.text;
                apiConnector.CreateEnvironment2D();
                break;
            case "toshort":
                notificationHandler.NotificationInvalidWorldNameToShort();
                Debug.Log("worldnametoshort");
                break;
            case "tolong":
                notificationHandler.NotificationInvalidWorldNameToLong();
                Debug.Log("worldnametolong");
                break;
            case "alreadyinuse":
                notificationHandler.NotificationInvalidWorldNameAlreadyExists();
                Debug.Log("wordnamealreadyinuse");
                break;
            case "cantuseplus":
                notificationHandler.NotificationInvalidWorldNameCantBePlus();
                Debug.Log("cantuseplus");
                break;

        }
    }

    #endregion

    #region Return input

    public string returnLoginEmailInput()
    {
        return emailInput;
    }
    
    public string returnLoginPasswordInput()
    {
        return passwordInput;
    }

    public string returnRegistrationEmailInput()
    {
        return registrationEmailInput;
    }

    public string returnRegistrationPasswordInput()
    {
        return registrationPasswordInput;
    }

    public string returnWorldNameInput()
    {
        return worldNameInput;
    }

    public void resetWorldNameInput()
    {
        worldNameInputField.text = null;
    }
}

#endregion