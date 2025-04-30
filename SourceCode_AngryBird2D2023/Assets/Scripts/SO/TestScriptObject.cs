using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TestScriptObject : ScriptableObject
{
    public new string name;
    public int level;

    public int[] levelData;
    public int[] levelData2= {10 };

    public int[,] mapData;
}
