using UnityEngine;
using BNG;

public class FlightControlsAnimation : MonoBehaviour
{
    public float maxAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleRotation = InputBridge.Instance.RightThumbstickAxis.y;
        //deploying the cherrystar units
    }
}
