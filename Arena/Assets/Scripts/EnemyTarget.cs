using UnityEngine;
using System.Collections;

public class EnemyTarget : MonoBehaviour 
{
    private Transform playerTrans;
    public float EnemySpeed;
    void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
	// Use this for initialization
	void Start () 
    {
        EnemySpeed = Random.Range(0.1f, 10f);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
