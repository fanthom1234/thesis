using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkLineBehav : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform from;
    private Transform to;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    } 

    public void SetLinePoints(Transform from, Transform to)
    {
        this.from = from;
        this.to = to;
    }

    private void Update() {
        if (from == null || to == null)
            Destroy(this.gameObject);
            
        lineRenderer.SetPosition(0, from.position);
        lineRenderer.SetPosition(1, to.position);
    }
}
