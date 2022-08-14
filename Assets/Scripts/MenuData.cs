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
    private int _difficulty = 0;
    public int difficulty{
        get{
            return _difficulty;
        }
        set{
            _difficulty = value;
        }
    }
}