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
	void Update () 
    {
        FireAndSpawnAmmo();
	}

    private void FireAndSpawnAmmo()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(Ammo, SpawnAmmo.position, transform.GetChild(0).rotation);
        }
    }
}
