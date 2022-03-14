using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class CapsuleRotation : MonoBehaviour
{
    public GameObject VRCam, DummyBody;

    WebXRManager XRManager;
    // Start is called before the first frame update
    void Start()
    {
        XRManager = this.transform.parent.GetComponent<WebXRManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If VR
        if(XRManager.xrState == WebXRState.ENABLED)
        {
            transform.rotation = Quaternion.Euler(0, VRCam.transform.eulerAngles.y, 0);
        } 

        //If PC
        else if (XRManager.xrState == WebXRState.NORMAL)
        {
            //this.transform.parent = DummyBody.transform;
            //this.transform.localPosition = new Vector3(0, 0.6f, -0.5f);
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }
            
    }

}
