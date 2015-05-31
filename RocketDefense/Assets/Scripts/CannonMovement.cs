using UnityEngine;
using System.Collections;

public class CannonMovement : MonoBehaviour 
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float RotationSpeed;

    private const float angleThreshold = 20f;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput < 0)
        {
            var dirRot = transform.position - RightTarget.position;
            var tarRot = Quaternion.LookRotation(dirRot);

            //Debug.Log(Vector3.Dot(dirRot, transform.forward));
            //if(Vector3.Dot(dirRot, transform.forward) < 15.0f)
            //{
              //  transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, RotationSpeed / 10f * Time.deltaTime);
            //}
            Debug.Log(Vector3.Angle(transform.forward, transform.position - RightTarget.position));
            if (Vector3.Angle(transform.forward, transform.position - RightTarget.position) > angleThreshold)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, RotationSpeed / 10f * Time.deltaTime);
            }
        }
        else if(horizontalInput > 0)
        {
            var dirRot = transform.position - LeftTarget.position;
            var tarRot = Quaternion.LookRotation(dirRot);
            Debug.Log(Vector3.Angle(transform.forward, transform.position - LeftTarget.position));
            
            if (Vector3.Angle(transform.forward, transform.position - LeftTarget.position) > angleThreshold)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, RotationSpeed / 10f * Time.deltaTime);
            }
            //Debug.Log(Vector3.Dot(dirRot, transform.forward));
            //if (Vector3.Dot(dirRot, transform.forward) < 15.0f)
            //{
              //  transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, RotationSpeed / 10f * Time.deltaTime);
            //}
        }
	}
}
