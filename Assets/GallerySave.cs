using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GallerySave : MonoBehaviour {
	public Text[] ShowText;

	public static float fTime;
	public static int userLevel = 0;
	// Use this for initialization


	[Serializable]
	public class PlayerData{
		public int userLevel;
		public float fTime;

	}


	void Start () {
		LoadData ();
		ShowText [0].text = "user : " + userLevel;
		ShowText [1].text = "fTime : " + fTime;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			userLevel++;
			fTime++;
			Debug.Log ("user Level : " + userLevel);
			Debug.Log("fTime : " +fTime);
		}

	}

	public void SaveData(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();

		data.userLevel = userLevel;
		data.fTime = fTime;

		bf.Serialize (file, data);
		file.Close ();
	}


	public void LoadData(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

		if (file != null && file.Length > 0) {
			PlayerData data = (PlayerData)bf.Deserialize (file);

			userLevel = data.userLevel;
			fTime = data.fTime;

		}
		file.Close ();
	}
}
