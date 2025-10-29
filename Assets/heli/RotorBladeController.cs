using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotorBladeController : MonoBehaviour
{
    public enum Axis // enumeration declares each blade axis
    {
        x,
        y,
        z
    }

    // declarations of independence
    public Axis rotationAxis;
    public float bladeSpeed = 3000;
    public bool inverseRotation = false;
    private Vector3 rotation;
    float rotateDegrees;

    void Start()
    {
        rotation = transform.localEulerAngles;
    }

    void Update()
    {
        if (inverseRotation)
            rotateDegrees -= bladeSpeed * Time.deltaTime;
        else
            rotateDegrees += bladeSpeed * Time.deltaTime;
        rotateDegrees = rotateDegrees % 360;
		switch (rotationAxis) // switch function selects between each blade axis. different cases = different rotation axes.
		{

			case Axis.y:
				transform.localRotation = Quaternion.Euler(rotation.x, rotateDegrees, rotation.z);
				break;
			case Axis.z:
				transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotateDegrees);
				break;
			case Axis.x:
				break;
			default: // just in case none of these cases match in the current moment
				transform.localRotation = Quaternion.Euler(rotateDegrees, rotation.y, rotation.z); // essentially keeps the axis cases in check in the event they do not run
                break;
		}
	}
}
