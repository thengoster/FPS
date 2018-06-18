using UnityEngine;
using System.Collections;

public class BackAndForth : MonoBehaviour {
	public float speed = 3.0f;
	public float maxX = 7.0f;
	public float minX = -7.0f;

	private int _direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (_direction * speed * Time.deltaTime, 0, 0);

		bool bounced = false;
		if (transform.position.x > maxX || transform.position.x < minX) {
			_direction = -_direction;
			bounced = true;
		}
		if (bounced) {
			transform.Translate (_direction * speed * Time.deltaTime, 0, 0);
		}
	}
}
