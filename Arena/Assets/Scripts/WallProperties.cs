using UnityEngine;
using System.Collections;

public class WallProperties : MonoBehaviour 
{
    public int Clicked;
    public int Clickable;
	// Use this for initialization
	void Awake () 
    {
        Clickable = 0;
        Clicked = Random.Range(1, 5);
	}

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
