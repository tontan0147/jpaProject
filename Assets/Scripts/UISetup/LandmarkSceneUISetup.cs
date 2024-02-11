using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LandmarkSceneUISetup : MonoBehaviour
{
    [SerializeField] private Image mainPicture;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private TextMeshProUGUI stationDes;
    [SerializeField] private TextMeshProUGUI schedule;
    public StationSO station;

    private void Awake()
    {
        //landmark = staticset.Instance.currentLandmark;
    }
    void Start()
    {
        stationName.text = stationName.text + station.GetLandmarks[0].landmarkName;
        schedule.text = schedule.text + station.GetSchedule;
        mainPicture.sprite = station.GetLandmarks[0].landmarkPicture[0];
        stationDes.text = station.GetLandmarks[0].landmarkDescription;
    }
}
