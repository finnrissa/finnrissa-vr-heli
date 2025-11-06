using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using BNG;
//hi
public class HelicopterController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] private float throttleSensitivity;
	[SerializeField] private float yawRate;
	[SerializeField] private float rollRate;
	[SerializeField] private float pitchRate;

	private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

	public float throttle2;
	public float roll2;
	public float pitch2;
	public float yaw2;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		InputCtrl();

		if (InputBridge.Instance.RightThumbstickAxis.x > 0)
		{
			Debug.Log("Stick POSITIVE X.");
			if (InputBridge.Instance.RightThumbstickAxis.x == 0)
			{
				Debug.Log("Stick X UNACTUATED");
			}
		}
		else Debug.Log("Stick NEGATIVE X");

		if (InputBridge.Instance.RightThumbstickAxis.y > 0)
		{
			Debug.Log("Stick POSITIVE Y");
			if (InputBridge.Instance.RightThumbstickAxis.y == 0)
			{
				Debug.Log("Stick Y UNACTUATED");
			}
		}
		else Debug.Log("Stick NEGATIVE Y.");
	}

	private void FixedUpdate() // forces acting on the helicopter. Force mode impulse since it is weight dependent. The rigidbody weighs 360kg.
	{
		_rigidbody.AddForce(transform.up * throttle, ForceMode.Impulse);
		_rigidbody.AddTorque(transform.right * pitch * pitchRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.forward * roll * rollRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.up * yaw * yawRate, ForceMode.Acceleration);
		_rigidbody.AddForce(transform.up * throttle2, ForceMode.Impulse);
		_rigidbody.AddTorque(transform.right * pitch2 * pitchRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.forward * roll2 * rollRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.up * yaw2 * yawRate, ForceMode.Acceleration);
	}
	//no limits placed on the airframe yet
	private void InputCtrl() // relative control axes from input manager
    {
		roll = Input.GetAxis("Roll");
		pitch = Input.GetAxis("Pitch");
		yaw = Input.GetAxis("Yaw");

		roll2 = -InputBridge.Instance.RightThumbstickAxis.x;
		pitch2 = InputBridge.Instance.RightThumbstickAxis.y;
		throttle2 = InputBridge.Instance.RightTrigger;

		// Throttle axis percentage and 0% clamp
		if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle += throttleSensitivity;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
			throttle -= throttleSensitivity;
        }
		//Debug.Log(roll);
		//Debug.Log(pitch);
		//Debug.Log(yaw);
		//Debug.Log(throttle);

		throttle = Mathf.Clamp(throttle, 0f, 100f);

		if (InputBridge.Instance.RightTriggerDown)
		{
			throttle2 += throttleSensitivity*10;
		}
		else if (InputBridge.Instance.RightGripDown)
		{
			throttle2 -= throttleSensitivity*10;
		}

		throttle2 = Mathf.Clamp(throttle2, 0f, 100f);
	}
}