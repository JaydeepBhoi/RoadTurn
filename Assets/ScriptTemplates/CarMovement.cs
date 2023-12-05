using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    #region PrivateVariables

    [SerializeField]
    int[] randomObj;

    public int numberOfObjects = 5;   // Number of objects to spawn
    public float spacing = 2.0f;     // Spacing between objects
    public Vector3 spawnPosition;

    public GameObject parentObj;
    #endregion


    #region PublicVariables



    //public List<GameObject> Carbunch;
    public List<GameObject> CarSpawnPoints;
    public List<Transform> CarbunchPos;
    public List<GameObject> totalCars;


   

    #endregion

    #region Unity Callbacks
    void Start()
    {

        randomObj = new int[CarSpawnPoints.Count];
      //  listOfLists.Clear();


        for (int i = 0; i < CarSpawnPoints.Count; i++)
        {
            randomObj[i] = Random.Range(2, totalCars.Count);

        }

        //foreach (int size in randomObj)
        //{
        //    newList = new MyCustomList();
        //    for (int i = 0; i < size; i++)
        //    {
        //        newList.myList.Add(totalCars[i]); 
        //    }
        //    listOfLists.Add(newList);
        //}


        generateData();
    }

    void Update()
    {
        // Update code here
    }
    #endregion

    #region Custom Methods

    public void generateData()
    {

         foreach (int size in randomObj)
        {
            Debug.Log(size);
            
            for (int i = 0; i < size; i++)
            {

                Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));


                GameObject carBunch = Instantiate(totalCars[i], new Vector3(0, 0, 0), rotation);
                Vector3 spawnPoint = spawnPosition + Vector3.right * i * spacing;
                for (int j = 0; j < CarSpawnPoints.Count; j++)
                {
                    Debug.Log(CarSpawnPoints[j].transform.position);

                    // carBunch.transform.position = new Vector3(spawnPoint.x + CarSpawnPoints[j].transform.position.x, CarSpawnPoints[j].transform.position.y, CarSpawnPoints[j].transform.position.z);
                    //  carBunch.transform.position = new Vector3(spawnPoint.x + CarSpawnPoints[j].transform.position.x, CarSpawnPoints[j].transform.position.y, CarSpawnPoints[j].transform.position.z);
                    // carBunch.transform.parent[j] = CarSpawnPoints[j].transform;

                    carBunch.transform.parent = CarSpawnPoints[j].transform;
                }

              //  newList.myList.Add(carBunch);
            }
         //   listOfLists.Add(newList);




        }

    }



  
    #endregion

}




