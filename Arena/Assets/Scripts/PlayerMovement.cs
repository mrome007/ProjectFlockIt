using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TestPlayerMovement))]
public class PlayerMovement : MonoBehaviour 
{
    public float PlayerSpeed;

    private Vector3 moveBy;
	// Use this for initialization
	void Start () 
    {
        moveBy = new Vector3();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovePlayer();
	}

    private void MovePlayer()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        moveBy = new Vector3(hor, 0f, ver);
        transform.Translate(moveBy * PlayerSpeed * Time.deltaTime);
    }
}
