using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class HandGrab : MonoBehaviour
{
    private WebXRController controller;
    GameObject objectNearHand, objectInHand;
    WebXRManager XRManager;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<WebXRController>();
        XRManager = GameObject.Find("WebXRCameraSet").GetComponent<WebXRManager>();

        if(XRManager.xrState == WebXRState.NORMAL)
        {
            //hide hand when in PC mode
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);

            if (this.GetComponent<LaserPointer>())
            {
                this.GetComponent<LaserPointer>().enabled = false;
                this.GetComponent<LineRenderer>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetButtonDown("Grip"))
        {
            GrabObject();
        }

        if (controller.GetButtonUp("Grip"))
        {
            ReleaseObject();
        }
    }

    void GrabObject()
    {
        if(objectNearHand != null)
        {
            objectInHand = objectNearHand;
            objectInHand.transform.SetParent(this.transform);
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
            objectInHand.GetComponent<IInteraction>().Interact();
        }
    }

    public void ReleaseObject()
    {
        if(objectInHand != null)
        {
            objectInHand.transform.SetParent(null);
            objectInHand.GetComponent<Rigidbody>().isKinematic = false;
            objectInHand = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabable")
        {
            objectNearHand = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        objectNearHand = null;
    }
}
