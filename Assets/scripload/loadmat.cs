using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class loadmat : MonoBehaviour
{
    [SerializeField]
    private List<SkyboxLocationSO> skyboxSOList = new List<SkyboxLocationSO>();
    [SerializeField]
    private Button skyboxButton;
    [SerializeField]
    private GameObject verticalLayout;
    [SerializeField]
    private SlidePanel _sp;
    private int matIndex;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI infoText;

    public float rotationSpeed = 4.0f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotation = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                cam.transform.Rotate(Vector3.up, rotation, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StationList");
        }
    }

    private void Awake()
    {
        if (FindAnyObjectByType<staticset>())
        {
            matIndex = staticset.Instance.sky;
            Debug.Log(matIndex);
        }
    }


    private void Start(){
        InitSkybox(matIndex);
        InitSkyboxButton();
        infoText.text = skyboxSOList[matIndex].GetStationInfo();
    }

    private void InitSkybox(int x)
    {
        Debug.Log("Init sky: " + skyboxSOList[x].name);
        RenderSettings.skybox = skyboxSOList[x].GetSkyboxMat(0);
    }

    private void InitSkyboxButton()
    {
        for (int i = 0; i < skyboxSOList[matIndex].GetSkyboxLength(); i++)
        {
            Material currentSky = skyboxSOList[matIndex].GetSkyboxMat(i);
            Button newSkyBoxButton = Instantiate(skyboxButton, verticalLayout.transform);
            newSkyBoxButton.onClick.AddListener(() => ChangeSkybox(currentSky));
            newSkyBoxButton.gameObject.SetActive(true);
        }
    }

    public void ChangeSkybox(Material skyboxMaterial)
    {
        RenderSettings.skybox = skyboxMaterial;
        _sp.ToggleSlider();
    }

    public void OpenStationInformationPanel()
    {
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(true);
        }
    }

}

