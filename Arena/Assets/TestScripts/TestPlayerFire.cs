using UnityEngine;
using System.Collections;

public class TestPlayerFire : MonoBehaviour
{
    #region boolean test flags
    private bool hasPlayerFire;
    private bool isAmmoOnScreen;
    #endregion

    #region test messages
    private const string hasPlayerFireMessage = "Player does not have a Player Fire Script.";
    private const string isAmmoOnScreenMessage = "When pressing fire, there are no ammos on screen";
    #endregion

    private bool hasFireBeenPressed = false;

    // Use this for initialization
	void Start () 
    {
	
	}

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || 
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && (PlayerProperties.Minis.Count > 0))
        {
            hasFireBeenPressed = true;
        }
    }

    void LateUpdate()
    {
        TestIsAmmoOnScreen();
    }

    private void TestHasPlayerFire()
    {
        PlayerFire playFire = gameObject.GetComponent<PlayerFire>();
        hasPlayerFire = playFire != null;
        if(!hasPlayerFire)
        {
            Debug.LogError(hasPlayerFireMessage);
        }
    }

    private void TestIsAmmoOnScreen()
    {
        if(hasFireBeenPressed)
        {
            var ammos = GameObject.FindGameObjectsWithTag("Ammo");
            isAmmoOnScreen = ammos.Length > 0;
            if(!isAmmoOnScreen)
            {
                Debug.LogError(isAmmoOnScreenMessage);
            }
        }
        hasFireBeenPressed = false;
    }
}
