using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class UIPanelFollowCamera : MonoBehaviour
{
    public Camera _Camera, CameraVR, CameraPC;
    public Vector3 Offset;
    public float Smooth;
    public WebXRManager XRManager;
    private void Awake()
    {
        //If VR
        if(XRManager.xrState == WebXRState.ENABLED)
        {
            _Camera = CameraVR;
        }

        //if pc
        else if (XRManager.xrState == WebXRState.NORMAL)
        {
            _Camera = CameraPC;
        }

        if (GetComponent<Canvas>() != null)
        {
            //GetComponent<Canvas>().worldCamera = Camera.main;
            GetComponent<Canvas>().worldCamera = _Camera;
        }
        //_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if VR
        if(XRManager.xrState == WebXRState.ENABLED)
        {
            transform.position = Vector3.Lerp(transform.position, _Camera.transform.position + _Camera.transform.forward * Offset.z + _Camera.transform.right * Offset.x + _Camera.transform.up * Offset.y, Time.deltaTime * Smooth);
        }

        //if PC
        else
        {
            transform.position = Vector3.Lerp(transform.position, _Camera.transform.position + _Camera.transform.forward * 0.3f + _Camera.transform.right * Offset.x + _Camera.transform.up * Offset.y, Time.deltaTime * Smooth);
        }
        transform.rotation = Quaternion.Euler(_Camera.transform.eulerAngles.x, _Camera.transform.eulerAngles.y, 0);
    }

}
