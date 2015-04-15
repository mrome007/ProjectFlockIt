using UnityEngine;
using System.Collections;

public class TestFireAmmo : MonoBehaviour
{
    #region boolean test flags
    private bool hasFireAmmoScript;
    private bool isGoingForward;
    #endregion

    #region test messages
    private const string hasFireAmmoScriptMessage = "Ammo does not have Fire Ammo Script";
    private const string isGoingForwardMessage = "Ammo is not going forward";
    #endregion

    private Vector3 prevX;
    private Vector3 currentX;
    private float timerTest = 0.35f;
    // Use this for initialization
	void Start () 
    {
        currentX = transform.position;
        prevX = currentX;
	}
	
	// Update is called once per frame
	void Update () 
    {
        TestIsGoingForward();
	}

    private void TestHasFireAmmoScript()
    {
        FireAmmo fAmmo = gameObject.GetComponent<FireAmmo>();
        hasFireAmmoScript = fAmmo != null;
        if(!hasFireAmmoScript)
        {
            Debug.LogError(hasFireAmmoScriptMessage);
        }
    }

    private void TestIsGoingForward()
    {
        timerTest -= Time.deltaTime;
        if(timerTest <= 0f)
        {
            timerTest = 0.35f;
            currentX = transform.position;
            isGoingForward = Vector3.Distance(currentX, prevX) > 0f;
            if(!isGoingForward)
            {
                Debug.LogError(isGoingForwardMessage);
            }
            prevX = currentX;
        }
    }
}
