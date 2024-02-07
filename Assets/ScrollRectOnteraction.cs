using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectOnteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isTouchingImage;
    public GameObject _swipeRotate;
    public ScrollRect scrollRect;

    void Start(){
        /*SwipeRotate sr = _swipeRotat.GetComponent<SwipeRotate>();
        if(sr == null){
            Debug.Log("ลืมใส่ SwipeRote ใน Inspector");
        }*/
    }

    void Update(){
        CheckTop();
    }
    
    void CheckTop(){
        if(_swipeRotate == null)
        {
            return;
        }
        SwipeRotate sr = _swipeRotate.GetComponent<SwipeRotate>();

        if (scrollRect.verticalNormalizedPosition >= 1f)
        {
            if(sr != null){
                sr.enabled = true;
            }
        }else{
            if(sr != null){
                sr.enabled = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        //CheckIfTouchingImage(eventData.position, true);
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //CheckIfTouchingImage(eventData.position, false);
    }

    private void CheckIfTouchingImage(Vector2 screenPosition, bool isDown)
    {
        // Convert screen position to world position using a raycast
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the collider belongs to the image
            if (hit.collider.CompareTag("YourImageTag"))
            {
                isTouchingImage = isDown;

                // Do something based on whether the player is touching the image
                if (isTouchingImage)
                {
                    Debug.Log("Player is touching the image.");
                    // Add your logic here
                }
                else
                {
                    Debug.Log("Player stopped touching the image.");
                    // Add your logic here
                }
            }
        }
    }
}
