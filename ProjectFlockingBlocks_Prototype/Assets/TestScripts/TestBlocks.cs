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
	// Use this for initialization
	void Start () 
    {
        numMiniBlocks = 0;
        currMiniBlocks = 0;
	    TestBlocksInScene();
	}
	
	// Update is called once per frame
	void Update () 
    {
        TestDestroyingBlocks();
        if(toDestroy == null)
        {
            inBlock = false;
        }
	}

    void LateUpdate()
    {
        TestMiniBlocks();
    }


    private void TestBlocksInScene()
    {
        testBlocks = GameObject.FindGameObjectsWithTag("Blocks");
        blocksInScene = testBlocks.Length > 0;
        TestIt.Assert(blocksInScene, blocksInSceneMessage);
    }

    void OnTriggerEnter(Collider other)
    {
        inBlock = true;
        //test whether you can destroy a block.
        canDestroyBlocks = other.gameObject.tag == "Blocks";
        if (canDestroyBlocks)
        {
            //test the destroying process.
            toDestroy = other.gameObject;
            countToDestroy = other.gameObject.GetComponent<DestroyBlock>().CurrDeathCount;
            Debug.Log("I can destroy this blocks: " + other.gameObject.name);
        }
        TestIt.Assert(canDestroyBlocks, canDestroyBlocksMessage);

        
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
                TestIt.Assert(isDestroyingBlocks, isDestroyingBlocksMessage);
                countToDestroy = currentDestroy;
            }
        }
    }

    void TestMiniBlocks()
    {
        numMiniBlocks = 0;
        for(int i = 0; i < testBlocks.Length; i++)
        {
            if(testBlocks[i] == null)
            {
                numMiniBlocks++;
            }
        }
        currMiniBlocks = GameObject.FindGameObjectsWithTag("MiniBlocks").Length;
        areThereMiniBlocks = numMiniBlocks == currMiniBlocks;
        TestIt.Assert(areThereMiniBlocks, areThereMiniBlocksMessage);
    }

}
