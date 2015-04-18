using UnityEngine;
using System.Collections;

public class WallProperties : MonoBehaviour 
{
    public int Clicked;
    public int Clickable;
    public GameObject MiniWall;
	// Use this for initialization
	void Awake () 
    {
        Clickable = 0;
        Clicked = Random.Range(1, 5);
	}

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () 
    {
        DestroyTheWall();
	}

    private void DestroyTheWall()
    {
        if(Clickable == Clicked)
        {
            AssignThingsToSpawn();
            Destroy(gameObject);
        }
    }

    private void AssignThingsToSpawn()
    {
        GameObject mini = Instantiate(MiniWall, transform.position, Quaternion.identity) as GameObject;
        var miniScale = Random.Range(0.1f, 1.3f);
        mini.transform.localScale = new Vector3(miniScale, miniScale, miniScale);
        var minifol = mini.GetComponent<MiniFollow>();
        minifol.Target = GameObject.FindGameObjectWithTag("Player");
        minifol.miniSmoothTime = Random.Range(0.35f, 0.85f);
    }
}
