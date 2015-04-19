using UnityEngine;
using System.Collections;

public class TestPlayerProperties : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerPropertiesScript;
    #endregion

    #region test messages
    private const string hasPlayerPropertiesMessage = "Player does not have Player Properties Script";
    #endregion
    // Use this for initialization
	void Start () 
    {
        TestHasPlayerProperties();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
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
}
