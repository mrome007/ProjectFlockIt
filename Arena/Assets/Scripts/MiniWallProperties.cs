using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TestMiniWallProperties))]
public class MiniWallProperties : MonoBehaviour 
{
    public string ActiveMode = "Default";
    private string currentMode;
    
    void Awake()
    {
        ActiveMode = "Default";
        currentMode = ActiveMode;
        WhichToTurnOn();
    }
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckIfModeChanged();
	}

    private void CheckIfModeChanged()
    {
        if(currentMode != ActiveMode)
        {
            TurnOffAllComponents();
            WhichToTurnOn();
            currentMode = ActiveMode;
        }
    }

    private void TurnOffAllComponents()
    {
        MonoBehaviour thisMono = gameObject.GetComponent<MiniWallProperties>();
        MonoBehaviour thisMonoTest = gameObject.GetComponent<TestMiniWallProperties>();
        MonoBehaviour[] allComp = gameObject.GetComponents<MonoBehaviour>();
        for(int index = 0; index < allComp.Length; index++)
        {
            if(allComp[index] != thisMono && allComp[index] != thisMonoTest)
            {
                allComp[index].enabled = false;
            }
        }
    }

    private void WhichToTurnOn()
    {
        TurnOffAllComponents();
        switch(ActiveMode)
        {
            case "Default":
                gameObject.GetComponent<MiniFollow>().enabled = true;
                gameObject.GetComponent<TestMiniWallFollow>().enabled = true;
                break;

            case "Direct":
                gameObject.GetComponent<MiniDirect>().enabled = true;
                gameObject.GetComponent<TestMiniDirect>().enabled = true;
                break;

            default:
                break;
        }
    }
}
