using UnityEngine;
using System.Collections;

public class PlayerModes : MonoBehaviour 
{
    public GameObject MiniContainer;
    public LayerMask GroundLayer;
    public enum PlayerMode
    {
        Default,
        Throw,
        Control,
        Explode
    }

    private int whichMode;
    public int NumModes = 4;
    public PlayerMode CurrentMode;

    //Control Mode;
    public Vector3 ControlTarget = Vector3.zero;
	// Use this for initialization
	void Start () 
    {
        whichMode = 0;
        CurrentMode = (PlayerMode)whichMode;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ChangeMode();
        ModeActions();
	}

    void ChangeMode()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            whichMode++;
            whichMode %= NumModes;
            CurrentMode = (PlayerMode)whichMode;
        }
    }

    void ModeActions()
    {
        switch(CurrentMode)
        {
            case PlayerMode.Default:
                break;

            case PlayerMode.Control:
                ControlActions();
                break;

            case PlayerMode.Throw:
                break;

            case PlayerMode.Explode:
                break;
                
            default:
                break;
        }
    }

    void ControlActions()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 20.0f, GroundLayer))
            {
                ControlTarget.z = hit.point.z;
                ControlSetMiniTarget(ControlTarget);
            }
        }
    }

    void ControlSetMiniTarget(Vector3 target)
    {
        int numChild = MiniContainer.transform.childCount;
        for (int index = 0; index < numChild; index++)
        {
            TestFollowPlayer tfp = MiniContainer.transform.GetChild(index).gameObject.GetComponent<TestFollowPlayer>();
            tfp.enabled = false;
            ContinueFollow cf = MiniContainer.transform.GetChild(index).gameObject.GetComponent<ContinueFollow>();
            cf.enabled = false;
            ControlToTarget cto = MiniContainer.transform.GetChild(index).gameObject.GetComponent<ControlToTarget>();
            cto.Target = target;
            cto.SetMiniTarget();
            cto.enabled = true;
        }

        for(int index = 0; index < numChild; index++)
        {
            Debug.Log(index + " " + numChild);
            MiniContainer.transform.GetChild(0).transform.parent = null;
        }
    }
}
