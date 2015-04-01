using UnityEngine;
using System.Collections;

public class TestCanDestroyBlocks : MonoBehaviour 
{
    private bool inBlock;
    private bool canDestroyBlocks;
    private const string canDestroyBlocksMessage = "This isn't a block you can destroy";


	void OnTriggerEnter(Collider other)
    {
        inBlock = true;
        canDestroyBlocks = other.gameObject.tag == "Blocks";
        if(canDestroyBlocks)
        {
            Debug.Log("I can destroy this blocks: " + other.gameObject.name);
        }
        TestIt.Assert(canDestroyBlocks, canDestroyBlocksMessage);
    }

    void OnTriggerExit(Collider other)
    {
        inBlock = false;
    }

    void Update()
    {

    }
}
