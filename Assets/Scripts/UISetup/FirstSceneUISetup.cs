using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FirstSceneUISetup : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInputField; // Reference to the TMP InputField in the Inspector
    [SerializeField] private GameObject noSearchResultText;
    
    [SerializeField] private ShortcutStationButton stationButtonTemplate;
    [SerializeField] private ShortcutStationButton recStationButtonTemplate;
    [SerializeField] private GameObject horizontalLayout;
    [SerializeField] private GameObject recHhorizontalLayout;
    private List<ShortcutStationButton> shortcutStationButtonList = new List<ShortcutStationButton>();
    private List<ShortcutStationButton> recShortcutStationButtonList = new List<ShortcutStationButton>();
    private string partialNameToSearch;
    public List<ShortcutStationButton> GetAllShortcutStationButton => shortcutStationButtonList;
    private void Awake()
    {
        noSearchResultText.SetActive(false);
        searchInputField.onEndEdit.AddListener(HandleInputEnd);
    }
    void Start()
    {
        foreach (StationSO so in staticset.Instance.stationSOList)
        {
            ShortcutStationButton newButton = Instantiate(stationButtonTemplate, horizontalLayout.transform);
            newButton.gameObject.SetActive(true);
            newButton.Init(so.GetStationName, so.GetStationMainPicture, so.GetAllFlags);
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadStationOverviewScene(so));
            //newButton.transform.SetAsFirstSibling();
            shortcutStationButtonList.Add(newButton);
        }
        stationButtonTemplate.gameObject.SetActive(false);

        foreach (StationSO so in staticset.Instance.recStationSOList)
        {
            ShortcutStationButton newButton = Instantiate(recStationButtonTemplate, recHhorizontalLayout.transform);
            newButton.gameObject.SetActive(true);
            newButton.Init(so.GetStationName, so.GetStationMainPicture, so.GetAllFlags);
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadStationOverviewScene(so));
            newButton.transform.SetAsFirstSibling();
            recShortcutStationButtonList.Add(newButton);
        }
        recStationButtonTemplate.gameObject.SetActive(false);
    }
    private void LoadStationOverviewScene(StationSO station)
    {
        staticset.Instance.currentStation = station;
        SceneManager.LoadScene("StationInfo");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("First");
        }
    }

    private void FindObjectsByPartialName(string partialName)
    {
        bool isFound = false;
        noSearchResultText.SetActive(isFound);
        foreach (ShortcutStationButton button in shortcutStationButtonList)
        {
            bool shouldSetActive = button.GetLocationName.Contains(partialName);
            button.gameObject.SetActive(shouldSetActive);
            if (shouldSetActive)
            {
                isFound = true;
            }
        }
        foreach (ShortcutStationButton button in recShortcutStationButtonList)
        {
            bool shouldSetActive = button.GetLocationName.Contains(partialName);
            button.gameObject.SetActive(shouldSetActive);
            if (shouldSetActive)
            {
                isFound = true;
            }
        }
        if (!isFound)
        {
            noSearchResultText.SetActive(true);
        }
    }

    private void HandleInputEnd(string input)
    {
        partialNameToSearch = input;
        FindObjectsByPartialName(partialNameToSearch);
    }
}
