using UnityEngine;
using System.Collections;

public class TestPlayerMovement : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerMovement;
    private bool isNotMovingInY;
    #endregion

    #region error messages
    private const string hasPlayerMovementMessage = "Player does not have PlayerMovement Script.";
    private const string isNotMovingInYMessage = "Player is not suppose to be moving in the y-axis.";
    #endregion

    void Start()
    {
        TestHasPlayerMovement();
    }

    void Update()
    {
        TestMovementInY();
    }

    private void TestHasPlayerMovement()
    {
        PlayerMovement playerMove = gameObject.GetComponent<PlayerMovement>();
        hasPlayerMovement = playerMove != null;
        if(!hasPlayerMovement)
        {
            Debug.LogError(hasPlayerMovementMessage);
        }
    }

    private void TestMovementInY()
    {
        isNotMovingInY = transform.position.y == 0;
        if(!isNotMovingInY)
        {
            Debug.LogError(isNotMovingInYMessage);
        }
    }
}
