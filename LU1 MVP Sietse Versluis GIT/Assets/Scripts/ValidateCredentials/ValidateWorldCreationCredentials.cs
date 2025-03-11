using UnityEngine;

public class ValidateWorldCreationCredentials : MonoBehaviour
{
    public ApiConnector apiConnector;
    public string Outcome(string inputString)
    {
        bool worldAlreadyExists = false;

        foreach (var environment in apiConnector.environmentNameIds)
        {
            if (environment.name == inputString)
            {
                worldAlreadyExists = true;
                break;
            }
        }

        if (inputString.Length < 1)
        {
            return "toshort";
        }
        else if (inputString.Length > 25)
        {
            return "tolong";
        }
        else if (worldAlreadyExists)
        {
            return "alreadyinuse";
        }
        else if (inputString == "+")
        {
            return "cantuseplus";
        }
        else
        {
            return "correct";
        }
    }
}
