using UnityEngine;
using System.Collections;

public class TestPlayerChangeDirection : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerChangeDirectionScript;
    private bool hasChangedDirections;
    #endregion

    #region test messages
    private const string hasPlayerChangeDirectionScriptMessage = "Player does not have a Player Direction Script";
    private const string hasChangedDirectionsMessage = "Player did not switch directions as required";
    #endregion

    private bool up;
    private bool down;
    private bool left;
    private bool right;
    // Use this for initialization
	void Start () 
    {
        right = true;
        up = false;
        down = false;
        left = false;
        TestHasPlayerChangedDirectionScript();
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetInputArrows();
	}

    void LateUpdate()
    {
        TestChangedDirections();
    }

    private void TestHasPlayerChangedDirectionScript()
    {
        PlayerDirection playD = gameObject.GetComponent<PlayerDirection>();
        hasPlayerChangeDirectionScript = playD != null;
        if(!hasPlayerChangeDirectionScript)
        {
            Debug.LogError(hasPlayerChangeDirectionScriptMessage);
        }
    }

    private void TestChangedDirections()
    {
        if(up)
        {
            hasChangedDirections = transform.GetChild(0).rotation.eulerAngles.y == 270.0f ||
                transform.GetChild(0).rotation.eulerAngles.y == -90.0f;
        }
        if(down)
        {
            hasChangedDirections = transform.GetChild(0).rotation.eulerAngles.y <= 91.0f ||
                transform.GetChild(0).rotation.eulerAngles.y >= 89.0f;
        }
        if(left)
        {
            hasChangedDirections = transform.GetChild(0).rotation.eulerAngles.y <= 181.0f &&
                transform.GetChild(0).rotation.eulerAngles.y > 179.0f;
        }
        if(right)
        {
            hasChangedDirections = transform.GetChild(0).rotation.eulerAngles.y == 0.0f ||
                transform.GetChild(0).rotation.eulerAngles.y == 360.0f;
        }
        ChangedDirectionError(hasChangedDirections);
    }

    private void ChangedDirectionError(bool has)
    {
        if(!has)
        {
            Debug.LogError(hasChangedDirectionsMessage);
        }
    }

    private void GetInputArrows()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            down = false;
            left = false;
            right = false;
            up = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            up = false;
            left = false;
            right = false;
            down = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            up = false;
            down = false;
            right = false;
            left = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            up = false;
            down = false;
            left = false;
            right = true;
        }
    }
}
