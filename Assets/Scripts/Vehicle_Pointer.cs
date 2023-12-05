using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Vehicle_Pointer : MonoBehaviour
     {

    //public static CarPointer instance;
        #region PrivateVariables
        [SerializeField]
        int randomObj;
        [SerializeField]
        float spacing;
    float dataCar;

         float degreeOfCarBunch;
         Vector3 directionCarBunch;
       // public Direction direction;
        #endregion


        #region PublicVariables
        public List<GameObject> totalCars;
        public List<GameObject> carBunchList;
        public Direction direction;
        public DirectionToMove directionToMove;
        public GameObject childDirection;
         public static float totalCarsData;
         public int counterCarDicable;
    #endregion


    #region Unity Callbacks




    void Start()
    {
        randomObj = Random.Range(2, totalCars.Count);

        if (direction == Direction.Left)
        {
            directionCarBunch = new(1, 0, 0);
            degreeOfCarBunch = 90f;
        }
        else if (direction == Direction.Right)
        {
            directionCarBunch = new(-1, 0, 0);
            degreeOfCarBunch = -90f;
        }

        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {

            // generateCarBunch();

            Invoke("generateCarBunch", 1f);
           
        }
        
    }


    #endregion

    #region Custom Methods

    public void bunchListCount()
    {
        for(int i=0;i<= carBunchList.Count; i++)
        {
            dataCar++;
        }
    }

    public void generateCarBunch()
        {

            for (int i = 0; i < randomObj; i++)
            {
                Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f,degreeOfCarBunch));
                Vector3 spawnPoint = gameObject.transform.position + directionCarBunch * i * spacing;
                GameObject carBunch = Instantiate(totalCars[i], spawnPoint, rotation);
                carBunch.transform.position = new Vector3(spawnPoint.x+1f, gameObject.transform.position.y, gameObject.transform.position.z);
                carBunch.transform.parent = gameObject.transform;
                carBunchList.Add(carBunch);

                totalCarsData++;
          
        }

          counterCarDicable = (int)totalCarsData;
       

    }
}

     


        #endregion
    


public enum Direction
{
    Right,
    Left
}


