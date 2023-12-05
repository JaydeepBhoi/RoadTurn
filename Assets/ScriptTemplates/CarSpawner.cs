using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    #region PrivateVariables

    private Vector2 screenBounds;
    private float respwnTime;

    #endregion


    #region PublicVariables

    public GameObject CarPrefab;
    public float MinrespwnTime, MaxrespwnTime;
    public GameObject parentObj;

    public List<GameObject> prefabArray;

    #endregion


    #region Unity Callbacks

    void Start()
    {
        respwnTime = Random.Range(MinrespwnTime, MaxrespwnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(carSpawnWave());
    }

    #endregion

    #region Custom Methods

    private void spawnCars()
    {
        int initialObj = Random.Range(0, prefabArray.Count);
        GameObject Obj= Instantiate(prefabArray[initialObj]) as GameObject;
        Obj.transform.position = new Vector2(1f, (screenBounds.y-2f) * -2);
        Obj.transform.parent=parentObj.transform;
    }

    
    IEnumerator carSpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respwnTime);
            respwnTime = Random.Range(MinrespwnTime, MaxrespwnTime);
            spawnCars();
        }
    }
    #endregion
}


