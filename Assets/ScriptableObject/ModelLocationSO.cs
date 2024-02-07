using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModelLocationSO", menuName = "ScriptableObjects/ModelLocationSO")]
public class ModelLocationSO : ScriptableObject
{
    [Header("[0] On the Boat")]
    [Header("[1] On the Station")]
    [Header("[2] On the Barge")]
    [SerializeField]
    private GameObject stationPrefab;
    [SerializeField]
    private Camera[] camerasList;
    private GameObject cam;

    public Camera GetCamera(int camPos)
    {
        return camerasList[camPos];
    }

    public Camera[] GetAllCamera()
    {
        return camerasList;
    }

    public GameObject GetStationPrefab => stationPrefab;
}
public enum CameraPosition
{
    TOP,
    STATION,
    BARGE
}
