using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TestCameraMovement))]
public class CameraMovement : MonoBehaviour 
{
    public Transform PlayerTarget;
    public float SmoothTime;
    private Vector3 theTarget;
    private Vector3 refVelocity;
	// Use this for initialization
	void Start () 
    {
        theTarget = PlayerTarget.position;
        refVelocity = new Vector3();
	}
	
	// Update is called once per frame
	void Update () 
    {
        FollowPlayer();
	}

    void FollowPlayer()
    {
        theTarget = PlayerTarget.position;
        theTarget.y = 20f;
        transform.position = Vector3.SmoothDamp(transform.position, theTarget, ref refVelocity, SmoothTime);
    }
}
