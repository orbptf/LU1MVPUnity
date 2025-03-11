using UnityEngine;

public class ValidateRegisterCredentials : MonoBehaviour
{
    bool containsUpperCharacter = false;
    bool containsLowerCharacter = false;
    bool containsDigitCharacter = false;
    bool containsSpecialCharacter = false;

    public string outcome(string inputPasswordString)
    {
        foreach (char character in inputPasswordString)
        {
            if (char.IsUpper(character))
            {
                containsUpperCharacter = true;
            }

            else if (char.IsLower(character))
            {
                containsLowerCharacter = true;
            }

            else if (char.IsDigit(character))
            {
                containsDigitCharacter = true;
            }

            else if (!char.IsLetterOrDigit(character))
            {
                containsSpecialCharacter = true;
            }
        }



        if (inputPasswordString.Length < 10)
        {
            return "passwordtoshort";
        }

        else if (!containsUpperCharacter)
        {
            return "nouppercase";
        }

        else if (!containsLowerCharacter)
        {
            return "nolowercase";
        }

        else if (!containsDigitCharacter)
        {
            return "nodigit";
        }

        else if (!containsSpecialCharacter)
        {
            return "nospecial";
        }
        else
        {
            return "correct";
        }
    }
}
