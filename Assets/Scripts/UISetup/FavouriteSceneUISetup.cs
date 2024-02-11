using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
                newButton.gameObject.SetActive(transform);
                newButton.GetComponent<Button>().onClick.AddListener(() => newButton.gameObject.SetActive(false));
            }
        }
        favButtonTemplate.gameObject.SetActive(false);
    }
}


