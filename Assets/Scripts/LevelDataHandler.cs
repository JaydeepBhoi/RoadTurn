using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    public static LevelDataHandler instance;
    public BezierCurve bezierCurve;
    public LevelManager levelManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    
}
