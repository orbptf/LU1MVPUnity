using UnityEngine;

public class PlayHandler : MonoBehaviour
{
    public ApiConnector apiConnector;

    public async void LoadPrefabsInWorld()
    {
        await apiConnector.ReadObject2Ds(true);
    }
}
