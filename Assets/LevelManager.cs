using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public LevelSo levelSo;
    public static int targetLevelNumber;
    private GameObject levelPrefab;
    private void Start()
    {
        targetLevelNumber = 2;
    }



    public void LoadLevelPrefab()
    {
        Debug.Log("Hi");

        LevelsClass level = levelSo.levelsDataList[targetLevelNumber];

        Debug.Log(level);

        if (levelPrefab != null)
        {
            Destroy(levelPrefab);

        }

        levelPrefab = Instantiate(level.LevelsObj);

        Invoke("isFalse", 0.2f);
    }
    
    public void isFalse() {
        levelPrefab.SetActive(false);
        levelPrefab.SetActive(true);
    }

}
