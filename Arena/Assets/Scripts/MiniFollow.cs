using UnityEngine;
using System.Collections;


[RequireComponent(typeof(TestMiniWallFollow))]
public class MiniFollow : MonoBehaviour 
{
    public GameObject Target;
    private Vector3 targetPos;

    private Vector3 refVelocity;
    public float miniSmoothTime;
	// Use this for initialization
	void Start () 
    {
        refVelocity = Vector3.zero;
        targetPos = Vector3.zero;
        var chance = Random.Range(0, 2);
        targetPos.x = (chance == 0) ? Random.Range(0.15f, 3.5f) : Random.Range(-3.5f, -0.15f);
        chance = Random.Range(0, 2);
        targetPos.z = (chance == 0) ? Random.Range(0.15f, 3.5f) : Random.Range(-3.5f, -0.15f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.transform.position + targetPos, ref refVelocity, miniSmoothTime);
	}

    void FixedUpdate()
    {
        
    }
}
