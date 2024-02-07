
using UnityEngine;


public class SwipeRotate : MonoBehaviour
{
    private float rotationSpeed = 0.02f;
    private Vector2 touchPosition;
    private Touch touch;
    private Quaternion rotationY;
    

    void Update()
    {
        // ตรวจสอบการแตะหน้าจอ
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ตรวจสอบว่าเริ่มแตะหน้าจอหรือกำลังทำนิ้วขยับ
            if (touch.phase == TouchPhase.Moved)
            {
               rotationY = Quaternion.Euler( 0f, - touch.deltaPosition.x * rotationSpeed , 0f);
               transform.rotation = rotationY * transform.rotation;
            }
        }
    }
}
