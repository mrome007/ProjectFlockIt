using UnityEngine;
using System.Collections;

public class TestMiniWallProperties : MonoBehaviour
{
    #region boolean test flags
    private bool hasMiniWallProperties;
    private bool defaultIsOn;
    private bool directIsOn;
    #endregion

    #region test messages
    private const string hasMiniWallPropertiesMessage = "Mini Wall does not have MiniWallProperties Script";
    private const string defaultIsOnMessage = "Default Action is not on";
    private const string directIsOnMessage = "Direct Action is not on";
    #endregion
    // Use this for initialization
	void Start () 
    {
        TestHasMiniWallProperties();
	}
	

    void LateUpdate()
    {
        TestDefaulIsOn();
        TestDirectIsOn();
    }

    private void TestHasMiniWallProperties()
    {
        MiniWallProperties miniProp = gameObject.GetComponent<MiniWallProperties>();
        hasMiniWallProperties = miniProp != null;
        if(!hasMiniWallProperties)
        {
            Debug.LogError(hasMiniWallPropertiesMessage);
        }
    }

    private void TestDefaulIsOn()
    {
        MiniWallProperties miniWallProp = gameObject.GetComponent<MiniWallProperties>();
        if (miniWallProp.ActiveMode == "Default")
        {
            MiniFollow miniFol = gameObject.GetComponent<MiniFollow>();
            TestMiniWallFollow tMiniFol = gameObject.GetComponent<TestMiniWallFollow>();

            defaultIsOn = (miniFol.enabled == true) && (tMiniFol.enabled == true);
            if (!defaultIsOn)
            {
                Debug.LogError(defaultIsOnMessage);
            }
        }
    }

    private void TestDirectIsOn()
    {
        MiniWallProperties miniWallProp = gameObject.GetComponent<MiniWallProperties>();
        if (miniWallProp.ActiveMode == "Direct")
        {
            MiniDirect miniDir = gameObject.GetComponent<MiniDirect>();
            TestMiniDirect tMiniDir = gameObject.GetComponent<TestMiniDirect>();

            directIsOn = (miniDir.enabled == true) && (tMiniDir.enabled == true);
            if (!directIsOn)
            {
                Debug.LogError(directIsOnMessage);
            }
        }
    }
}
