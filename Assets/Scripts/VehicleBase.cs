using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleBase : MonoBehaviour
{
    #region Public Varialble

    public Rigidbody2D rb;
    public float posY;




    #endregion

    #region abstract callBacks

    public virtual void carMoveDown()
    {
        if (GameState.GamePlay == GameManager.instance.CurrentState()) {

            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(0, posY);

        }

    }

    public virtual void carMoveUp()
    {
        if (GameState.GamePlay == GameManager.instance.CurrentState())
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 180);
            rb.velocity = new Vector2(0, -posY); // Move down
        }
    }

    public abstract void Movevehicles();

    #endregion
}
