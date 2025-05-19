using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public GameObject testPrefab;
    public List<GameObject> objList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tempObj;

        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(0, 0);
        objList.Add(tempObj);

        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(1, 0);
        objList.Add(tempObj);

        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(2, 0);
        objList.Add(tempObj);

        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(3, 0);
        objList.Add(tempObj);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            objList[Random.Range(0, objList.Count)].GetComponent<SpriteRenderer>().material.color = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject tempObj;
            tempObj = Instantiate(testPrefab, transform);
            tempObj.transform.position = new Vector2(objList[objList.Count - 1].transform.position.x + 1, 0);
            objList.Add(tempObj);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Destroy(objList[Random.Range(0, objList.Count)].gameObject);
            Debug.Log(objList[0].name);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Destroy(objList[0].gameObject);
            objList.RemoveAt(0);
        }
    }
}
