using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour 
{
    private GameObject thePlayer;
    public int CurrDeathCount;
    private int deathCount;
    public int NumMiniSpawns;
    private bool blockAlive;
    public GameObject MiniBlockObject;

    void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }
	// Use this for initialization
	void Start () 
    {
        NumMiniSpawns = Random.Range(1,4);
        CurrDeathCount = 0;
        deathCount = Random.Range(2, 5);
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
            if(CurrDeathCount > deathCount)
            {
                blockAlive = false;
                Destroy(gameObject);
                SpawnMiniBlock();
            }
        }
    }

    void SpawnMiniBlock()
    {
        for (int i = 0; i < NumMiniSpawns; i++)
        {
            GameObject mini = (GameObject)Instantiate(MiniBlockObject,
                               new Vector3(Random.Range(-1.0f, 1.0f), -0.5f, Random.Range(transform.position.z - 3.0f, transform.position.z + 3.0f)),
                               Quaternion.identity);
            mini.transform.parent = thePlayer.transform;
            mini.GetComponent<ContinueFollow>().Target = thePlayer;
            float range = Random.Range(0.25f, 0.75f);
            mini.transform.localScale = new Vector3(range, range, range);
        }
    }
}
