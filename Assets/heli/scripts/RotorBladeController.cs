using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotorBladeController : MonoBehaviour
{
    // declarations of independence
	public Axis rotationAxis;
    public float bladeSpeed;
	public bool inverseRotation = false;
	public Vector3 rotation;
    float rotateDegrees;
    // nothingburger enum
	public enum Axis // enumeration declares each blade axis
    {
        z // fire emoji
    }

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
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotateDegrees);
        // rotatedegrees only tracked in this file, doesn't allow for other files to affect blade rotation
        // if i were you i would make rotatedegrees based off of transform.localEulerAngles.z += bladeSpeed * deltaTime each frame
        // that way if another script wants to touch the transform z rotation this script will be able to see those changes and not make the model tweak 
	}
}
