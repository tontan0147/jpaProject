using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneder : MonoBehaviour
{
    public GameObject loadingSceneImg;
    public void LoadSceneskybox(int x){
        staticset.Instance.sky = x;
        StartCoroutine(delaySkybox());
    }
    public void LoadSceneStationList(){
        SceneManager.LoadScene("StationList");
    }
    public void LoadFavScene()
    {
        SceneManager.LoadScene("Favourite");
    }
    public void LoadSceneStationOverview(StationSO station)
    {
        staticset.Instance.currentStation = station;
        SceneManager.LoadScene("StationInfo");
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("First");
    }
    public void LoadSceneByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator delaySkybox()
    {
        if (loadingSceneImg != null)
        {
            loadingSceneImg.SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Scene360");
    }

}
