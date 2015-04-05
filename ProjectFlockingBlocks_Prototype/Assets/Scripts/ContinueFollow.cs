using UnityEngine;
using System.Collections;

public class ContinueFollow : MonoBehaviour
{
    public GameObject Target;
    private float dampTime = 0.45f;
    private Vector3 targetThePlayer;
    private Vector3 followVelocity;
    private GameObject miniBlocksContainer;

    void Awake()
    {
        miniBlocksContainer = GameObject.FindGameObjectWithTag("Container");
    }
	// Use this for initialization
	void Start () 
    {
        dampTime = Random.Range(0.25f, 0.55f);
        targetThePlayer = Target.transform.position;
        targetThePlayer.x = transform.position.x;
        targetThePlayer.y = -0.5f;
        transform.parent = miniBlocksContainer.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        targetThePlayer = Target.transform.position;
        targetThePlayer.x = transform.position.x + Random.Range(-1.0f,1.0f);
        targetThePlayer.y = -0.5f;
        targetThePlayer.z += Random.Range(-13.0f, 13.0f);
        transform.position = Vector3.SmoothDamp(transform.position, targetThePlayer, ref followVelocity, dampTime);
	}
}
