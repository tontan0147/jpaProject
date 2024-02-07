using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class loadmodel : MonoBehaviour
{
    [SerializeField]
    private List<Station> staionList = new List<Station>();
    private Station modelToLoad;
    [SerializeField]
    private GameObject verticalLayout;
    [SerializeField]
    private Button cameraButton;
    [SerializeField]
    private SlidePanel _sp;
    private int modelIndex;
    private GameObject activeCam;
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI infoText;

    private float rotationSpeed = 2.0f;
    private Vector2 touchPosition;
    private Touch touch;
    private Quaternion rotationY;
    //public float rotationSpeed = 1.0f;

    void Start(){
        if(staionList.Count > 0)
        {
            if (FindAnyObjectByType<staticset>())
            {
                InitStationModel(staticset.Instance.model);
                modelIndex = staticset.Instance.model;
                Debug.Log("Load model: " + modelIndex);
                staionList[modelIndex].SetActiveCamera(0);
                infoText.text = staionList[modelIndex].GetStationInfo();
                activeCam = modelToLoad.GetCamera(0);
            }
            InitCameraButton();
        }
        else
        {
            Debug.Log("There's no Station assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StationList");
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotation = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                activeCam.transform.Rotate(Vector3.up, rotation, Space.World);
            }
        }
    }

    private void InitCameraButton()
    {
        for (int i = 0; i < modelToLoad.GetAllCamera().Length; i++)
        {
            int currentCameraIndex = i;
            Button newSkyBoxButton = Instantiate(cameraButton, verticalLayout.transform);

            newSkyBoxButton.onClick.AddListener(() => ChangeCamera(currentCameraIndex));

            newSkyBoxButton.gameObject.SetActive(true);
        }
    }

    public void ChangeCamera(int camIndex)
    {
        modelToLoad.SetActiveCamera(camIndex);
        activeCam = modelToLoad.GetCamera(camIndex);
        _sp.ToggleSlider();
    }

    private void InitStationModel(int x){
        modelToLoad = Instantiate(staionList[x],
            staionList[x].transform.position,
            staionList[x].transform.rotation);
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
