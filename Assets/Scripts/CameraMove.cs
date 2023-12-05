using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;  
    public float smoothness = 4.0f; 
    int countMove;
    public static CameraMove instance;
    public bool isFirst=false;

    public List<GameObject> lenesPos;
    private void Start()
    {
        instance = this;
        
    }

    public void MoveToNewPosition(GameObject ObjPosXRight, GameObject ObjPosXLeft, GameObject target, Direction direction)
    {
       
        StartCoroutine(MoveCameraCoroutine(ObjPosXRight, ObjPosXLeft, target, direction));
    }

    public void setLnsPos(DirectionToMove direction,GameObject lens)
    {

       

            if (DirectionToMove.Top == direction)
            lens.transform.position = new Vector3(lens.transform.position.x, transform.position.y+5.5f, lens.transform.position.z);
            else if (DirectionToMove.Down == direction)
            lens.transform.position = new Vector3(lens.transform.position.x, transform.position.y-5.5f, lens.transform.position.z);

    }


    public void UserInput() {

        InputHandler.isInput = false;
       

    }

    private IEnumerator MoveCameraCoroutine(GameObject ObjPosXRight, GameObject ObjPosXLeft, GameObject target, Direction direction)
    {

        InputHandler.isInput = true;

        float elapsedTime = 0f;

        while (elapsedTime < smoothness)
        {
            if (Direction.Left == direction)
                transform.position = Vector3.Lerp(transform.position, new Vector3(ObjPosXLeft.transform.position.x, target.transform.position.y, -10), Time.deltaTime * smoothness);
            else if (Direction.Right == direction)
                transform.position = Vector3.Lerp(transform.position, new Vector3(ObjPosXRight.transform.position.x, target.transform.position.y, -10), Time.deltaTime * smoothness);

            elapsedTime += Time.deltaTime * smoothness;

         

            yield return null;
           
        }

        if(elapsedTime >= smoothness)
        {
            Invoke("UserInput", 0.2f);
        }
    
    }


}
