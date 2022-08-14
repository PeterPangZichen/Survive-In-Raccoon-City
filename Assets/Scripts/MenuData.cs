using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuData", menuName = "ScriptableObjects/MenuData", order = 2)]
public class MenuData : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    // Difficulty
    public int difficulty = 0;

    // Level pass
    public bool[] levelPass = new bool[]{true, false, false, false, false};
}