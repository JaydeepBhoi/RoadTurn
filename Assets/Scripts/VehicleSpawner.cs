using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    //private Vector2 screenBounds;
    private float respwnTime;

    public List<GameObject> prefabsToPool; // List of GameObjects to pool
    public int poolSize = 10;

    private List<GameObject> objectPool = new List<GameObject>();


    public float MinrespwnTime, MaxrespwnTime;
  //  public GameObject parentObj;
    GameObject obj;

 


    

    public DirectionToMove moveDirectyion;

    private void OnEnable()
    {

       
        respwnTime = Random.Range(MinrespwnTime, MaxrespwnTime);

        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {
            StartCoroutine(carSpawnWave());
            InitializeObjectPool();

            Debug.Log("*********** Hey ************");
        }
    }

    void InitializeObjectPool()
    {
        if (prefabsToPool.Count == 0)
        {
            Debug.LogWarning("No prefabs specified for the object pool.");
            return;
        }

        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {

            for (int i = 0; i < poolSize; i++)
            {
                obj = Instantiate(prefabsToPool[Random.Range(0, prefabsToPool.Count)]);

                obj.transform.position = gameObject.transform.position;
                obj.transform.parent = gameObject.transform;

                if (moveDirectyion == DirectionToMove.Top)
                {
                    obj.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else if (moveDirectyion == DirectionToMove.Down)
                {
                    obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                objectPool.Add(obj);

                obj.SetActive(false);
            }
        }
        
    }


    public GameObject GetPooledObject()
    {
        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {

            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    obj.GetComponent<VehicleLane_Move>().Movevehicles();
                    return obj;
                }
            }
        }
        return null;
    }

    public void Update()
    {
       
    }

    IEnumerator carSpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respwnTime);
            respwnTime = Random.Range(MinrespwnTime, MaxrespwnTime);
            GetPooledObject();
        }
    }
}

public enum DirectionToMove
{
    Top,
    Down
}