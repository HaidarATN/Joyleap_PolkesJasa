using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class KepalaTaskObject : MonoBehaviour
{
    public GameObject DummyBody, VRParent;
    public WebXRManager XRManager;
    // Start is called before the first frame update
    void Start()
    {
        //XRManager = this.transform.parent.GetComponent<WebXRManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ////If VR
        //if (XRManager.xrState == WebXRState.ENABLED)
        //{
        //    this.transform.parent = VRParent.transform;
        //    this.transform.localPosition = new Vector3(0, 0, 0);
        //}

        ////If PC
        //else if (XRManager.xrState == WebXRState.NORMAL)
        //{
        //    this.transform.parent = DummyBody.transform;
        //    this.transform.localPosition = new Vector3(0, 0.516f, 0);
        //}
    }
}
