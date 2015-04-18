using UnityEngine;
using System.Collections;


[RequireComponent(typeof(TestWallActions))]
public class WallActions : MonoBehaviour 
{
    private bool nextToWall = false;
    private GameObject currWall;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Slash) && nextToWall)
        {
            currWall.GetComponent<WallProperties>().Clickable++;
        }
        if(currWall == null)
        {
            nextToWall = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("You hit a wall " + Time.time);
            nextToWall = true;
            currWall = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            nextToWall = false;
            currWall = null;
        }
    }
}
