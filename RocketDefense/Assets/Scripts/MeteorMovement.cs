using UnityEngine;
using System.Collections;

public class MeteorMovement : MonoBehaviour 
{
    public float MeteorAcceleration;
    public float MeteorSpeed;
    private Vector3 moveBy;
    private float currentSpeed;
	// Use this for initialization
	void Start () 
    {
        currentSpeed = 0f;
        moveBy = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentSpeed = SpeedUpToTarget(currentSpeed, MeteorSpeed, MeteorAcceleration);
        moveBy.y = currentSpeed;
        transform.Translate(-moveBy * Time.deltaTime);
	}

    private float SpeedUpToTarget(float current, float target, float acc)
    {
        if(current == target)
        {
            return target;
        }
        float direction = Mathf.Sign(target - current);
        current += (acc * Time.deltaTime * direction);
        return (direction != Mathf.Sign(target - current)) ? target : current;
    }
}
