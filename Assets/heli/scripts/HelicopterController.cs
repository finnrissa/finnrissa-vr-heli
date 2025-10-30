using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float responsiveness = 500f;
	[SerializeField] private float yawResponsiveness = 250f;
	[SerializeField] private float rollResponsiveness = 150f;
	[SerializeField] private float pitchResponsiveness = 250f;
	[SerializeField] private float throttleResponsiveness = 50f;
	[SerializeField] private float throttleAmount = 25f;
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

	private void FixedUpdate()
	{
        _rigidbody.AddForce(transform.up * throttle, ForceMode.Impulse);
		_rigidbody.AddTorque(transform.right * pitch * pitchResponsiveness);
		_rigidbody.AddTorque(transform.forward * roll * rollResponsiveness);
		_rigidbody.AddTorque(transform.up * yaw * yawResponsiveness);
	}
	private void InputCtrl()
    {
		roll = Input.GetAxis("Roll");
		pitch = Input.GetAxis("Pitch");
		yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle += Time.deltaTime * throttleAmount;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= Time.deltaTime * throttleAmount;
        }

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
}