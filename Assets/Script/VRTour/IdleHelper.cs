using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class IdleHelper : MonoBehaviour
{
    public GameObject HintCanvas, controller;

    public float idleTime = 0, maxIdle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;

        if(idleTime > maxIdle) {
            HintCanvas.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        }

        else
        {
            HintCanvas.transform.localScale = new Vector3(0, 0, 0);
        }

    }
}
