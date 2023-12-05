using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBunch_Move : VehicleBase
{

    private Camera mainCamera;

    float cameraHalfHeight;
    float cameraPosY;

    public Vehicle_Pointer pointer;

    public float startTime;

    public bool isJourneyComplete;

    public int countCar_SqMove;

    public int carData;

    public LayerMask carReleaseLayer;

    public int newLayerIndex = 9;

    private void OnEnable()
    {
       InputHandler.LvlComplete += CompleteLevel;
    }
    private void OnDisable()
    {
      InputHandler.LvlComplete -= CompleteLevel;

        //if (Vehicle_Pointer.totalCarsData == 0)
        //{
        //   Invoke("LevelCompleteInvokeCall", 1.8f);
        //}
        //pointer.counterCarDicable--;
        //Debug.Log("Hey___" + pointer.counterCarDicable);
    }

   public void LevelCompleteInvokeCall()
    {
        
            InputHandler.LvlComplete?.Invoke();
        
    }


   

    private void Start()
    {
        pointer = transform.GetComponentInParent<Vehicle_Pointer>();
        countCar_SqMove = 0;

      
    }


    private void Update()
    {
        CarDisable();
    }


    public void MoveCurve()
    {
        StartCoroutine(MoveAlongBezierCurve(gameObject, VehiclePointes_Manager.instance.countBzireCurve));
   
    }

    public override void carMoveDown()
    {
        base.carMoveDown();
    }

    public override void carMoveUp()
    {
        base.carMoveUp();
    }

    public override void Movevehicles()
    { 
        if (pointer.directionToMove == DirectionToMove.Top)
        {
            carMoveUp();
        }
        else if (pointer.directionToMove == DirectionToMove.Down)
        {
            carMoveDown();
        }
       
    }

   public void stopCar() {
        InputHandler.isInput = false;

        gameObject.layer = newLayerIndex;
     }


    public IEnumerator MoveAlongBezierCurve(GameObject player, int curveIndex)
    {
        InputHandler.isInput = true;
        startTime = Time.time;
        Transform startPoint = LevelDataHandler.instance.bezierCurve.startPoints[curveIndex];
        Transform endPoint = LevelDataHandler.instance.bezierCurve.endPoints[curveIndex];
        Transform controlPoint = LevelDataHandler.instance.bezierCurve.controlPoints[curveIndex];
        while (!isJourneyComplete)
        {
            float distanceCovered = (Time.time - startTime) * LevelDataHandler.instance.bezierCurve.speed;
            float fractionOfJourney = distanceCovered / LevelDataHandler.instance.bezierCurve.journeyLength;

            Vector3 position = LevelDataHandler.instance.bezierCurve.CalculateBezierPoint(startPoint, endPoint, controlPoint, fractionOfJourney);
            player.transform.position = position;

            Vector3 tangent = LevelDataHandler.instance.bezierCurve.CalculateBezierTangent(startPoint, endPoint, controlPoint, fractionOfJourney);


            //  float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg - 90f;

            float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg - 90f;

            player.transform.rotation = Quaternion.Euler(0, 0, angle);
           
            yield return null;

            if (fractionOfJourney > LevelDataHandler.instance.bezierCurve.RotateCurveTime)
            {
                isJourneyComplete = true;
               
                Invoke("stopCar", 0.2f);

              //  lvlComplete();



            }
        }

        player.transform.position = endPoint.position;

        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {
            LevelManage.instance.LevelProgressSlider(Vehicle_Pointer.totalCarsData);
        }

        if(LevelManage.instance.slider.value >= 0.99f)
        {
           
            Invoke("LevelCompleteInvokeCall", 2f);
            Debug.Log("Hi........Hi" + Vehicle_Pointer.totalCarsData);
        }
       
        Movevehicles();

        countCar_SqMove++;

        
   

    }
  
    public void CompleteLevel()
    {
        Vehicle_Pointer.totalCarsData = 0;
        LevelManage.instance.slider.value = 0;
        GameManager.instance.StateManage(GameState.LevelComplete);
        ScreenManager.instance.ShowNextScreen(ScreenType.LevelComplete);
    }

    public void CarDisable() {

          float cameraMinHeight;
          float cameraMaxHeight;
          mainCamera = Camera.main;

         cameraHalfHeight = mainCamera.orthographicSize;
         cameraPosY = mainCamera.transform.position.y;
         cameraMinHeight = cameraPosY - cameraHalfHeight;
         cameraMaxHeight = cameraPosY + cameraHalfHeight;

     
       if (gameObject.transform.position.y < cameraMinHeight || gameObject.transform.position.y > cameraMaxHeight && gameObject.layer== carReleaseLayer)
        {
            
            gameObject.SetActive(false);
           
        }
        
    }

}
