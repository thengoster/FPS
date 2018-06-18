﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

	public const float baseSpeed = 6.0f;
	public float speed = 6.0f;

	public float gravity = -9.8f;

	private CharacterController _charController;

	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
		PlayerPrefs.GetFloat ("speed", speed);
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime; // m/s * s = meters moved
		movement = transform.TransformDirection (movement); // transform from local to global
		_charController.Move (movement);
	}
}




