using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationImageObject : MonoBehaviour
{
    [SerializeField] private Image picture;

    public void InitImage(Sprite img)
    {
        picture.sprite = img;
    }
}
