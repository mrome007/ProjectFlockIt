using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    public float CameraSpeed;
    private Vector3 moveBy;

    private float firstPress;
    private float secondPress;

	// Use this for initialization
	void Start () 
    {
        moveBy = Vector3.zero;
        firstPress = 0f;
        secondPress = 0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        SwipeToMove();
	}

    private void SwipeToMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            moveBy = Vector3.zero;
            firstPress = Input.mousePosition.y;
        }
        if(Input.GetMouseButton(0))
        {
            secondPress = Input.mousePosition.y;
            float direction = ((secondPress - firstPress) != 0) ? Mathf.Sign(secondPress - firstPress) : 0f;
            moveBy.y = direction * CameraSpeed * Time.deltaTime;
        }
        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine("StallUp");
            Debug.Log("hello");
        }
        transform.Translate(moveBy);
    }

    private IEnumerator StallUp()
    {
        yield return new WaitForSeconds(0.5f);
        moveBy = Vector3.zero;
    }
}
