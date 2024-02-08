using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StationSO", menuName = "ScriptableObjects/StationSO")]
public class StationSO : ScriptableObject
{
    [System.Serializable]
    public struct Landmark
    {
        public string landmarkName;
        public Sprite[] landmarkPicture;
        [TextArea(3, 5)] public string landmarkDescription;
    }
    public enum Overview
    {
        _3D,
        _360,
        BOTH
    };
    [Header("Station Detail")]
    [SerializeField] private string stationName = "Station";
    [SerializeField] private string stationKeyword = "Key";
    [SerializeField] private Overview overview = Overview.BOTH;
    [SerializeField] private string schedule = "9:00 - 10:00";
    [SerializeField] private Sprite stationMainPicture;

    public string GetStationName => stationName;
    public string GetStationKeyword => stationKeyword;
    public Overview GetStationOverview => overview;
    public string GetSchedule => schedule;
    public Sprite GetStatioPicture => stationMainPicture;

    [Header("Landmark")]
    [SerializeField] private Landmark[] landmarks;

    [Header("Station Description")]
    [SerializeField] [TextArea(15, 20)] private string infoText;
}
