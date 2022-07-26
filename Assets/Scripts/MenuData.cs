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
    private int _numOfZombies = 0;
    public int NumOfZombies{
        get{
            return _numOfZombies;
        }
    }

    public void SetValue(int value)
    {
        _numOfZombies = value;
    }

    public int GetValue()
    {
        return _numOfZombies;
    }
}