using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour 
{
    public int CurrDeathCount;
    private int DeathCount;
    private bool blockAlive;
    public GameObject MiniBlockObject;
	// Use this for initialization
	void Start () 
    {
        CurrDeathCount = 0;
        DeathCount = Random.Range(2, 5);
        blockAlive = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckDeath();
	}

    void CheckDeath()
    {
        if(blockAlive)
        {
            if(CurrDeathCount > DeathCount)
            {
                blockAlive = false;
                Destroy(gameObject);
                SpawnMiniBlock();
            }
        }
    }

    void SpawnMiniBlock()
    {
        GameObject mini = (GameObject)Instantiate(MiniBlockObject, 
                           new Vector3(1.0f, -0.5f, Random.Range(-20f, 20f)), 
                           Quaternion.identity);
        float range = Random.Range(0.1f,2.0f);
        mini.transform.localScale = new Vector3(range, range, range);
    }
}
