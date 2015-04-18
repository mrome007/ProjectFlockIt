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
    private bool wasThereADestroyedWall;
    private bool wasThereASpawnAfterDestroy;
    #endregion

    #region test messages
    private const string hasWallActionsScriptMessage = "Player does not have Wall Actions Script";
    private const string isNearWallMessage = "What ever you hit is not a wall";
    private const string doesWallHaveWallPropertiesMessage = "The Wall you are next to you does not have Wall Properties Script";
    private const string doesWallPropertiesClickMessage = "Wall Properties does not have clicked on value";
    private const string hasWallClickableIncreasedMessage = "Clicking didn't increase the Clickable";
    private const string wasThereADestroyedWallMessage = "There doesn't seem to be a wall destroyed";
    private const string wasThereASpawnAfterDestroyMessage = "Hey you just destroyed a wall and nothing spawned";
    #endregion

    private int prevClickable;
    private int currClickable;

    private GameObject currWall;
    private bool nextToWall;

    private int numWallsOnScene;
    private int curNumWalls;

    private int curNumSpawns;
    void Awake()
    {
        numWallsOnScene = GameObject.FindGameObjectsWithTag("Wall").Length;
        curNumWalls = numWallsOnScene;
    }

    // Use this for initialization
	void Start () 
    {
        curNumSpawns = 0;
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
        TestDestroyedWalls();
        if (currWall == null)
        {
            nextToWall = false;
        }
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
            //Debug.Log("Wall clicked = " + wall.Clicked);
        }
    }

    private void TestHasClickableIncreased()
    {
        //if (currWall == null)
          //  return;
        WallProperties wall = currWall.GetComponent<WallProperties>();
        currClickable = wall.Clickable;
        if(Input.GetKeyDown(KeyCode.Slash) && nextToWall)
        {
            currClickable = wall.Clickable;
            hasWallClickableIncreased = currClickable > prevClickable;
            if(!hasWallClickableIncreased)
            {
                Debug.LogError(hasWallClickableIncreasedMessage);
            }
            else
            {
                //Debug.Log(currClickable + " " + prevClickable);
                prevClickable = currClickable;
            }
        }
    }

    private void TestDestroyedWalls()
    {
        if(nextToWall && (currWall == null))
        {
            curNumWalls = GameObject.FindGameObjectsWithTag("Wall").Length;
            wasThereADestroyedWall = (numWallsOnScene - 1) == curNumWalls;
            if(!wasThereADestroyedWall)
            {
                Debug.LogError(wasThereADestroyedWallMessage);
            }
            numWallsOnScene = curNumWalls;
            curNumSpawns++;
            TestSpawnAfterDestroyedWall();
        }
    }

    private void TestSpawnAfterDestroyedWall()
    {
        var numSpawn = GameObject.FindGameObjectsWithTag("MiniWall").Length;
        wasThereASpawnAfterDestroy = numSpawn == curNumSpawns;
        if(!wasThereASpawnAfterDestroy)
        {
            Debug.LogError(wasThereASpawnAfterDestroyMessage);
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
