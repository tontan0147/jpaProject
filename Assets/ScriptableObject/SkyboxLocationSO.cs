using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkyboxLocationSO", menuName = "ScriptableObjects/SkyboxLocationSO")]
public class SkyboxLocationSO : ScriptableObject
{
    [Header("[0] On the Boat")]
    [Header("[1] On the Station")]
    [Header("[2] On the Barge")]
    [SerializeField]
    private Material[] skyBoxMaterial;
    [Header("Station Info")]
    [SerializeField]
    [TextArea(15, 20)]
    private string infoText;

    public Material GetSkyboxMat(int x)
    {
        return skyBoxMaterial[x];
    }

    public int GetSkyboxLength()
    {
        return skyBoxMaterial.Length;
    }
    public string GetStationInfo()
    {
        return infoText;
    }


}
