using UnityEngine;
using System.Collections;

public class TestBlocks : MonoBehaviour 
{
    private GameObject[] testBlocks;
    private bool blocksInScene;
    private const string blocksInSceneMessage = "There are no blocks in the scene";

    private bool canDestroyBlocks;
    private const string canDestroyBlocksMessage = "This isn't a block you can destroy";

    private bool isDestroyingBlocks;
    private const string isDestroyingBlocksMessage = "You are not attempting to destoy the block";

    private bool areThereMiniBlocks;
    private const string areThereMiniBlocksMessage = "Yo Where are the minis!!";

    private bool inBlock;
    private int countToDestroy;
    private GameObject toDestroy;

    private int numMiniBlocks;
    private int currMiniBlocks;

    private int totalMinisExpected;
    
	// Use this for initialization
	void Start () 
    {
        totalMinisExpected = 0;
        numMiniBlocks = 0;
        currMiniBlocks = 0;
	    TestBlocksInScene();
        for (int i = 0; i < testBlocks.Length; i++)
        {
            if (testBlocks[i] != null)
            {
                totalMinisExpected += testBlocks[i].GetComponent<DestroyBlock>().NumMiniSpawns;
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(toDestroy == null)
        {
            inBlock = false;
        }
	}

    void LateUpdate()
    {
        TestDestroyingBlocks();
        TestMiniBlocks();
    }


    private void TestBlocksInScene()
    {
        testBlocks = GameObject.FindGameObjectsWithTag("Blocks");
        blocksInScene = testBlocks.Length > 0;
        if(!blocksInScene)
        {
            Debug.LogError(blocksInSceneMessage);
        }
        TestIt.Assert(blocksInScene);
    }

    void OnTriggerEnter(Collider other)
    {
        inBlock = true;
        //test whether you can destroy a block.
        canDestroyBlocks = other.gameObject.tag == "Blocks";
        if (canDestroyBlocks)
        {
            Debug.Log("I can destroy this blocks: " + other.gameObject.name + " " + countToDestroy);
            //test the destroying process.
            toDestroy = other.gameObject;
            countToDestroy = other.gameObject.GetComponent<DestroyBlock>().CurrDeathCount;
        }
        if(!canDestroyBlocks)
        {
            Debug.Log(canDestroyBlocksMessage);
        }
        TestIt.Assert(canDestroyBlocks);

        
    }

    void OnTriggerExit(Collider other)
    {
        inBlock = false;
        if(other.gameObject.tag == "Blocks")
        {
            toDestroy = null;
        }
    }

    void TestDestroyingBlocks()
    {
        if(inBlock && toDestroy)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                int currentDestroy = toDestroy.GetComponent<DestroyBlock>().CurrDeathCount;
                isDestroyingBlocks = currentDestroy > countToDestroy;
                if(!isDestroyingBlocks)
                {
                    Debug.LogError(isDestroyingBlocksMessage);
                }
                TestIt.Assert(isDestroyingBlocks);
                countToDestroy = currentDestroy;
            }
        }
    }

    void TestMiniBlocks()
    {
        numMiniBlocks = totalMinisExpected;
        for(int i = 0; i < testBlocks.Length; i++)
        {
            if(testBlocks[i] != null)
            {
                numMiniBlocks -= testBlocks[i].GetComponent<DestroyBlock>().NumMiniSpawns;
            }
        }
        currMiniBlocks = GameObject.FindGameObjectsWithTag("MiniBlocks").Length;
        //Debug.Log(numMiniBlocks + " " + currMiniBlocks);
        areThereMiniBlocks = numMiniBlocks == currMiniBlocks;
        if (!areThereMiniBlocks)
        {
            Debug.LogError(areThereMiniBlocksMessage);
        }
        TestIt.Assert(areThereMiniBlocks);
    }

}
