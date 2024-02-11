using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Information : MonoBehaviour
{
    [SerializeField]
    private Image informationImage;

    [SerializeField]
    private Sprite map;

    [SerializeField]
    private Sprite stationImage;

    [SerializeField]
    private Sprite schedule;

	[SerializeField]
	private Camera mainCamera;

	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

	Vector2 firstTouchPrevPos, secondTouchPrevPos;

	[SerializeField]
	float zoomModifierSpeed = 0.1f;

	[SerializeField]
	private GameObject scrollView;

	void Start()
	{
		mainCamera = GetComponent<Camera>();
		InformationChange(staticset.Instance.information);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("First");
		}
		if (Input.touchCount == 2)
		{
			Touch firstTouch = Input.GetTouch(0);
			Touch secondTouch = Input.GetTouch(1);

			firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

			zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

			if (touchesPrevPosDifference > touchesCurPosDifference)
				//Debug.Log("Zoom" + zoomModifier);
				mainCamera.orthographicSize += zoomModifier;
			if (touchesPrevPosDifference < touchesCurPosDifference)
				//Debug.Log("Zoom" + zoomModifier);
				mainCamera.orthographicSize -= zoomModifier;

		}
		//testText.text = zoomModifier.ToString();
		mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 10f, 40f);
		if(mainCamera.orthographicSize < 0)
        {
			mainCamera.orthographicSize = 0;

		}
		if(mainCamera.orthographicSize > 40)
        {
			mainCamera.orthographicSize = 40;

		}
	}

    private void InformationChange(int informationIndex)
    {
        switch (informationIndex)
        {
            case 0:
                informationImage.sprite = map;
                break;
            case 1:
                informationImage.sprite = null;
				scrollView.SetActive(true);
				break;
            case 2:
                informationImage.sprite = schedule;
                break;
        }
    }
}
