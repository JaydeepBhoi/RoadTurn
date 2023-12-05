using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSo", menuName = "LevelsMenu")]
public class LevelSo : ScriptableObject
{
    //  Levels levels=new ();

    public List<LevelsClass> levelsDataList;
}

[Serializable]
public class LevelsClass
{
    public int levelNumber;
    public GameObject LevelsObj;
}