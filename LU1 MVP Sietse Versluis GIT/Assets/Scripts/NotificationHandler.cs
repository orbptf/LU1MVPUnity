using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    private float notificationDuration = 3f;

    public GameObject invalidLogin;

    public GameObject correctLogin;
    private bool shouldLoginTimerRun;
    private float loginTimer;



    public GameObject invalidRegisterPasswordToShort;
    public GameObject invalidRegisterNoUpperCase;
    public GameObject invalidRegisterNoLowerCase;
    public GameObject invalidRegisterNoDigit;
    public GameObject invalidRegisterNoSpecial;
    public GameObject invalidRegisterUserAlreadyExistsOrNoSpecialCharacter;

    public GameObject correctRegister;
    private bool shouldRegisterTimerRun;
    private float registerTimer;



    public GameObject invalidWorldNameToShort;
    public GameObject invalidWorldNameToLong;
    public GameObject invalidWorldNameAlreadyExists;
    public GameObject invalidWorldNameCantBePlus;

    public GameObject correctWorld;
    private bool shouldWorldtimerRun;
    private float worldTimer;

    public GameObject serverError;



    void Start()
    {
        ResetNotifications();
        ResetTimers();
    }

    private void Update()
    {
        if (shouldLoginTimerRun)
        {
            loginTimer += Time.deltaTime;
            if (loginTimer >= notificationDuration)
            {
                ResetTimers();
            }
        }

        if (shouldRegisterTimerRun)
        {
            registerTimer += Time.deltaTime;
            if (registerTimer >= notificationDuration)
            {
                ResetTimers();
            }
        }

        if (shouldWorldtimerRun)
        {
            worldTimer += Time.deltaTime;
            if (worldTimer >= notificationDuration)
            {
                ResetTimers();
            }
        }
    }

    public void ResetNotifications()
    {
        invalidLogin.SetActive(false);

        invalidRegisterPasswordToShort.SetActive(false);
        invalidRegisterNoUpperCase.SetActive(false);
        invalidRegisterNoLowerCase.SetActive(false);
        invalidRegisterNoDigit.SetActive(false);
        invalidRegisterNoSpecial.SetActive(false);
        invalidRegisterUserAlreadyExistsOrNoSpecialCharacter.SetActive(false);

        invalidWorldNameToShort.SetActive(false);
        invalidWorldNameToLong.SetActive(false);
        invalidWorldNameAlreadyExists.SetActive(false);
        invalidWorldNameCantBePlus.SetActive(false);

        serverError.SetActive(false);
    }

    public void ResetTimers()
    {
        correctLogin.SetActive(false);
        shouldLoginTimerRun = false;
        loginTimer = 0;

        correctRegister.SetActive(false);
        shouldRegisterTimerRun = false;
        registerTimer = 0;

        correctWorld.SetActive(false);
        shouldWorldtimerRun = false;
        worldTimer = 0;
    }

    #region Login

    public void NotificationInvalidLogin()
    {
        invalidLogin.SetActive(true);
    }

    public void NotificationCorrectLogin()
    {
        correctLogin.SetActive(true);
        shouldLoginTimerRun = true;
    }

    #endregion

    #region Register

    public void NotificationPasswordToShort()
    {
        invalidRegisterPasswordToShort.SetActive(true);
    }

    public void NotificationNoUpperCase()
    {
        invalidRegisterNoUpperCase.SetActive(true);
    }

    public void NotificationNoLowerCase()
    {
        invalidRegisterNoLowerCase.SetActive(true);
    }

    public void NotificationNoDigit()
    {
        invalidRegisterNoDigit.SetActive(true);
    }

    public void NotificationNoSpecial()
    {
        invalidRegisterNoSpecial.SetActive(true);
    }
    
    public void NotificationCorrectRegister()
    {
        correctRegister.SetActive(true);
        shouldRegisterTimerRun = true;
    }

    public void NotificationUserAlreadyExistsOrNoSpecialCharacter()
    {
        invalidRegisterUserAlreadyExistsOrNoSpecialCharacter.SetActive(true);
    }

    public void NotificationServerError()
    {
        serverError.SetActive(true);
    }

    #endregion

    #region World

    public void NotificationInvalidWorldNameToShort()
    {
        invalidWorldNameToShort.SetActive(true);
    }

    public void NotificationInvalidWorldNameToLong()
    {
        invalidWorldNameToLong.SetActive(true);
    }

    public void NotificationInvalidWorldNameAlreadyExists()
    {
        invalidWorldNameAlreadyExists.SetActive(true);
    }

    public void NotificationInvalidWorldNameCantBePlus()
    {
        invalidWorldNameCantBePlus.SetActive(true);
    }

    public void NotificationCorrectWorldCreated()
    {
        correctWorld.SetActive(true);
        shouldWorldtimerRun = true;
    }

    #endregion
}
