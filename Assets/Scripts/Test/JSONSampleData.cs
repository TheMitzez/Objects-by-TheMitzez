using UnityEngine;

public class JSONSampleData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SampleData sampleData = new SampleData();

        sampleData.name = "Lizzy";

        sampleData.address = new Address();
        sampleData.address.unit = 5;
        sampleData.address.road = "2nd Avenue";
        sampleData.address.city = "New York";

        sampleData.books = new Book[2];
        sampleData.books[0] = new Book();
        sampleData.books[0].bookName = "Programming in C#";
        sampleData.books[0].author = "Zee Zee";
        sampleData.books[0].isDigital = true;

        sampleData.books[1] = new Book();
        sampleData.books[1].bookName = "Intro to Unity";
        sampleData.books[1].author = "Adewale Johnson";
        sampleData.books[1].isDigital = false;

        string data = JsonUtility.ToJson(sampleData, true);
        Debug.Log(data);
    }
}
