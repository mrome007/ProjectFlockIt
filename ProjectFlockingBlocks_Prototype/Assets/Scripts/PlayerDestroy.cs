using UnityEngine;
using System.Collections;

public class PlayerDestroy : MonoBehaviour 
{
    private bool inBlock;
    private GameObject blockToDestroy;

    void Update()
    {
        DestroyBlock();
        if(blockToDestroy == null)
        {
            inBlock = false;
        }
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Blocks")
        {
            inBlock = true;
            blockToDestroy = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Blocks")
        {
            inBlock = false;
            blockToDestroy = null;
        }
    }

    void DestroyBlock()
    {
        if(inBlock && blockToDestroy)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                blockToDestroy.GetComponent<DestroyBlock>().CurrDeathCount++;
            }
        }
    }

}
