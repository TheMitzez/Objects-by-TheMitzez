using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTriangle, txtSquare, txtCircle;
    public Dictionary<string, int>  objDictionary = new Dictionary<string, int>();

    public string checkForValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objDictionary.Add("Triangles", 0);
        objDictionary.Add("Squares", 0);
        objDictionary.Add("Circles", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (objDictionary.ContainsKey("Triangles"))
            {
                objDictionary["Triangles"]++;
                txtTriangle.text = objDictionary["Triangles"].ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (objDictionary.ContainsKey("Squares"))
            {
                objDictionary["Squares"]++;
                txtSquare.text = objDictionary["Squares"].ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (objDictionary.ContainsKey("Circles"))
            {
                objDictionary["Circles"]++;
                txtCircle.text = objDictionary["Circles"].ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            int val = 0;
            bool hasKey = objDictionary.TryGetValue(checkForValue, out val);
            Debug.Log(checkForValue + ":" + hasKey + " - " + val);
        }
    }
}
