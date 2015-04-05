using UnityEngine;
using System.Collections;

public class TestModes : MonoBehaviour 
{
    private PlayerModes playerModes;
    private int whichMode;

    private bool currentMode;
    private const string currentModeMessage = "Not the right mode";
    void Awake()
    {
        playerModes = gameObject.GetComponent<PlayerModes>();
    }

    void Start()
    {
        whichMode = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            whichMode++;
            whichMode %= 4;
        }
    }
	
	void LateUpdate()
    {
        TestPlayerModes();
    }

    void TestPlayerModes()
    {
        currentMode = playerModes.CurrentMode == (PlayerModes.PlayerMode)whichMode;
        //currentMode = playerModes.CurrentMode == whichMode;
        if(!currentMode)
        {
            Debug.LogError(currentModeMessage);
        }
        TestIt.Assert(currentMode);
    }
}
