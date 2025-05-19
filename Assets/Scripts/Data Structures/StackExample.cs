using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    public GameObject testPrefab;
    public Stack<GameObject> objStack = new Stack<GameObject>();

    GameObject tempObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(testPrefab, transform);
            tempObj.transform.position = new Vector2(0, objStack.Count);

            tempObj.name = "STACKED - " + objStack.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            objStack.Push(tempObj);
            Debug.Log("Pushed" + tempObj.name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = objStack.Pop();
            Destroy(removedObj);
            Debug.Log("Popped from the stack" + removedObj.name);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Object at the top of the stack is"  + objStack.Peek().name);
        }
    }
}
