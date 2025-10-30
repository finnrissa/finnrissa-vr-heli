using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController2 : MonoBehaviour
{
	private Rigidbody _rigidbody;
	
	[SerializeField] private float _responsiveness = 500f;
	[SerializeField] private float _yawresponsiveness = 250f;
	[SerializeField] private float _rollresponsiveness = 150f;
	[SerializeField] private float _pitchresponsiveness = 250f;
	[SerializeField] private float _throttleresponsiveness = 50f;
	[SerializeField] private float _throttleAmount = 25f;
	private float _throttle;

	private float _roll;
	private float _pitch;
	private float _yaw;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		HandleInputs();
	}
	private void FixedUpdate()
	{
		_rigidbody.AddForce(transform.up * _throttle, ForceMode.Impulse);
		_rigidbody.AddTorque(transform.right * _pitch * _responsiveness);
		_rigidbody.AddTorque(transform.forward * _roll * _responsiveness);
		_rigidbody.AddTorque(transform.up * _yaw * _yawresponsiveness);
	}
	private void HandleInputs()
	{
		_roll = Input.GetAxis("Roll");
		_pitch = Input.GetAxis("Pitch");
		_yaw = Input.GetAxis("Yaw");

		if (Input.GetKey(KeyCode.LeftShift))
		{
			_throttle += _throttleresponsiveness * _throttleAmount;
		}
		else if (Input.GetKey(KeyCode.LeftControl))
		{
			_throttle -= _throttleresponsiveness * _throttleAmount;
		}

		_throttle = Mathf.Clamp(_throttle, 0f, 100f);
	}
}