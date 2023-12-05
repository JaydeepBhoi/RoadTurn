using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BezierCurve : MonoBehaviour
{
    public List<Transform> startPoints;
    public List<Transform> endPoints;
    public List<Transform> controlPoints;
    public float RotateCurveTime;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;

    public Vector3 CalculateBezierPoint(Transform startPoint, Transform endPoint, Transform controlPoint, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * startPoint.position; // (1-t)^3 * P0
        p += 3 * uu * t * controlPoint.position; // 3 * (1-t)^2 * t * P1
        p += 3 * u * tt * endPoint.position; // 3 * (1-t) * t^2 * P2
        p += ttt * endPoint.position; // t^3 * P3

        return p;
    }

    public Vector3 CalculateBezierTangent(Transform startPoint, Transform endPoint, Transform controlPoint, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 tangent = -3 * uu * startPoint.position +
            (3 * uu - 6 * u * t) * controlPoint.position +
            (6 * u * t - 3 * tt) * endPoint.position +
            3 * tt * endPoint.position;

        return tangent.normalized;
    }
}
