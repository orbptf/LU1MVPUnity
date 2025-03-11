using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using System.Threading.Tasks;

public class WorldLoadingHandler : MonoBehaviour
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

    public ApiConnector apiConnector;
    public ScreenHandler screenHandler;
    public PrefabInstantiatorHandler prefabInstantiatorHandler;

    public async void LoadWorlds()
    {
        Debug.Log("Loading worlds");

        text1.text = "+";
        text2.text = "+";
        text3.text = "+";
        text4.text = "+";
        text5.text = "+";

        deleteButton1.SetActive(false);
        deleteButton2.SetActive(false);
        deleteButton3.SetActive(false);
        deleteButton4.SetActive(false);
        deleteButton5.SetActive(false);

        apiConnector.environmentNameIds.Clear();
        prefabInstantiatorHandler.ClearPrefabs();
        await apiConnector.ReadEnvironment2Ds();
        
        for (int worldPositionInList = 0; worldPositionInList < apiConnector.environmentNameIds.Count; worldPositionInList++)
        {
            string worldName = apiConnector.environmentNameIds[worldPositionInList].name;

            if (worldPositionInList == 0)
            {
                text1.text = worldName;
                deleteButton1.SetActive(true);
            }
            else if (worldPositionInList == 1)
            {
                text2.text = worldName;
                deleteButton2.SetActive(true);
            }
            else if (worldPositionInList == 2)
            {
                text3.text = worldName;
                deleteButton3.SetActive(true);
            }
            else if (worldPositionInList == 3)
            {
                text4.text = worldName;
                deleteButton4.SetActive(true);
            }
            else if (worldPositionInList == 4)
            {
                text5.text = worldName;
                deleteButton5.SetActive(true);
            }
        }
        screenHandler.GoToWorldSelectionScreen();
    }   
}
