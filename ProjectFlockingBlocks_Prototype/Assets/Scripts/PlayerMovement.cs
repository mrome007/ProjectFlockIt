using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    public float PlayerSpeed;
    private int currentlyFacing;
    public int CurrentlyFacing
    {
        get { return currentlyFacing; }
    }
    private bool startMoving;

    public void StartMovement()
    {
        startMoving = true;
    }

	// Use this for initialization
	void Start () 
    {
        currentlyFacing = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!startMoving)
        {
            return;
        }
        float horizontalMove = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalMove * Vector3.forward * Time.deltaTime * PlayerSpeed);
        FaceOppositeDirection(horizontalMove);
	}

    private void FaceOppositeDirection(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            currentlyFacing = 0;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (horizontalMove < 0)
        {
            currentlyFacing = 1;
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
