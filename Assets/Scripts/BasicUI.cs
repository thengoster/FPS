using UnityEngine;
using System.Collections;

public class BasicUI : MonoBehaviour {
	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 40, 20), "Test")) {
			Debug.Log ("Test button");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
