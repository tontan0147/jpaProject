using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShortcutPanelSetup : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button scheduleButton;
    [SerializeField] private Button mapButton;
    [SerializeField] private Button favButton;

    private void Start()
    {
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("First"));
        scheduleButton.onClick.AddListener(() => SceneManager.LoadScene("Schedule"));
        mapButton.onClick.AddListener(() => SceneManager.LoadScene("Information"));
        favButton.onClick.AddListener(() => SceneManager.LoadScene("Favourite"));
    }
}
