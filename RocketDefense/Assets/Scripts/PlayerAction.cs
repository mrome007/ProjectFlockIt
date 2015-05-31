using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour 
{
    public GameObject[] Players;
    private float spawnCoolDown = 0.75f;
    private float spawnTimer = 0f;
    public int PlayerIndex = 0;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        SpawnPlayers();
	}

    private void SpawnPlayers()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(spawnTimer <= 0)
            {
                spawnTimer = spawnCoolDown;
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 200f);
                if (Players.Length > 0)
                {
                   Instantiate(Players[PlayerIndex], hit.point, Quaternion.identity);
                }
            }
        }
        spawnTimer = (spawnTimer > 0) ? spawnTimer - Time.deltaTime : 0f;
    }
}
