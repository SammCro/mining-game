using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;

    [SerializeField] private Transform StartPosition;

    private float lineWidth = 0.05f;


    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;

    }

    void Start()
    {
        
    }

    public void RenderLine(Vector3 endposition, bool RenderEnabled)
    {
        if (RenderEnabled)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }

            lineRenderer.positionCount = 2;
        }
        else
        {

            lineRenderer.positionCount = 0;

            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        if (lineRenderer.enabled)
        {
            Vector3 temp = StartPosition.position;
            temp.z = -10f;

            StartPosition.position = temp;

            temp = endposition;
            temp.z = 0f;

            endposition = temp;

            lineRenderer.SetPosition(0,StartPosition.position);
            lineRenderer.SetPosition(1,endposition);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
