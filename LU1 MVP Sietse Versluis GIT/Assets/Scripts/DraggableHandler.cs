using System;
using UnityEngine;

public class DraggableHandler : MonoBehaviour
{
    //public ApiConnector apiConnector;

    public Transform trans;

    public int prefabNumber;

    private Vector3 lastPosition;

    private Vector3 firstPosition;

    private bool isDragging = false;

    private string prefabObjectId;

    public void StartDragging()
    {
        isDragging = true;
    }

    public void Update()
    {
        if (isDragging)
        {
            trans.position = GetMousePosition();

            //if (Input.GetMouseButtonDown(0))
            //{
            //    StopDragging();
            //}
        }
    }

    public async void StopDragging()
    {
        isDragging = false;

        firstPosition = trans.position;
        Debug.Log($"Prefab {prefabNumber}:::");
        
        Debug.Log($"firstposition = {firstPosition}");
        
        Debug.Log("object losgelaten");



        ApiConnector apiConnector = FindFirstObjectByType<ApiConnector>();

        Debug.Log($"momentele omgeving:::{apiConnector.currentEnvironment}");
        int currentEnvironment = apiConnector.currentEnvironment;

        foreach (var worldId in apiConnector.environmentNameIds)
        {
            Debug.Log(worldId.name);
            Debug.Log(worldId.id);
        }

        apiConnector.object2D = new Object2D
        {
            environmentId = apiConnector.environmentNameIds[currentEnvironment - 1].id, // Zorg dat dit correct is ingesteld
            prefabId = ReturnObject2DPrefabId(),
            positionX = ReturnObject2DPositionX(),
            positionY = ReturnObject2DPositionY(),
            scaleX = 1,
            scaleY = 1,
            sortingLayer = 1
        };

        await apiConnector.CreateObject2D();
    }

    private void OnMouseDown()
    {
        Debug.Log("onmousedown");
    }

    private void OnMouseUp()
    {
        Debug.Log("onmouseup");
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }








    public string ReturnObject2DPrefabId()
    {
        return Convert.ToString(prefabNumber);
    }

    public float ReturnObject2DPositionX()
    {
        return trans.position.x;
    }

    public float ReturnObject2DPositionY()
    {
        return trans.position.y;
    }
}
