using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; // interacting with UI system code framework

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();

		// Cursor.lockState = CursorLockMode.Locked; // locks cursor the center of screen, automatically makes cursor invisible
		// Cursor.visible = false; // make cursor invisible in code for clarity
	}

	void OnGUI() { // MonoBehaviour similarly responds to OnGUI like Start() and Update()
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label (new Rect (posX, posY, size, size), "*");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) &&
			!EventSystem.current.IsPointerOverGameObject()) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> (); // in essence, we have a reference to the reactive target hit
				if (target != null && target.IsAlive) {
					target.ReactToHit(); // use that referenced target's method
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds (1);

		Destroy (sphere);
	}
}
