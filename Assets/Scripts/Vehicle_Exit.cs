
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vehicle_Exit : MonoBehaviour
{
  
    #region PrivateVariables
    [SerializeField]

    private Transform initialPosition;
    #endregion
    int carCount;

    #region PublicVariables
    public LayerMask carLayer;
    #endregion


    #region Unity Callbacks
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & carLayer) != 0)
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = initialPosition.position;
        }
    }
}
#endregion

#region Custom Methods
// Define your custom methods here
#endregion