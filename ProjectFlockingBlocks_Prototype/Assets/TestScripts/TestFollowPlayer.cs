using UnityEngine;
using System.Collections;

public class TestFollowPlayer : MonoBehaviour 
{
    private GameObject thePlayer;
    private bool isFollowingPlayer;
    private const string isFollowingPlayerMessage = "Not Following the Player";


    private bool isContinuingToFollow;
    private const string isContinuingToFollowMessage = "The mini is no longer following the player";

    void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void Start () 
    {
        isFollowingPlayer = transform.parent == thePlayer.transform;
        if(!isFollowingPlayer)
        {
            Debug.LogError(isFollowingPlayerMessage);
        }
        TestIt.Assert(isFollowingPlayer);
	}
	

    void LateUpdate()
    {
        TestContinueToFollow();
    }

    void TestContinueToFollow()
    {
        isContinuingToFollow = gameObject.GetComponent<ContinueFollow>().Target != null;
        if(!isContinuingToFollow)
        {
            Debug.LogError(isContinuingToFollowMessage);
        }
        TestIt.Assert(isContinuingToFollow);
    }
}
