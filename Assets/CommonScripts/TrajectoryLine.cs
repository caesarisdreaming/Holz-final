using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer Lr;

    private void Awake()
    {
        Lr.GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint,Vector3 endPoint)
    {
        Lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        Lr.SetPositions(points);
    }

    public void EndLine()
    {
        Lr.positionCount = 0;
    }
}
