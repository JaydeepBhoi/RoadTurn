using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleLane_Move : VehicleBase
{
    #region Variables
    public VehicleSpawner carSpawn;
    #endregion

    #region Unity Callbacks
    private void OnEnable()
    {

        carSpawn = transform.GetComponentInParent<VehicleSpawner>();
    }
    #endregion

    #region Public Methods
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

        if (carSpawn.moveDirectyion == DirectionToMove.Top)
        {
            carMoveUp();
        }
        else if (carSpawn.moveDirectyion == DirectionToMove.Down)
        {
            carMoveDown();
        }
    }
    #endregion

    #region Collision Handling
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.GetComponent<VehicleBunch_Move>() != null)
        {
            GameOver();
        }
    }


    public void GameOver() {


        GameManager.instance.StateManage(GameState.GameOver);
        ScreenManager.instance.ShowNextScreen(ScreenType.GameOverScreen);
        Vehicle_Pointer.totalCarsData = 0;

    }


    #endregion
}
