using UnityEngine;
using System.Collections;

public class TestMiniWallFollow : MonoBehaviour
{
    #region boolean test flags
    private bool hasMiniFollowScript;
    private bool hasMiniTarget;
    private bool isMiniTargetPlayer;
    #endregion

    #region test messages
    private const string hasMiniFollowScriptMessage = "Mini Wall does not have Mini Follow Script";
    private const string hasMiniTargetMessage = "Mini Target does not have a target";
    private const string isMiniTargetPlayerMessage = "Mini has a target, but it is not the player";
    #endregion

    public GameObject thePlayer;
    void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void TestHasMiniFollowScript()
    {
        MiniFollow minifol = gameObject.GetComponent<MiniFollow>();
        hasMiniFollowScript = minifol != null;
        if(!hasMiniFollowScript)
        {
            Debug.LogError(hasMiniFollowScriptMessage);
        }
        else
        {
            TestHasMiniTarget(minifol);
        }
    }

    private void TestHasMiniTarget(MiniFollow minifol)
    {
        hasMiniTarget = minifol.Target != null;
        if(!hasMiniTarget)
        {
            Debug.LogError(hasMiniTargetMessage);
        }
        else
        {
            TestIsMiniTargetPlayer(minifol.Target);
        }
    }

    private void TestIsMiniTargetPlayer(GameObject player)
    {
        isMiniTargetPlayer = player == thePlayer;
        if(!isMiniTargetPlayer)
        {
            Debug.LogError(isMiniTargetPlayerMessage);
        }
    }
}
