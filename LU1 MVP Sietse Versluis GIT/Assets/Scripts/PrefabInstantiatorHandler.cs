using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
public class PrefabInstantiatorHandler : MonoBehaviour
{
    public Vector3 position;

    public GameObject prefabRoadSegment1;
    public GameObject prefabRoadSegment2;
    public GameObject prefabRoadSegment3;
    public GameObject prefabRoadSegment4;
    public GameObject prefabRoadSegment5;
    public GameObject prefabRoadSegment6;

    public Button RoadSegmentButton1;
    public Button RoadSegmentButton2;
    public Button RoadSegmentButton3;
    public Button RoadSegmentButton4;
    public Button RoadSegmentButton5;
    public Button RoadSegmentButton6;

    private GameObject selectedPrefabRoadSegmentButton;

    public void DiceButton1()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment1;
        CreateInstanceOfPrefabDie();
    }

    public void DiceButton2()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment2;
        CreateInstanceOfPrefabDie();
    }

    public void DiceButton3()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment3;
        CreateInstanceOfPrefabDie();
    }

    public void DiceButton4()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment4;
        CreateInstanceOfPrefabDie();
    }

    public void DiceButton5()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment5;
        CreateInstanceOfPrefabDie();
    }

    public void DiceButton6()
    {
        selectedPrefabRoadSegmentButton = prefabRoadSegment6;
        CreateInstanceOfPrefabDie();
    }

    public void CreateInstanceOfPrefabDie()
    {
        GameObject instanceOfRoadSegment = Instantiate(selectedPrefabRoadSegmentButton, position, Quaternion.identity);
        DraggableHandler draggableHandler = instanceOfRoadSegment.GetComponent<DraggableHandler>();    
        draggableHandler.StartDragging();
    }

    public void ClearPrefabs()
    {
        DraggableHandler[] draggableObjects = FindObjectsByType<DraggableHandler>(FindObjectsSortMode.None);

        foreach (DraggableHandler draggable in draggableObjects)
        {
            Destroy(draggable.gameObject);
        }

        Debug.Log(draggableObjects.Length + " objecten met DraggableHandler vernietigd.");
    }
}
