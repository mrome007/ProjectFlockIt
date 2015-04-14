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
        if(Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(Ammo, SpawnAmmo.position, Quaternion.identity);
        }
    }
}
