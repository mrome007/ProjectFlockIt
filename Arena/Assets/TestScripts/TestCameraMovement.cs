using UnityEngine;
using System.Collections;

public class TestCameraMovement : MonoBehaviour
{
    #region boolean test flags
    private bool hasCameraMovement;
    private bool isNotMovingInY;
    #endregion

    #region test messages
    private const string hasCameraMovementMessage = "Camera does not have Camera Movement Script";
    private const string isNotMovingInYMessage = "The Camera should not be moving in the y-axis";
    #endregion
    // Use this for initialization
	void Start () 
    {
        TestHasCameraMovement();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void TestHasCameraMovement()
    {
        CameraMovement camMove = gameObject.GetComponent<CameraMovement>();
        hasCameraMovement = camMove != null;

        if(!hasCameraMovement)
        {
            Debug.LogError(hasCameraMovementMessage);
        }
    }

    private void TestIsNotMovingInY()
    {
        isNotMovingInY = transform.position.y == 20;
        if(!isNotMovingInY)
        {
            Debug.LogError(isNotMovingInYMessage);
        }
    }
}
