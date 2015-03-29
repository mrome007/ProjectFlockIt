using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Transform PlayerTarget;

    private float dampTime = 0.75f;
    private Vector3 followVelocity;
    private bool follow;
    private Vector3 targetThePlayer;

	// Use this for initialization
	void Start () 
    {
        followVelocity = Vector3.zero;
        targetThePlayer = PlayerTarget.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(!follow)
        {
            return;
        }
        targetThePlayer = PlayerTarget.position;
        targetThePlayer.y = transform.position.y;
        targetThePlayer.x = transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, targetThePlayer, ref followVelocity, dampTime);
	}

    public void StartFollow()
    {
        follow = true;
    }
}
