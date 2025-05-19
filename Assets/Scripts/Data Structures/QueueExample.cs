using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    public GameObject testPrefab;
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    GameObject tempObj;
    Vector2 lastEnqueuePosition = Vector2.zero; 

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
            tempObj.transform.position = new Vector2(lastEnqueuePosition.x +1, 0);

            tempObj.name = "QUEUE - " + objQueue.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            objQueue.Enqueue(tempObj);
            lastEnqueuePosition = tempObj.transform.position;
            Debug.Log("Pushed" + tempObj.name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = objQueue.Dequeue();
            Destroy(removedObj);
            Debug.Log("Dequeued from the queue" + removedObj.name);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Object at the start of the queue is" + objQueue.Peek().name);
        }
    }
}
