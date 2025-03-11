using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CustomButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private DraggableHandler currentDraggableHandler;

    public GameObject prefabRoadSegment1;
    public GameObject prefabRoadSegment2;
    public GameObject prefabRoadSegment3;
    public GameObject prefabRoadSegment4;
    public GameObject prefabRoadSegment5;
    public GameObject prefabRoadSegment6;

    private GameObject selectedPrefabRoadSegmentButton;

    public Vector3 position;
    public int buttonNumber;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"Button {buttonNumber} pressed down!");
        // Hier kan je je logica uitvoeren
        switch (buttonNumber)
        {
            case 1:
                selectedPrefabRoadSegmentButton = prefabRoadSegment1;
                CreateInstanceOfPrefabDie();
                break;
            case 2:
                selectedPrefabRoadSegmentButton = prefabRoadSegment2;
                CreateInstanceOfPrefabDie();
                break;
            case 3:
                selectedPrefabRoadSegmentButton = prefabRoadSegment3;
                CreateInstanceOfPrefabDie();
                break;
            case 4:
                selectedPrefabRoadSegmentButton = prefabRoadSegment4;
                CreateInstanceOfPrefabDie();
                break;
            case 5:
                selectedPrefabRoadSegmentButton = prefabRoadSegment5;
                CreateInstanceOfPrefabDie();
                break;
            case 6:
                selectedPrefabRoadSegmentButton = prefabRoadSegment6;
                CreateInstanceOfPrefabDie();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"Button {buttonNumber} released!");
        currentDraggableHandler.StopDragging();
    }

    public void CreateInstanceOfPrefabDie()
    {
        GameObject instanceOfRoadSegment = Instantiate(selectedPrefabRoadSegmentButton, position, Quaternion.identity);
        currentDraggableHandler = instanceOfRoadSegment.GetComponent<DraggableHandler>();
        currentDraggableHandler.StartDragging();
    }
}
