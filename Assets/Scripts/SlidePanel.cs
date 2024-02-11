using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    [SerializeField]
    private Button buttonUI;
    [SerializeField]
    private Sprite upButtonImage;
    [SerializeField]
    private Sprite downButtonImage;

    [SerializeField]
    private Animator slidePanelAnim;
    private bool isSlideUp;

    private void Start()
    {
        isSlideUp = false;
    }
    public void ToggleSlider()
    {
        slidePanelAnim.SetBool("IsStart", true);
        if (isSlideUp)
        {
            SlideDown();
        }
        else
        {
            SlideUp();
        }
        isSlideUp = !isSlideUp;
    }

    public void SlideUp()
    {
        slidePanelAnim.SetBool("IsSlideUp", true);
        buttonUI.GetComponent<Image>().sprite = downButtonImage;
    }

    public void SlideDown()
    {
        slidePanelAnim.SetBool("IsSlideUp", false);
        buttonUI.GetComponent<Image>().sprite = upButtonImage;
    }
}
