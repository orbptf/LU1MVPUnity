using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadPrefabsHandler : MonoBehaviour
{
    private Vector2 position;

    public GameObject prefabRoadSegment1;
    public GameObject prefabRoadSegment2;
    public GameObject prefabRoadSegment3;
    public GameObject prefabRoadSegment4;
    public GameObject prefabRoadSegment5;
    public GameObject prefabRoadSegment6;
    private GameObject selectedPrefab;
    public void LoadPrefab(Object2D object2D)
    {
        switch (object2D.prefabId)
        {
            case "1":
                selectedPrefab = prefabRoadSegment1;
                break;
            case "2":
                selectedPrefab = prefabRoadSegment2;
                break;
            case "3":
                selectedPrefab = prefabRoadSegment3;
                break;
            case "4":
                selectedPrefab = prefabRoadSegment4;
                break;
            case "5":
                selectedPrefab = prefabRoadSegment5;
                break;
            case "6":
                selectedPrefab = prefabRoadSegment6;
                break;
        }
        position.x = object2D.positionX;
        position.y = object2D.positionY;
        GameObject instanceOfRoadSegment = Instantiate(selectedPrefab, position, Quaternion.identity);
    }
}
