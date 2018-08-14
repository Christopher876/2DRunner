using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Start_Debug : MonoBehaviour {

	public GameObject player;
	public Button Shoot_Button;
	public Button Jump_Button;

	public Text rank;
	public Text rank_value;
	public Text Time;
	public Text time_value;
	public Text score;
	public Text score_value;
	public Image health;
	public Image gun;
	public Text ammoCount;

	public GameObject command_input_activation;
	public InputField command_Input;
	public GameObject plus;
	public GameObject minus;
	public Button plus_button;
	public Button minus_button;
	private Transform transform;
	public string user_Input;

	public bool textInput = false;
	private bool localInput = false;

	public float PlusOrSubtract = 1;

	public void Update()
	{
		if (textInput)
		{
			user_Input = command_Input.text;
			if (user_Input != "" && command_Input.isFocused && Input.GetKey(KeyCode.Return))
			{
				Debug.Log(user_Input);
				parseInfo();
			}
		}

		if (localInput)
		{
			string local_input = command_Input.text;
			if (local_input != "" && command_Input.isFocused && Input.GetKey(KeyCode.Return))
			{
				local_input = local_input + "f";
				PlusOrSubtract = float.Parse(command_Input.text);
			}

		}
	}

	public void parseInfo()
	{
		switch (user_Input)
		{
			case "shoot position":
				textInput = false;
				localInput = true;
				command_Input.text = "";
				transform = GameObject.Find("Shoot_Button").transform;
				ControlButton(transform);
				break;

			case "shoot scale":
				textInput = false;
				localInput = true;
				command_Input.text = "";
				transform = GameObject.Find("Shoot_Button").transform;
				ControlButton(transform);
				plus_button.onClick.AddListener(AddScaleX);
				minus_button.onClick.AddListener(SubtractScaleX);
				break;
		}
	}

	public void ControlMovement (){

		if (!textInput)
		{
			player.GetComponent<player_movement>().enabled = false;
			OpenInputField();
			textInput = true;
		}

		else
		{
			player.GetComponent<player_movement>().enabled = true;
			CloseInputField();
			textInput = false;
		}
	}

	public void OpenInputField()
	{
		command_input_activation.SetActive(true);
	}

	public void CloseInputField()
	{
		command_input_activation.SetActive(false);
		plus.SetActive(false);
		minus.SetActive(false);
	}

	public void ControlButton(Transform transform)
	{
		Debug.Log("" + transform.position.x + "," + transform.position.y);
		plus.SetActive(true);
		minus.SetActive(true);
	}

	public void AddX()
	{
		Vector3 X = transform.position;
		X.x = transform.position.x + PlusOrSubtract;
		transform.position = X;
	}


	public void SubtractX()
	{
		Vector3 X = transform.position;
		X.x = transform.position.x - PlusOrSubtract;
		transform.position = X;
	}

	public void AddScaleX()
	{
		Vector3 X = transform.localScale;
		X.x = transform.localScale.x + PlusOrSubtract;
		transform.localScale = X;
	}

	public void SubtractScaleX()
	{
		Vector3 X = transform.localScale;
		X.x = transform.localScale.x - PlusOrSubtract;
		transform.localScale = X;
	}



}
