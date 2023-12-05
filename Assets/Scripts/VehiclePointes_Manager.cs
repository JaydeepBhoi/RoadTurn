using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePointes_Manager : MonoBehaviour
{
    #region PrivateVariables
    
     
    GameObject firstObject;

    private GameObject carObj;
    public  int countBzireCurve=0;
    int countBunch;
    private Vector2 screenBounds;
    private bool isCarEnabled=false;
   
    Vector3 newPos;

    #endregion


    #region PublicVariables

   // public List<GameObject> pointsList;
    
    public List<Vehicle_Pointer> pointsListOBJ = new List<Vehicle_Pointer>();
    public List<Vector3> OldcarPos;
    public float carBizirecurve;
    public static float  totalCarsData=0;

    public BezierCurve curveHandler;
   public float dataCar;
    public static VehiclePointes_Manager instance;

    public bool isCameraMove=false;
 
    public float result;
    public GameObject CameraPointLeft,CameraPointRight;

    int countPointers=0;
   
    #endregion

    Vector3 curentPos;

    #region Unity Callbacks
  

    private void OnEnable()
    {
        InputHandler.inputForCarMove += startCar;
    }

    private void OnDisable()
    {
        InputHandler.inputForCarMove -= startCar;
    }

    void Start()
    {
        instance = this;
       


        Invoke("MoveCamera", 2f);

    }
    public void MoveCamera()
    {
      CameraMove.instance.MoveToNewPosition(CameraPointRight, CameraPointLeft, pointsListOBJ[0].gameObject, pointsListOBJ[0].direction);
    }

    public void ComonCameraCall()
    {
      
        countPointers++;

        
        if (countPointers < pointsListOBJ.Count)
        {
            CameraMove.instance.MoveToNewPosition(CameraPointRight, CameraPointLeft, pointsListOBJ[countPointers].gameObject, pointsListOBJ[countPointers].direction);
        }
       

    }

   

    public void startCar()
    {
        
        for (int i = 0; i < pointsListOBJ.Count;i++)
        {
            countBzireCurve = i;

            Debug.Log("CountData" + countBzireCurve);


             if (pointsListOBJ[i].carBunchList.Count > 0 && pointsListOBJ[i].carBunchList !=null)
            {
               

                for (int j = 0; j < pointsListOBJ[i].carBunchList.Count; j++)
                {
                    curentPos = pointsListOBJ[i].carBunchList[j].transform.position;
                    OldcarPos.Add(curentPos);
               }
               
                
                firstObject = pointsListOBJ[i].carBunchList[0];
                pointsListOBJ[i].carBunchList[0].GetComponent<VehicleBunch_Move>().MoveCurve();
           
              
                pointsListOBJ[i].carBunchList.RemoveAt(0);
                StartCoroutine(MovecarSequence());

                firstObject = null;
              
               if (pointsListOBJ[i].carBunchList.Count == 0)
                {
                     ComonCameraCall();
                }

                break;
            
            }

        
        }
        Debug.Log("Couter===== " + countBzireCurve);
    }


    IEnumerator MovecarSequence()
    {
        yield return new WaitForSeconds(0.1f);

        float duration = 0.05f; // Adjust the duration as needed

        for (int j = 0; j < pointsListOBJ[countBzireCurve].carBunchList.Count; j++)
        {
            Vector3 initialPosition = pointsListOBJ[countBzireCurve].carBunchList[j].transform.position;
            Vector3 targetPosition = OldcarPos[j];

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
               
                float t = elapsedTime / duration;
                pointsListOBJ[countBzireCurve].carBunchList[j].transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
          
           

            if (elapsedTime >= duration)
            {
              
            }
        
            pointsListOBJ[countBzireCurve].carBunchList[j].transform.position = targetPosition;
        }

        OldcarPos.Clear();

    }



    #endregion

    #region Custom Methods

    #endregion
}
