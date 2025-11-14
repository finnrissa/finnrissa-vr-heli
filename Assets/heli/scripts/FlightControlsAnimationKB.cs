using UnityEngine;
using BNG;

public class FlightControlsAnimationKB : MonoBehaviour
{
	public float maxPitchAngle = 20f;       // Forward/back tilt
	public float maxRollAngle = 20f;        // Left/right tilt
	public float returnSpeed = 5f;          // How quickly stick returns to center
	public float inputResponseSpeed = 10f;  // How quickly stick follows input

	private Quaternion _neutralRotation;
	private Quaternion _targetRotation;

	void Start()
	{
		_neutralRotation = transform.localRotation;
		_targetRotation = _neutralRotation;
	}

	void Update()
	{
		float rollInput2 = Input.GetAxis("Roll");
		float pitchInput2 = Input.GetAxis("Pitch");
		float yaw2 = Input.GetAxis("Yaw");

		// Rotate around the local X axis — this is your working pitch
		Quaternion pitchRotation = Quaternion.AngleAxis(-pitchInput2 * maxPitchAngle, Vector3.right);


		// Rotate around the stick’s local forward axis (instead of world Z)
		Quaternion rollRotation = Quaternion.AngleAxis(rollInput2 * maxRollAngle, transform.forward);

		// Combine both rotations relative to the neutral rotation
		Quaternion desiredRotation = _neutralRotation * pitchRotation * rollRotation;

		_targetRotation = Quaternion.Slerp(_targetRotation, desiredRotation, Time.deltaTime * inputResponseSpeed);

		if (Mathf.Approximately(pitchInput2, 0f) && Mathf.Approximately(rollInput2, 0f))
		{
			_targetRotation = Quaternion.Slerp(_targetRotation, _neutralRotation, Time.deltaTime * returnSpeed);
		}

		transform.localRotation = _targetRotation;
	}
}
