using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TestPlayerDirect))]
public class PlayerDirect : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerDirectAction();
	}

    private void PlayerDirectAction()
    {
        if(PlayerProperties.PlyerModes == PlayerProperties.PlayerModes.Direct)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) 
                && (PlayerProperties.Minis.Count > 0))
            {
                GameObject directee = PlayerProperties.Minis.Dequeue();

                //Write a test for this.
                directee.GetComponent<TestMiniWallFollow>().enabled = false;
                directee.GetComponent<MiniFollow>().enabled = false;
            }
        }
    }

}
