using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderCtrl : MonoBehaviour
{
	[SerializeField] Rigidbody rb;
	public float speed;
	public AnimationCurve curve;
	public float curveSpeed = 1;
	// Start is called before the first frame update
	void Start()
	{

	}

	private void FixedUpdate()
	{
		Quaternion deltaRotation = Quaternion.Euler(0, speed * curve.Evaluate((Time.time* curveSpeed) - (int)(Time.time* curveSpeed)) * Time.fixedDeltaTime, 0);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}
}
