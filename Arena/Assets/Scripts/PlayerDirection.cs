using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TestPlayerChangeDirection))]
public class PlayerDirection : MonoBehaviour 
{
    private Vector3 up = new Vector3(0f, 270f, 0f);
    private Vector3 down = new Vector3(0f, 90f, 0f);
    private Vector3 left = new Vector3(0f, 180f, 0f);
    private Vector3 right = new Vector3(0f, 0f, 0f);
	// Use this for initialization
	void Start () 
    {
        transform.GetChild(0).rotation = Quaternion.Euler(right); 
	}
	
	// Update is called once per frame
	void Update () 
    {
        ChangeDirections();
	}

    private void ChangeDirections()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.GetChild(0).rotation = Quaternion.Euler(up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.GetChild(0).rotation = Quaternion.Euler(down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.GetChild(0).rotation = Quaternion.Euler(left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.GetChild(0).rotation = Quaternion.Euler(right);
        }
    }
}
