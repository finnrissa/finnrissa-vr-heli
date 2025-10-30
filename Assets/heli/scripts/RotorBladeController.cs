using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotorBladeController : MonoBehaviour
{
    public enum Axis // enumeration declares each blade axis
    {
        z // fire emoji
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
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotateDegrees);
	}
}
