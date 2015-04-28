using UnityEngine;
using System.Collections;

[RequireComponent(typeof (TestPlayerFire))]
public class PlayerFire : MonoBehaviour 
{
    public GameObject Ammo;
    public Transform SpawnAmmo;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        FireAndSpawnAmmo();
	}

    private void FireAndSpawnAmmo()
    {
        if (PlayerProperties.PlyerModes == PlayerProperties.PlayerModes.Default)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && (PlayerProperties.Minis.Count > 0))
            {
                Instantiate(Ammo, SpawnAmmo.position, transform.GetChild(0).rotation);
            }
        }
    }
}
