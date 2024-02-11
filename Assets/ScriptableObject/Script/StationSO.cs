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
    public enum Visual
    {
        _3D,
        _360,
        BOTH
    };
    public enum Flag
    {
        Green,
        Orange,
        Yellow,
        Red
    };
    [Header("Station Detail")]
    [SerializeField] private string stationName = "Station";
    [SerializeField] private string stationKeyword = "Key";
    [SerializeField] private Visual visual = Visual.BOTH;
    [SerializeField] private string schedule = "9:00 - 10:00";
    [SerializeField] private Sprite stationMainPicture;
    [SerializeField] private Sprite[] stationSubPictures;
    [SerializeField] private Flag[] flags;
    [SerializeField] private bool isFav = false;

    public string GetStationName => stationName;
    public string GetStationKeyword => stationKeyword;
    public Visual GetStationVisual => visual;
    public string GetSchedule => schedule;
    public Sprite GetStationMainPicture => stationMainPicture;
    public Sprite[] GetStationSubPictures => stationSubPictures;
    public Flag[] GetAllFlags => flags;
    public string GetStationDescription => infoText;
    //public bool GetIsFavourite => isFav;
    public Landmark[] GetLandmarks => landmarks;
    public bool IsFav
    {
        get { return isFav; }
        set { isFav = value; }
    }

    [Header("Landmark")]
    [SerializeField] private Landmark[] landmarks;

    [Header("Station Description")]
    [SerializeField] [TextArea(15, 20)] private string infoText;
}

