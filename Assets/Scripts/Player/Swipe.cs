using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	public int deadzone = 125;
	public bool swipeLeft, swipeRight, swipeUp, swipeDown;
	public bool isDragging = false;
	public Vector2 startTouch, swipeDelta;

	private float hold = 0;
	private float release = 0.02f;

	private void Start()
	{
		
	}

	private void Update()
	{
		swipeLeft = swipeRight = swipeUp = swipeDown = false;

		#region Standalone Inputs

		if (Input.GetMouseButtonDown(0))
		{
			isDragging = true;
			startTouch = Input.mousePosition;
		}

		else if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			Reset();
		}

		#endregion

		#region Mobile Input

		if(Input.touches.Length != 0)
		{
			if(Input.touches[0].phase == TouchPhase.Began)
			{
				isDragging = true;
				startTouch = Input.touches[0].position;
			}
			else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				isDragging = false;
				Reset();
			}
		}

		#endregion

		//Calculate distance
		swipeDelta = Vector2.zero;
		if(isDragging)
		{
			if(Input.touches.Length > 0)
			{
				swipeDelta = Input.touches[0].position - startTouch;
			}
			else if (Input.GetMouseButton(0))
			{
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		//Cross the deadzone?
		if (swipeDelta.magnitude > deadzone)
		{
			//direction
			float x = swipeDelta.x;
			float y = swipeDelta.y;

			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Left or right
				if (x < 0)
					swipeLeft = true;

				else
					swipeRight = true;

			}

			else
			{
				//Up or Down
				if (y < 0)
					swipeDown = true;
				else
					swipeUp = true;

			}


			Reset();
		}


	}

	private void Reset()
	{
		startTouch = Vector2.zero;
		swipeDelta = Vector2.zero;
		isDragging = false;
	}

}
