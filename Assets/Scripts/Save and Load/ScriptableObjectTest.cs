using UnityEngine;

public class ScriptableObjectTest : MonoBehaviour
{
    public ScriptableObjectSample sample;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!sample)
            return;

        Debug.Log($"My enemy name is {sample.objectName}, the damage value : {sample.damageValue}," + $"starting at : {sample.startPosition},");
    }

    // Update is called once per frame

}
