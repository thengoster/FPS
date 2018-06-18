using UnityEngine;
using UnityEngine.UI; // working with the UI components inside the overarching eventsystems (canvas)
using System.Collections;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private SettingsPopup settingsPopup;

	private int _score;

	void Awake() {
		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	// Use this for initialization
	void Start () {
		_score = 0;
		scoreLabel.text = _score.ToString ();
		settingsPopup.Close ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnOpenSettings() {
		settingsPopup.Open ();
	}

	public void OnPointerDown() {
		Debug.Log ("pointer down");
	}

	private void OnEnemyHit() {
		_score += 1;
		scoreLabel.text = _score.ToString ();
	}
}
