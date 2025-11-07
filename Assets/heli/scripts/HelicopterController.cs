using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using BNG;
//hi
public class HelicopterController : MonoBehaviour
{
	public Rigidbody helicopter;
	[SerializeField] private float throttleSensitivity;
	[SerializeField] private float yawRate;
	[SerializeField] private float rollRate;
	[SerializeField] private float pitchRate;
	[SerializeField] private float stickThrottleRate;
	[SerializeField] float maxSpeed;

	private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

	private float throttle2;
	private float roll2;
	private float pitch2;
	private float yaw2l;
	private float yaw2r;

	private void Awake()
	{
		helicopter = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		InputCtrl();

		//if (InputBridge.Instance.RightThumbstickAxis.x > 0)
		//{
			//Debug.Log("Stick POSITIVE X.");
			//if (InputBridge.Instance.RightThumbstickAxis.x == 0)
			//{
				//Debug.Log("Stick X UNACTUATED");
			//}
		//}
		//else Debug.Log("Stick NEGATIVE X");

		//if (InputBridge.Instance.RightThumbstickAxis.y > 0)
		//{
			//Debug.Log("Stick POSITIVE Y");
			//if (InputBridge.Instance.RightThumbstickAxis.y == 0)
			//{
				//Debug.Log("Stick Y UNACTUATED");
			//}
		//}
		//else Debug.Log("Stick NEGATIVE Y.");
	}

	private void FixedUpdate() // forces acting on the helicopter. Force mode impulse since it is weight dependent. The rigidbody weighs 360kg.
	{
		helicopter.AddForce(transform.up * throttle, ForceMode.Impulse);
		helicopter.AddTorque(transform.right * pitch * pitchRate, ForceMode.Acceleration);
		helicopter.AddTorque(transform.forward * roll * rollRate, ForceMode.Acceleration);
		helicopter.AddTorque(transform.up * yaw * yawRate, ForceMode.Acceleration);
		helicopter.AddForce(transform.up * throttle2 * stickThrottleRate, ForceMode.Impulse);
		helicopter.AddTorque(transform.right * pitch2 * pitchRate, ForceMode.Acceleration);
		helicopter.AddTorque(transform.forward * roll2 * rollRate, ForceMode.Acceleration);
		helicopter.AddTorque(transform.up * yaw2l * yawRate, ForceMode.Acceleration);
		helicopter.AddTorque(transform.up * yaw2r * yawRate, ForceMode.Acceleration);
	}
	//no limits placed on the airframe yet
	private void InputCtrl() // relative control axes from input manager
    {
		roll = Input.GetAxis("Roll");
		pitch = Input.GetAxis("Pitch");
		yaw = Input.GetAxis("Yaw");

		throttle2 = InputBridge.Instance.LeftThumbstickAxis.y;
		roll2 = -InputBridge.Instance.RightThumbstickAxis.x;
		pitch2 = InputBridge.Instance.RightThumbstickAxis.y;
		yaw2r = InputBridge.Instance.RightTrigger;
		yaw2l = -InputBridge.Instance.LeftTrigger;


		if (Input.GetKey(KeyCode.R))
		{
			helicopter.position = new Vector3(152, 3, 48);
			helicopter.rotation = Quaternion.identity;
			throttle = 0f;
			throttle2 = 0f;
		}

		if (InputBridge.Instance.BButtonDown)
		{
			helicopter.position = new Vector3(152, 3, 48);
			helicopter.rotation = Quaternion.identity;
			throttle = 0f;
			throttle2 = 0f;
		}

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
		Debug.Log(throttle2);

		throttle = Mathf.Clamp(throttle, 0f, 100f);
		throttle2 = Mathf.Clamp(throttle2, 0f, 100f);
	}
}