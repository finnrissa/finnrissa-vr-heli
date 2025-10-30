using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		InputCtrl();
	}

	private void FixedUpdate() // forces acting on the helicopter. Given it is rigidbody I'm using ForceMode. Impulse since it is weight dependent.
	{
		_rigidbody.AddForce(transform.up * throttle, ForceMode.Impulse);
		_rigidbody.AddTorque(transform.right * pitch * pitchRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.forward * roll * rollRate, ForceMode.Acceleration);
		_rigidbody.AddTorque(transform.up * yaw * yawRate, ForceMode.Acceleration);
	}
	// conversely, acceleration isn't. I don't fully understand these, though I think they are working fine, I just have no limits placed on the airframe yet.
	private void InputCtrl() // relative control axes from input manager
    {
		roll = Input.GetAxis("Roll");
		pitch = Input.GetAxis("Pitch");
		yaw = Input.GetAxis("Yaw");

		// Throttle axis percentage and 0% clamp
		if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle += throttleSensitivity;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
			throttle -= throttleSensitivity;
        }
		Debug.Log(roll);
		Debug.Log(pitch);
		Debug.Log(yaw);
		Debug.Log(throttle);

		throttle = Mathf.Clamp(throttle, 0f, 100f);
	}
}