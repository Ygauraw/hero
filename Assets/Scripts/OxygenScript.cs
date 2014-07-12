using UnityEngine;
using System.Collections;

public class OxygenScript : MonoBehaviour {

	public float o2Time = 60f;
	public bool hasTime = true;
	private float startTime;
	private float restSeconds;
	private int roundedRestSeconds;
	private int displaySeconds;
	private int displayMinutes;
	private int countDownSeconds;

	void Awake() {
		startTime = Time.time + o2Time;
	}

	void OnGUI () {
		//make sure that your time is based on when this script was first called
		//instead of when your game started
		var guiTime = Time.time - startTime;

		if (hasTime) {
			restSeconds = countDownSeconds - (guiTime);
		}

		//display messages or whatever here -->do stuff based on your timer
		if (restSeconds == 60) {
			print ("One Minute Left");
		}
		if (restSeconds <= 0) {
			print ("Time is Over");
			hasTime = false;
		}

		//display the timer
		roundedRestSeconds = Mathf.CeilToInt(restSeconds);
		displaySeconds = roundedRestSeconds % 60;
		displayMinutes = roundedRestSeconds / 60;

		string text = string.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds);
		GUI.Label (new Rect (10, 150, 100, 20), "Oxygen: "+text);
	}
}
