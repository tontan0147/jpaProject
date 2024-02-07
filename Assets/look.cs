using UnityEngine;

public class TouchInput : MonoBehaviour
{
    // เมื่อเริ่มทำงาน
    public float rotationSpeed = 0.1f;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is moving
            if (touch.phase == TouchPhase.Moved)
            {
                // Get the touch delta position
                Vector2 deltaPosition = touch.deltaPosition;

                // Rotate the skybox based on touch delta position
                RotateSkybox(deltaPosition);
            }
        }
    }

    void RotateSkybox(Vector2 deltaPosition)
    {
        // Calculate the rotation angles based on touch delta position
        float rotationX = -deltaPosition.y * rotationSpeed;
        float rotationY = deltaPosition.x * rotationSpeed;

        // Apply rotation to the skybox
        RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") + rotationY);
    }

}


