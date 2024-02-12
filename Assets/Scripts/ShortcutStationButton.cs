using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShortcutStationButton : MonoBehaviour
{
    [SerializeField] private Image picture;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private GameObject flagHLG;
    [SerializeField] private Sprite[] flagSprites;
    [SerializeField] private Image flagTemplate;
    private Sprite currentFlagTmp;
    private string locationName;
    public string GetLocationName => locationName;

    public void Init(string name, Sprite pic, StationSO.Flag[] flags)
    {
        stationName.text = name;
        locationName = name;
        picture.sprite = pic;
        if(flags.Length > 0)
        {
            foreach (StationSO.Flag flag in flags)
            {
                Image newFlag = Instantiate(flagTemplate, flagHLG.transform);
                switch (flag)
                {
                    case StationSO.Flag.Green:
                        newFlag.sprite = flagSprites[0];
                        break;
                    case StationSO.Flag.Orange:
                        newFlag.sprite = flagSprites[1];
                        break;
                    case StationSO.Flag.Yellow:
                        newFlag.sprite = flagSprites[2];
                        break;
                    case StationSO.Flag.Red:
                        newFlag.sprite = flagSprites[3];
                        break;
                }
            }
            flagTemplate.gameObject.SetActive(false);
        }
        
    }
}
