using UnityEngine;
using System.Collections;

public class TestPlayerDirect : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerDirectScript;
    private bool hasMiniWallListDecreased;
    private bool wasFollowTurnedOff;
    #endregion

    #region test messages
    private const string hasPlayerDirectScriptMessage = "Player does not have Player Direct Script";
    private const string hasMiniWallListDecreasedMessage = "Mini Wall List did not decrease";
    private const string wasFollowTurnedOffMessage = "Mini that was directed is still following player";
    #endregion

    private bool playDirected = false;
    private int currMiniWalls;
    // Use this for initialization
	void Start () 
    {
        currMiniWalls = PlayerProperties.Minis.Count;
        playDirected = false;
        TestHasPlayerDirect();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (PlayerProperties.PlyerModes == PlayerProperties.PlayerModes.Direct)
        {
            if ((PlayerProperties.Minis.Count > 0) &&(Input.GetKeyDown(KeyCode.UpArrow) || 
                Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) 
                || Input.GetKeyDown(KeyCode.RightArrow)))
            {
                playDirected = true;
                currMiniWalls = PlayerProperties.Minis.Count;
            }
        }
	}

    void LateUpdate()
    {
        if(playDirected)
        {
            TestHasMiniWallListDecreased();
        }
    }

    private void TestHasPlayerDirect()
    {
        PlayerDirect playDir = gameObject.GetComponent<PlayerDirect>();
        hasPlayerDirectScript = playDir != null;
        if(!hasPlayerDirectScript)
        {
            Debug.LogError(hasPlayerDirectScriptMessage);
        }
    }

    private void TestHasMiniWallListDecreased()
    {
        int theCurNumMinis = PlayerProperties.Minis.Count;
        hasMiniWallListDecreased = theCurNumMinis == currMiniWalls;
        if(!hasMiniWallListDecreased)
        {
            Debug.LogError(hasMiniWallListDecreasedMessage);
        }
        Debug.Log(PlayerProperties.Minis.Count);
        playDirected = false;
    }
}
