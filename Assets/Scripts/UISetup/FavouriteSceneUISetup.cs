using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FavouriteSceneUISetup : MonoBehaviour
{
    [SerializeField] private ShortcutButton favButtonTemplate;
    [SerializeField] private GameObject verticalLayout;

    [SerializeField] private List<StationSO> stationSOList;

    private Coroutine notificationCR;

    void Start()
    {
        this.stationSOList = staticset.Instance.stationSOList;
        Debug.Log(stationSOList.Count);

        foreach (StationSO so in staticset.Instance.stationSOList)
        {
            if (so.IsFav)
            {
                ShortcutButton newButton = Instantiate(favButtonTemplate, verticalLayout.transform);
                newButton.Init(so.GetStationName, so.GetStationMainPicture);
                newButton.gameObject.SetActive(true);
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadInfoScene(so));
            }
        }
        favButtonTemplate.gameObject.SetActive(false);
    }

    public void LoadInfoScene(StationSO station)
    {
        staticset.Instance.currentStation = station;
        SceneManager.LoadScene("StationInfo");
    }
}


