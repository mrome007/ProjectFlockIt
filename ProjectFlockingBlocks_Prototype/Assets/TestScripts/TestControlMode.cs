using UnityEngine;
using System.Collections;

public class TestControlMode : MonoBehaviour 
{
    private PlayerModes playerModes;

    private bool whereIsControlTarget;
    private const string whereIsControlTargetMessage = "Control Target Doesn't match";

    private bool miniHasTarget;
    private const string miniHasTargetMessage = "During Control Mode, mini block does not have a target.";

    private Vector3 targetControl = Vector3.zero;
    private GameObject Ground;
    private GameObject miniBlockContainer;

    void Awake()
    {
        playerModes = gameObject.GetComponent<PlayerModes>();
        Ground = GameObject.FindGameObjectWithTag("Ground");
        miniBlockContainer = GameObject.FindGameObjectWithTag("Container");
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        /*
	   if(Input.GetMouseButtonDown(0) && playerModes.CurrentMode == PlayerModes.PlayerMode.Control)
       {
           Vector3 mousePos = Input.mousePosition;
           mousePos.z = 12f;
           targetControl.z = Camera.main.ScreenToWorldPoint(mousePos).z;
       }
       */
	}

    void LateUpdate()
    {
        if (playerModes.CurrentMode == PlayerModes.PlayerMode.Control)
        {
            //TestControlTarget();
            if(Input.GetMouseButtonDown(0))
            {
                TestGoToTarget();
            }
        }
    }

    void TestControlTarget()
    {
        whereIsControlTarget = Mathf.Abs(targetControl.z - playerModes.ControlTarget.z) <= 1.0f;
        if(!whereIsControlTarget)
        {
            Debug.LogError(whereIsControlTargetMessage);
        }
        TestIt.Assert(whereIsControlTarget);
    }

    void TestGoToTarget()
    {
        miniHasTarget = true;
        int numChild = miniBlockContainer.transform.childCount;
        for (int index = 0; index < numChild; index++)
        {
            ControlToTarget cto = miniBlockContainer.transform.GetChild(index).gameObject.GetComponent<ControlToTarget>();
            TestFollowPlayer tfp = miniBlockContainer.transform.GetChild(index).gameObject.GetComponent<TestFollowPlayer>();
            ContinueFollow cf = miniBlockContainer.transform.GetChild(index).gameObject.GetComponent<ContinueFollow>();
            if (cto.Target == null || tfp.enabled == true || cf.enabled == true)
            {
                miniHasTarget = false;
            }
        }
        if(!miniHasTarget)
        {
            Debug.LogError(miniHasTargetMessage);
        }
        TestIt.Assert(miniHasTarget);
    }
}
