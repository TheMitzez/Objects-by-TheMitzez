using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    //public int studentNumber;
    //public int[] studentScore;
    public GameObject testPrefab;
      
    public GameObject[] objArray = new GameObject[2];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //studentNumber = 15;
        //studentScore = new int[studentNumber]
        objArray[0] = Instantiate(testPrefab, transform);
        objArray[0].transform.position = new Vector2 (0, 0);

        objArray[1] = Instantiate(testPrefab, new Vector2(1,0), Quaternion.identity, transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            objArray[Random.Range(0, objArray.Length)].GetComponent<SpriteRenderer>().material.color = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Destroy(objArray[0].gameObject);
            Debug.Log(objArray[0].name);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            objArray[0] = Instantiate(testPrefab, transform);
            objArray[0].transform.position = new Vector2(0, 0);
        }
    }
}
