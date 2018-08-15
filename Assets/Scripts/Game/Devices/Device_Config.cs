using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device_Config : MonoBehaviour {

	public static string device_model;
	public static DeviceType device_type;
	
	void Start () {
		device_model = SystemInfo.deviceModel;
		device_type = SystemInfo.deviceType;
	}
	
}
