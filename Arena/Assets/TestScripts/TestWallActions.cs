using UnityEngine;
using System.Collections;

public class TestWallActions : MonoBehaviour
{
    #region boolean test flags
    private bool hasWallActionsScript;
    private bool isNearWall;
    private bool doesWallHaveWallProperties;
    private bool doesWallPropertiesClick;
    private bool hasWallClickableIncreased;
    #endregion

    #region test messages
    private const string hasWallActionsScriptMessage = "Player does not have Wall Actions Script";
    private const string isNearWallMessage = "What ever you hit is not a wall";
    private const string doesWallHaveWallPropertiesMessage = "The Wall you are next to you does not have Wall Properties Script";
    private const string doesWallPropertiesClickMessage = "Wall Properties does not have clicked on value";
    private const string hasWallClickableIncreasedMessage = "Clicking didn't increase the Clickable";
    #endregion

    private int prevClickable;
    private int currClickable;

    private GameObject currWall;
    private bool nextToWall;
    // Use this for initialization
	void Start () 
    {
        currClickable = 0;
        prevClickable = currClickable;
        TestHasWallActionsScript();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void LateUpdate()
    {
        if (nextToWall)
        {
            TestHasClickableIncreased();
        }
    }

    private void TestHasWallActionsScript()
    {
        WallActions wallAct = gameObject.GetComponent<WallActions>();
        hasWallActionsScript = wallAct != null;
        if(!hasWallActionsScript)
        {
            Debug.LogError(hasWallActionsScriptMessage);
        }
    }

    private void TestHasWallProperties(GameObject wall)
    {
        WallProperties wallProp = wall.GetComponent<WallProperties>();
        doesWallHaveWallProperties = wallProp != null;
        if(!doesWallHaveWallProperties)
        {
            Debug.LogError(doesWallHaveWallPropertiesMessage);
        }
        else
        {
            prevClickable = wallProp.Clickable;
            TestHasWallPropertiesClicked(wallProp);
        }
    }

    private void TestHasWallPropertiesClicked(WallProperties wall)
    {
        doesWallPropertiesClick = wall.Clicked > 0;
        if(!doesWallPropertiesClick)
        {
            Debug.LogError(doesWallPropertiesClickMessage);
        }
        else
        {
            Debug.Log("Wall clicked = " + wall.Clicked);
        }
    }

    private void TestHasClickableIncreased()
    {
        WallProperties wall = currWall.GetComponent<WallProperties>();
        currClickable = wall.Clickable;
        if(Input.GetKeyDown(KeyCode.M) && nextToWall)
        {
            currClickable = wall.Clickable;
            hasWallClickableIncreased = currClickable > prevClickable;
            if(!hasWallClickableIncreased)
            {
                Debug.LogError(hasWallClickableIncreasedMessage);
            }
            else
            {
                Debug.Log(currClickable + " " + prevClickable);
                prevClickable = currClickable;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isNearWall = other.gameObject.tag == "Wall";
        if(!isNearWall)
        {
            Debug.LogError(isNearWallMessage);
        }
        else
        {
            nextToWall = true;
            currWall = other.gameObject;
            TestHasWallProperties(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            nextToWall = false;
            currWall = null;
        }
    }


}
