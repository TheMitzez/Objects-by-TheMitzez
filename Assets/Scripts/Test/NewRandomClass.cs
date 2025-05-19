using UnityEngine;

public class NewRandomClass : MonoBehaviour
{
    public static int rndNum = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rndNum++;
        Debug.Log($"Random number = {rndNum}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
