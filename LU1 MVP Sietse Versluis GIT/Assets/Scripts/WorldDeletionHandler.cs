using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class WorldDeletionHandler : MonoBehaviour
{
    public ApiConnector apiConnector;
    public WorldLoadingHandler worldLoadingHandler;
    public ScreenHandler screenHandler;

    public TextMeshProUGUI selectedworldText;
    public Button deleteButton1;
    public Button deleteButton2;
    public Button deleteButton3;
    public Button deleteButton4;
    public Button deleteButton5;

    public GameObject confirmPopUp;

    private int selectedWorld;

    public void ClickedDeleteButton1()
    {
        selectedWorld = 1;
        ShowConfirmPopUp();
    }

    public void ClickedDeleteButton2()
    {
        selectedWorld = 2;
        ShowConfirmPopUp();
    }

    public void ClickedDeleteButton3()
    {
        selectedWorld = 3;
        ShowConfirmPopUp();
    }

    public void ClickedDeleteButton4()
    {
        selectedWorld = 4;
        ShowConfirmPopUp();
    }

    public void ClickedDeleteButton5()
    {
        selectedWorld = 5;
        ShowConfirmPopUp();
    }

    public void ShowConfirmPopUp()
    {
        selectedworldText.text = apiConnector.environmentNameIds[selectedWorld - 1].name;
        confirmPopUp.SetActive(true);
    }

    

    public async void ClickedConfirmDeletion()
    {
        await DeleteSelectedWorldObjects();
        DeleteSelectedWorld();
    }

    public void ClickedCancelDeletion()
    {
        Debug.Log("Deletion canceld");
        confirmPopUp.SetActive(false);
    }

    public async Task DeleteSelectedWorldObjects()
    {
        await apiConnector.ReadObject2Ds(false);
        Debug.Log($"ZOVEEL DINGEN IN OBJECTENLIJST: {apiConnector.publicObject2Ds.Count}");
        foreach (Object2D object2D in apiConnector.publicObject2Ds)
        {
            Environment2D environmentForDeletion = new Environment2D();
            environmentForDeletion.id = apiConnector.environmentNameIds[selectedWorld - 1].id;
            environmentForDeletion.name = "";
            environmentForDeletion.maxHeight = 0;
            environmentForDeletion.maxLength = 0;
            environmentForDeletion.usermail = "";

            Debug.Log($"Deleting object: {object2D.id}");
            await apiConnector.DeleteObject2D(object2D, environmentForDeletion);
        }
    }

    public void DeleteSelectedWorld()
    {
        Debug.Log("Deleting world:");
        apiConnector.DeleteEnvironment2D(apiConnector.environmentNameIds[selectedWorld - 1].id);
    }
}
