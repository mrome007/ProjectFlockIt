using UnityEngine;
using System.Collections;

public class TestPlayerMovement : MonoBehaviour 
{
    private PlayerMovement player;
    #region string error messages
    private const string messageHorizontal = "Player moved in another plane other than HORIZONTAL";
    private const string messageFacingLeft = "Player is facing LEFT when it should be facing RIGHT";
    private const string messageFacingRight = "Player is facing RIGHT when it should be facing LEFT";
    #endregion

    #region test flags
    private bool movementHorizontal;
    private bool changeDirection;
    #endregion
    // Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        //tests
        movementHorizontal = ((player.gameObject.transform.position.y == 0f)
                                  && (player.gameObject.transform.position.z == 0f));

        player.StartMovement();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //tests
        TestHorizontalMovement();
        TestDirectionChange();
	}

    private void TestHorizontalMovement()
    {
        movementHorizontal = ((player.gameObject.transform.position.y == 0f)
                                  && (player.gameObject.transform.position.x == 0f));
        TestIt.Assert(movementHorizontal);
    }

    private void TestDirectionChange()
    {
        //facing right
        if(player.CurrentlyFacing == 0)
        {
            changeDirection = player.gameObject.transform.GetChild(0).transform.rotation == Quaternion.Euler(0f, 180f, 0f);
            TestIt.Assert(changeDirection);
        }
        else//facing left
        {
            changeDirection = player.gameObject.transform.GetChild(0).transform.rotation == Quaternion.Euler(0f, 0f, 0f);
            TestIt.Assert(changeDirection);
        }
    }
}
