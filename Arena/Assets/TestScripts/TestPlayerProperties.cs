using UnityEngine;
using System.Collections;

public class TestPlayerProperties : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerPropertiesScript;
    private bool doesPlayerHaveRightMode;
    #endregion

    #region test messages
    private const string hasPlayerPropertiesMessage = "Player does not have Player Properties Script";
    private const string doesPlayerHaveRightModeMessage = "Player does not have the right mode";
    #endregion

    private int modeIndex;
    private string[] modes = { "Default", "Direct", "Drop", "Destroy" };
    // Use this for initialization
	void Start () 
    {
        modeIndex = 0;
        TestHasPlayerProperties();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Period))
        {
            modeIndex++;
            modeIndex %= 4;
        }
	}

    void LateUpdate()
    {
        TestDoesPlayerRightMode();
    }

    private void TestHasPlayerProperties()
    {
        PlayerProperties playProp = gameObject.GetComponent<PlayerProperties>();
        hasPlayerPropertiesScript = playProp != null;
        if(!hasPlayerPropertiesScript)
        {
            Debug.LogError(hasPlayerPropertiesMessage);
        }
    }

    private void TestDoesPlayerRightMode()
    {
        PlayerProperties playProp = gameObject.GetComponent<PlayerProperties>();
        doesPlayerHaveRightMode = playProp.CurrModeName == modes[modeIndex];
        if(!doesPlayerHaveRightMode)
        {
            Debug.LogError(doesPlayerHaveRightModeMessage);
        }
    }
}
