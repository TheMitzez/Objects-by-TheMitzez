using UnityEngine;

[CreateAssetMenu(fileName = "DataSample", menuName = "CircuitStream/Feb25Bootcamp/Create Scriptable Asset", order = 1)]
public class ScriptableObjectSample : ScriptableObject
{
    public string objectName;
    public string score;
    public Vector2 startPosition;
    public int damageValue;

}
