using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public delegate void InputForCarMove();
   // public delegate void LevelCompleted();

    public static InputForCarMove inputForCarMove;
  //  public static LevelCompleted levelCompleted;


    

     public static Action LvlComplete;



    public static bool isInput = false;


    private void Start()
    {
       
    }

    void Update()
    {
        if (GameState.GamePlay == GameManager.instance.CurrentState() && !isInput)
        {

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                inputForCarMove();

            }
           
        }


       

    }



   
}
