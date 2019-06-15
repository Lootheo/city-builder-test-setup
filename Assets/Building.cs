using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resource {Gold, Wood, Steel }
[System.Serializable]
public class Cost
{
    public Resource Resource;
    public int Amount;
}
public class Building : MonoBehaviour
{
    public List<Cost> Costs;
    public string Name = "PlaceholderName";
    public Vector2Int Size;
}
