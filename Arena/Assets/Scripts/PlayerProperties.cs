using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TestPlayerProperties))]
public class PlayerProperties : MonoBehaviour 
{
    public static Queue<GameObject> Minis;
    public enum PlayerModes
    {
        Default,
        Direct,
        Drop,
        Destroy
    }

    public static PlayerModes PlyerModes;
    public string CurrModeName = "Default";
    private int modeIndex;
	// Use this for initialization

    void Awake()
    {
        Minis = new Queue<GameObject>();
    }
	void Start () 
    {
        modeIndex = 0;
        PlyerModes = (PlayerModes)modeIndex;
        CurrModeName = ModeToString();
        PlyerModes = PlayerModes.Default;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ChangeModes();
	}

    private void ChangeModes()
    {
        if(Input.GetKeyDown(KeyCode.Period))
        {
            modeIndex++;
            modeIndex %= 4;
            PlyerModes = (PlayerModes)modeIndex;
            CurrModeName = ModeToString();
        }
    }

    private string ModeToString()
    {
        string plyer = "";
        switch(PlyerModes)
        {
            case PlayerModes.Default:
                plyer = "Default";
                break;

            case PlayerModes.Direct:
                plyer = "Direct";
                break;

            case PlayerModes.Drop:
                plyer = "Drop";
                break;

            case PlayerModes.Destroy:
                plyer = "Destroy";
                break;
            default:
                plyer = "Default";
                break;
        }
        return plyer;
    }

}
