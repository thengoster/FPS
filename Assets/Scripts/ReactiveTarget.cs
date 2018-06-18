using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	private bool _alive;

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI> ();
		if (behavior != null) {
			behavior.SetAlive (false);
			_alive = false;
		}
		StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		this.transform.Rotate (75, 0, 0);

		yield return new WaitForSeconds (1.5f);

		Destroy (this.gameObject);
	}


	// Use this for initialization
	void Start () {
		_alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsAlive {
		get { return _alive; }
	}
}

