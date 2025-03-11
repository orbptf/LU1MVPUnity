using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteWorldButtonHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    
    public GameObject confirmPopUp;
    public TextMeshProUGUI selectedWorldText;

    public Button deleteWorld1Button;
    public Button deleteWorld2Button;
    public Button deleteWorld3Button;
    public Button deleteWorld4Button;
    public Button deleteWorld5Button;

    private int deleteButtonClicked;

    public void OnDeleteButton1Clicked()
    {
        deleteButtonClicked = 1;
    }

    public void OnDeleteButton2Clicked()
    {
        deleteButtonClicked = 2;
    }

    public void OnDeleteButton3Clicked()
    {
        deleteButtonClicked = 3;
    }

    public void OnDeleteButton4Clicked()
    {
        deleteButtonClicked = 4;
    }

    public void OnDeleteButton5Clicked()
    {
        deleteButtonClicked = 5;
    }

    public void ShowConformationPopup()
    {
        selectedWorldText.text = apiConnector.environmentNameIds[deleteButtonClicked - 1].name;
        confirmPopUp.SetActive(true);
    }

}
