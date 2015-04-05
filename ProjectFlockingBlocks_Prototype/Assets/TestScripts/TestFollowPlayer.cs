using UnityEngine;
using System.Collections;

public class TestFollowPlayer : MonoBehaviour 
{
    private GameObject thePlayer;
    private GameObject theMiniContainer;
    private bool isFollowingPlayer;
    private const string isFollowingPlayerMessage = "Not Following the Player";


    private bool isContinuingToFollow;
    private const string isContinuingToFollowMessage = "The mini is no longer following the player";

    private bool inMiniBlockContainer;
    private const string inMiniBlockContainerMessage = "Mini block is not in mini block container";

    void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theMiniContainer = GameObject.FindGameObjectWithTag("Container");
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
        TestInMiniBlockContainer();
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

    void TestInMiniBlockContainer()
    {
        inMiniBlockContainer = transform.parent == theMiniContainer.transform;
        if(!inMiniBlockContainer)
        {
            Debug.LogError(inMiniBlockContainerMessage);
        }
        TestIt.Assert(inMiniBlockContainer);
    }
}
