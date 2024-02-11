using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticset : MonoBehaviour
{
    private static staticset _instance;
    public static staticset Instance => _instance;

    public int sky = 0;
    public int model = 0;
    public int information = 0;
    public StationSO currentStation;
    public StationSO.Landmark currentLandmark;
    public List<StationSO> stationSOList = new List<StationSO>();


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
