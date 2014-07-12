using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	Transform trans;
	float maxBoundsX = 12.5f;
	float minBoundsX = 2.5f;
	float maxBoundsY = -22f;
	float minBoundsY = -2.75f;
	float myX;
	float myY;

	// Update is called once per frame
	void Update ()
	{
		if (target)
		{
			if (target.position.x > maxBoundsX) {
				myX = maxBoundsX;
			} else if(target.position.x < minBoundsX) {
				myX = minBoundsX;
			}else {
				myX = target.position.x;
			}
			if(target.position.y < maxBoundsY) {
				myY = maxBoundsY;
			}else if(target.position.y > minBoundsY) {
				myY = minBoundsY;
			}else {
				myY = target.position.y;
			}


			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			//destination.x = myX;
			//Debug.Log ("target.position.x: "+target.position.x+" | maxBoundsX: "+maxBoundsX+" | myX: "+myX);
			destination.x = myX;
			destination.y = myY;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);



		}

	}
	void LateUpdate() {
		/*var v3 = transform.position;
		Debug.Log (v3.x+","+v3.y);
		v3.x = Mathf.Clamp(v3.x, minX, maxX);
		v3.y = Mathf.Clamp(v3.y, minY, maxY);
		transform.position = v3;*/
	}
}