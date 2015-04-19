using UnityEngine;
using System.Collections;


[RequireComponent(typeof(TestMiniWallFollow))]
public class MiniFollow : MonoBehaviour 
{
    public GameObject Target;
    private Vector3 targetPos;

    private Vector3 refVelocity;
    public float miniSmoothTime;

    private float timer = 0f;
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
        timer -= Time.deltaTime;
        ResetAddedTargetPos();
	}

    void FixedUpdate()
    {

    }

    private void ResetAddedTargetPos()
    {
        if (timer <= 0f)
        {
            timer = Random.Range(0f, 2.5f);
            var chance = Random.Range(0, 2);
            targetPos.x = (chance == 0) ? Random.Range(0.15f, 3.5f) : Random.Range(-3.5f, -0.15f);
            chance = Random.Range(0, 2);
            targetPos.z = (chance == 0) ? Random.Range(0.15f, 3.5f) : Random.Range(-3.5f, -0.15f);
        }
    }
}
