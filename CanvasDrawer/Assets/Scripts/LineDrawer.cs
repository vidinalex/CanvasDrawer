using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameManag manager;
    [SerializeField] private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    private float widthMax, heightMax;

    private void Start()
    {
        widthMax = manager.GetWidthMax();
        heightMax = manager.GetHeightMax();
    }
    void Update()
    {
        if (Input.touchCount == 0) return;

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (Input.GetTouch(0).position.y < heightMax)
            points.Add(Input.GetTouch(0).position);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            manager.CalcDiff(points.ToArray());
            manager.StartMovement();
            points.Clear();            
        }
        SetUpLine();
    }

    private void SetUpLine()
    {
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
