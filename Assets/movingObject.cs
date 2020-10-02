using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    private bool start = false;
    private RaycastHit hit;
    private Ray ray;
    private bool dragging = false;
    private float distance;
    private GameObject toMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                dragging = true;
                toMove = hit.collider.gameObject;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        if (dragging)
        { 
            distance = Vector3.Distance(toMove.transform.position, Camera.main.transform.position);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            toMove.transform.position = new Vector3(rayPoint.x, toMove.transform.position.y, rayPoint.z);
        }
    }

    public void ClickStart()
    {
        start = !start;
    }
}
