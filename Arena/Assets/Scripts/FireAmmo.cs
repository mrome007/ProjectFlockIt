using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TestFireAmmo))]
public class FireAmmo : MonoBehaviour 
{
    public float AmmoSpeed;
	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.right * Time.deltaTime * AmmoSpeed);
	}
}
