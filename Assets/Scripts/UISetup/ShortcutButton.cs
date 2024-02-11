using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShortcutButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image mainPicture;
    void Start()
    {
        
    }

    public void Init(string name, Sprite pic)
    {
        nameText.text = name;
        mainPicture.sprite = pic;
    }
}
