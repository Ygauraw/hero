using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour {

	public float airSpeed = 10.0f;
	public float gas = 0.0f;
	public float gasStorageRate = 2.0f;
	public float gasUseRate = 4.0f;
	public float maxGas = 1000.0f;
	public bool startOnFull = false;
	public bool isRechargable = true;
	public bool isEmpty = true;

	// Use this for initialization
	void Awake () {
		// start with full tank
		if (startOnFull) {
			gas = maxGas;
			isEmpty = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		PlayerScript controller = GetComponent<PlayerScript>();
		if (!controller.isFlying) {
			// recharge jetpack when on ground if rechargable
			if (isRechargable && gas < maxGas)
				gas += gasStorageRate;
			// don't overfill!
			if (gas > maxGas)
				gas = maxGas;
		} else{
			// use the all the gas!
			gas -= gasUseRate;
			if (gas < 0.0f) {
				gas = 0.0f;
				isEmpty = true;
			}
		}
	}
	void OnGUI () {
		GUI.Label(new Rect(10, 110, 100, 20), gas + " / " + maxGas);
	}
}
