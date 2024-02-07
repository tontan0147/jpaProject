using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField]
    private GameObject[] camerasList;

    [SerializeField]
    [TextArea(15, 20)]
    private string infoText;
    private GameObject cam;

    public GameObject GetCamera(int camPos)
    {
        return camerasList[camPos];
    }

    public GameObject[] GetAllCamera()
    {
        return camerasList;
    }

    public string GetStationInfo()
    {
        return infoText;
    }

    public void SetActiveCamera(int camIndex)
    {
        Debug.Log("Set Camera: " + camIndex);
        foreach (GameObject obj in camerasList)
        {
            obj.SetActive(false);
        }
        camerasList[camIndex].SetActive(true);
    }
}
