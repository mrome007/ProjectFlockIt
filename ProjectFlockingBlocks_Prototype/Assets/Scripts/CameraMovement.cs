using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    public float CameraSpeed;
    public Transform TargetTransform;
    private Vector3 Target;
    private Vector3 vel;
	// Use this for initialization
	void Start () 
    {
        Target = new Vector3();
        Target = TargetTransform.position;
        Target.y = transform.position.y;
        Target.x = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Target = TargetTransform.position;
        Target.y = transform.position.y;
        Target.x = transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, Target, ref vel, 0.75f);

	}
}
