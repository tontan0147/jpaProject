using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoSceneUISetup : MonoBehaviour
{
    [SerializeField] private Image mainPicture;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private TextMeshProUGUI stationDes;
    [SerializeField] private Toggle favToggle;
    [SerializeField] private ShortcutButton landmarkButtonTemplate;
    [SerializeField] private GameObject verticalLayout;
    [SerializeField] private GameObject notificationText;
    public StationSO stationSO;
    private Coroutine notificationCR;

    private void Awake()
    {
        stationSO = staticset.Instance.currentStation;
    }
    void Start()
    {
        stationName.text = stationSO.GetStationName;
        mainPicture.sprite = stationSO.GetStationMainPicture;
        stationDes.text = stationSO.GetStationDescription;
        favToggle.isOn = stationSO.IsFav;

        favToggle.onValueChanged.AddListener(OnToggleValueChanged);

        int i = 0;
        foreach (StationSO.Landmark item in stationSO.GetLandmarks)
        {
            int cur = i;
            if(item.landmarkName != "")
            {
                ShortcutButton newButton = Instantiate(landmarkButtonTemplate, verticalLayout.transform);
                if (item.landmarkPicture.Length != 0)
                {
                    newButton.Init(item.landmarkName, item.landmarkPicture[i]);
                }
                else
                {
                    newButton.Init(item.landmarkName, null);
                    Debug.Log(stationSO.GetStationName + " doesn't set the landmark name/picture!");
                }
                newButton.gameObject.SetActive(true);
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadSceneLandmark(item));
            }
            i++;
        }
        landmarkButtonTemplate.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("First");
        }
    }

    private void LoadSceneLandmark(StationSO.Landmark landMarkIndex)
    {
        staticset.Instance.currentStation = stationSO;
        staticset.Instance.currentLandmark = landMarkIndex;
        SceneManager.LoadScene("Attraction");
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            stationSO.IsFav = true;
            notificationCR = StartCoroutine(ShowNotification());
        }
        else
        {
            stationSO.IsFav = false;
            StopCoroutine(notificationCR);
            notificationText.gameObject.SetActive(false);
        }
    }
    private IEnumerator ShowNotification()
    {
        float duration = 0.2f;
        float elapsedTime = 0.0f;

        notificationText.gameObject.SetActive(true);

        while (elapsedTime < duration)
        {
            float scale = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            notificationText.transform.localScale = new Vector3(scale, scale, scale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        notificationText.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(1.0f);

        duration = 0.2f;
        elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float scale = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            notificationText.transform.localScale = new Vector3(scale, scale, scale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        notificationText.transform.localScale = Vector3.zero;

        notificationText.gameObject.SetActive(false);
    }


}


