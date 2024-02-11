using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class StationSearch : MonoBehaviour{
    [SerializeField]
    private List<GameObject> buttonList = new List<GameObject>();

    [SerializeField]
    private TMP_InputField searchInputField; // Reference to the TMP InputField in the Inspector
    private string partialNameToSearch;

    [SerializeField]
    private GameObject noSearchResultText;

    private void Awake()
    {
        noSearchResultText.SetActive(false);
        searchInputField.onEndEdit.AddListener(HandleInputEnd);
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
        foreach (GameObject obj in buttonList)
        {
            bool shouldSetActive = obj.name.Contains(partialName);
            obj.SetActive(shouldSetActive);
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
