using UnityEngine;
using System.Collections;

public class ControlToTarget : MonoBehaviour 
{
    public Vector3? Target;
    public float MiniDampTime;
    private Vector3 theTarget;
    private Vector3 followVelocity;

	void Start () 
    {
        MiniDampTime = Random.Range(0.15f,0.65f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.enabled)
        {
            transform.position = Vector3.SmoothDamp(transform.position, theTarget, ref followVelocity, MiniDampTime);
        }
	}

    public void SetMiniTarget()
    {
        theTarget = (Vector3)Target;
        Debug.Log(theTarget);
        theTarget.x = transform.position.x + Random.Range(-1.0f, 1.0f);
        theTarget.y = -0.5f;
        theTarget.z += Random.Range(-2f, 2f);
    }
}
