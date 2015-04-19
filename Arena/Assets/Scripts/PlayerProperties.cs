using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TestPlayerProperties))]
public class PlayerProperties : MonoBehaviour 
{
    public static List<GameObject> Minis;
	// Use this for initialization
	void Start () 
    {
        Minis = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
