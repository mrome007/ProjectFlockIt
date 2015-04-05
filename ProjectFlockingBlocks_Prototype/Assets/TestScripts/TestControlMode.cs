using UnityEngine;
using System.Collections;

public class TestControlMode : MonoBehaviour 
{
    private PlayerModes playerModes;

    private bool whereIsControlTarget;
    private const string whereIsControlTargetMessage = "Control Target Doesn't match";


    private Vector3 targetControl = Vector3.zero;
    private GameObject Ground;
    void Awake()
    {
        playerModes = gameObject.GetComponent<PlayerModes>();
        Ground = GameObject.FindGameObjectWithTag("Ground");
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	   if(Input.GetMouseButtonDown(0) && playerModes.CurrentMode == PlayerModes.PlayerMode.Control)
       {
           Vector3 mousePos = Input.mousePosition;
           mousePos.z = 12f;
           targetControl.z = Camera.main.ScreenToWorldPoint(mousePos).z;
           Debug.Log(targetControl);
       }
	}

    void LateUpdate()
    {
        if (playerModes.CurrentMode == PlayerModes.PlayerMode.Control)
        {
            //TestControlTarget();
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
}
