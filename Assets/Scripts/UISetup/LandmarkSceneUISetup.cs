using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LandmarkSceneUISetup : MonoBehaviour
{
    [SerializeField] private Image mainPicture;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private TextMeshProUGUI stationDes;
    [SerializeField] private TextMeshProUGUI schedule;
    [SerializeField] private TextMeshProUGUI travel;
    public StationSO station;
    private StationSO.Landmark landmark;

    private void Awake()
    {
        station = staticset.Instance.currentStation;
        landmark = staticset.Instance.currentLandmark;
    }
    void Start()
    {
        stationName.text = stationName.text + landmark.landmarkName;
        if(landmark.landmarkSchedule == null)
        {
            schedule.text = schedule.text + "-";
        }
        else
        {
            schedule.text = schedule.text + landmark.landmarkSchedule;
        }
        
        if(landmark.landmarkPicture.Length > 0)
        {
            mainPicture.sprite = landmark.landmarkPicture[0];
        }
        stationDes.text = landmark.landmarkDescription;
        travel.text = landmark.landmarkTravel;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BacktoStation();
        }
    }

    public void BacktoStation()
    {
        staticset.Instance.currentStation = station;
        SceneManager.LoadScene("StationInfo");
    }
}
