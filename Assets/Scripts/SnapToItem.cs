using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SnapToItem : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup hlg;

    public TextMeshProUGUI nameLabel;
    private Button[] buttonList;

    private bool isSnapped;
    public float snapForce;
    private float snapSpeed;
    [SerializeField] private float snapAdjust;
    [SerializeField] private int startVal;
    // Start is called before the first frame update
    void Start()
    {
        isSnapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        int currentItem = Mathf.RoundToInt((0 - (contentPanel.localPosition.x) / (sampleListItem.rect.width + hlg.spacing)));

        if(currentItem < startVal)
        {
            currentItem = startVal;
        }

        if(scrollRect.velocity.magnitude < 200 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + hlg.spacing)) + snapAdjust, snapSpeed), 
                contentPanel.localPosition.y, 
                contentPanel.localPosition.z);
            nameLabel.text = currentItem.ToString();
            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + hlg.spacing)) + snapAdjust)
            {
                isSnapped = true;
            }
        }
        if (scrollRect.velocity.magnitude > 200)
        {
           nameLabel.text = currentItem.ToString();
            isSnapped = false;
            snapSpeed = 0;
        }
    }

    private void SetButtonSize(int index)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if(i == index)
            {
                buttonList[i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                buttonList[i].gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            
        }
    }
}
