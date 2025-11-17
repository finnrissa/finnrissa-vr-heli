using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHelicopter : MonoBehaviour
{
	public float x;
	public float y;
	public float z;
	public Rigidbody helicopter;
	private float throttle;
	private float roll;
	private float pitch;
	private float yaw;

	private float throttle2;
	private float roll2;
	private float pitch2;
	private float yaw2l;
	private float yaw2r;

	public void onResetButton()
	{
		helicopter.position = new Vector3(2419, 3, 2758);
		helicopter.rotation = Quaternion.Euler(x, y, z);
		throttle = 0f;
		throttle2 = 0f;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	}
}
