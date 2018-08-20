using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Start_Debug : MonoBehaviour {
	#region Variables
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
	public GameObject plus_y;
	public GameObject minus_y;
	public Button plus_y_button;
	public Button minus_y_button;
	public Button plus_button;
	public Button minus_button;
	private Transform transform;
	public string user_Input;

	public bool textInput = false;
	private bool localInput = false;
	private bool isNumber;

	public float PlusOrSubtract = 1;
	public int i = 1;
	#endregion
	public void FixedUpdate()
	{
		if (textInput)
		{
			user_Input = command_Input.text;
			if (user_Input != "" && command_Input.isFocused && (Input.GetKey(KeyCode.Return) || (Device_Config.device_type == DeviceType.Handheld && Input.GetKey("#"))))
			{
				Debug.Log(user_Input);
				parseInfo();
				command_Input.text = "";
			}
		}

		if (localInput)
		{
			float num;
			string local_input = command_Input.text;
			isNumber = float.TryParse(local_input, out num);
			if (isNumber && (Input.GetKey(KeyCode.Return) || (Device_Config.device_type == DeviceType.Handheld && Input.GetKey("#"))))
			{
				PlusOrSubtract = num;
				command_Input.text = "";
			}
			else if (local_input == "exit" && (Input.GetKey(KeyCode.Return) || Device_Config.device_type == DeviceType.Handheld))
			{
				SetupExit();
				command_Input.text = "";
			}

		}
	}

	public void SetupExit()
	{
		localInput = false;
		textInput = true;
		plus.SetActive(false);
		minus.SetActive(false);
		plus_y.SetActive(false);
		minus_y.SetActive(false);
		plus_button.onClick.RemoveAllListeners();
		minus_button.onClick.RemoveAllListeners();
		minus_y_button.onClick.RemoveAllListeners();
		plus_y_button.onClick.RemoveAllListeners();
	}

	//This is where you add more keywords for the parser to use and call methods
	public void parseInfo()
	{
		switch (user_Input)
		{
			case "save":
				Save();
				break;

			case "shoot position":
				transform = Shoot_Button.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "shoot scale":
				transform = Shoot_Button.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "gun scale":
				transform = gun.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "gun position":
				transform = gun.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "jump scale":
				transform = Jump_Button.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "jump position":
				transform = Jump_Button.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "score position":
				transform = score.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "score scale":
				transform = score.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "score value position":
				transform = score_value.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "score value scale":
				transform = score_value.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "time position":
				transform = Time.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "time scale":
				transform = Time.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "time value position":
				transform = time_value.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "time value scale":
				transform = time_value.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "health pos":
				transform = health.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "health scale":
				transform = health.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "rank pos":
				transform = rank.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "rank scale":
				transform = rank.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "rank value pos":
				transform = rank.transform;
				ControlButton(transform);
				SetupPosition();
				break;

			case "rank value scale":
				transform = rank.transform;
				ControlButton(transform);
				SetupScale();
				break;

			case "res":
				SceneManager.LoadScene(1);
				break;
		}
	}

	//This is repurposing the buttons
	public void SetupScale()
	{
		textInput = false;
		localInput = true;
		command_Input.text = "";
		plus_button.onClick.AddListener(AddScaleX);
		minus_button.onClick.AddListener(SubtractScaleX);
		plus_y_button.onClick.AddListener(AddScaleY);
		minus_y_button.onClick.AddListener(SubtractScaleY);
	}

	//Repurposing the buttons
	public void SetupPosition()
	{
		textInput = false;
		localInput = true;
		command_Input.text = "";
		plus_button.onClick.AddListener(AddX);
		minus_button.onClick.AddListener(SubtractX);
		plus_y_button.onClick.AddListener(AddY);
		minus_y_button.onClick.AddListener(SubtractY);
	}

	//Called to open and close the dialog and stop/reset player movement
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
		plus_y.SetActive(false);
		minus_y.SetActive(false);

		plus_button.onClick.RemoveAllListeners();
		minus_button.onClick.RemoveAllListeners();
		minus_y_button.onClick.RemoveAllListeners();
		plus_y_button.onClick.RemoveAllListeners();
		textInput = false;
	}

	public void ControlButton(Transform transform)
	{
		Debug.Log("" + transform.position.x + "," + transform.position.y);
		plus.SetActive(true);
		minus.SetActive(true);
		plus_y.SetActive(true);
		minus_y.SetActive(true);
	}

	#region Position Functions
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

	public void AddY()
	{
		Vector3 Y = transform.position;
		Y.y = transform.position.y + PlusOrSubtract;
		//Y.x = transform.position.x - PlusOrSubtract;
		transform.position = Y;
		
	}

	public void SubtractY()
	{
		Vector3 Y = transform.position;
		Y.y = transform.position.y - PlusOrSubtract;
		//Y.x = transform.position.x + PlusOrSubtract;
		transform.position = Y;
	}
	#endregion

	#region Scale Functions
	public void AddScaleY()
	{
		Vector3 Y = transform.localScale;
		Y.y = transform.localScale.y + PlusOrSubtract;
		//Y.x = transform.localScale.x - PlusOrSubtract;
		transform.localScale = Y;
	}

	public void SubtractScaleY()
	{
		Vector3 Y = transform.localScale;
		Y.y = transform.localScale.y - PlusOrSubtract;
		//Y.x = transform.localScale.x + PlusOrSubtract;
		transform.localScale = Y;
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
	#endregion

	public void Save()
	{
		string destination = Application.persistentDataPath + "/debug_UI_settings.txt";

		string[] lines = {"Shoot Button Position: " + Shoot_Button.transform.position.x,"," + Shoot_Button.transform.position.y,
						"Shoot Button Scale: " + Shoot_Button.transform.localScale.x, "," + Shoot_Button.transform.localScale.y,
						"Jump Button Position: " + Jump_Button.transform.position.x,"," + Jump_Button.transform.position.y,
						"Jump Button Scale: " + Jump_Button.transform.localScale.x, "," + Jump_Button.transform.localScale.y,
						"Rank Button Position: " + rank.transform.position.x,"," + rank.transform.position.y,
						"Rank Button Scale: " + rank.transform.localScale.x, "," + rank.transform.localScale.y,
						"Rank Value Button Position: " + rank_value.transform.position.x,"," + rank_value.transform.position.y,
						"Rank Value Button Scale: " + rank_value.transform.localScale.x, "," + rank_value.transform.localScale.y,
						"Time Button Position: " + Time.transform.position.x,"," + Time.transform.position.y,
						"Time Button Scale: " + Time.transform.localScale.x, "," + Time.transform.localScale.y,
						"Time Value Button Position: " + time_value.transform.position.x,"," + time_value.transform.position.y,
						"Time Value Button Scale: " + time_value.transform.localScale.x, "," + time_value.transform.localScale.y,
						"Score Button Position: " + score.transform.position.x,"," + score.transform.position.y,
						"Score Button Scale: " + score.transform.localScale.x, "," + score.transform.localScale.y,
						"Score Value Button Position: " + score_value.transform.position.x,"," + score_value.transform.position.y,
						"Score Value Button Scale: " + score_value.transform.localScale.x, "," + score_value.transform.localScale.y,
						"Health Position: " + health.transform.position.x,"," + health.transform.position.y,
						"Health Scale: " + health.transform.localScale.x, "," + health.transform.localScale.y,
						"Gun Button Position: " + gun.transform.position.x,"," + gun.transform.position.y,
						"Gun Button Scale: " + gun.transform.localScale.x, "," + gun.transform.localScale.y,
						"AmmoCount Button Position: " + ammoCount.transform.position.x,"," + ammoCount.transform.position.y,
						"AmmoCount Button Scale: " + ammoCount.transform.localScale.x, "," + ammoCount.transform.localScale.y,};

		System.IO.File.WriteAllLines(destination, lines);
	}

}
