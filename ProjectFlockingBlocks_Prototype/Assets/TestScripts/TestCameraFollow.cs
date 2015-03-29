using UnityEngine;
using System.Collections;

public class TestCameraFollow : MonoBehaviour 
{
    public Transform PlayerTrans;
    private bool? isFollowing;
    private const string notFollowingMessage = "Camera is not following Player";

    void Awake()
    {
        CameraFollow camf = gameObject.GetComponent<CameraFollow>();
        camf.StartFollow();
    }
	
    void FixedUpdate()
    {
        Renderer r = PlayerTrans.GetChild(0).GetComponent<Renderer>();
        if(!isFollowing.HasValue && r.isVisible)
        {
            isFollowing = true;
        }
        if (isFollowing.HasValue)
        {
            TestIt.Assert(r.isVisible, notFollowingMessage);
        }
    }
}
