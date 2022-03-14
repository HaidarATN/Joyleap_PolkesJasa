using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class BringObjectTask : MonoBehaviour, IInteraction
{
    public GameObject DestinationObject, PanelConfirm, PCGrabPos;
    TaskManager TaskManager;
    WebXRManager XRManager;
    public bool needConfirmationPanel;
    [HideInInspector]
    public bool isGrabbedOnMouse;
    // Start is called before the first frame update
    void Start()
    {
        XRManager = GameObject.FindObjectOfType<WebXRManager>();
        TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        PCGrabPos = GameObject.Find("PCGrabPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbedOnMouse)
        {
            if (this.GetComponent<Rigidbody>())
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
            this.transform.parent = PCGrabPos.transform;
        }

        else
        {
            if (this.GetComponent<Rigidbody>())
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
            this.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == DestinationObject)
        {
            //PanelConfirm.SetActive(true);

            //Dropping item depends on mode
            if (XRManager.xrState == WebXRState.ENABLED)
            {
                this.transform.parent.gameObject.GetComponent<HandGrab>().ReleaseObject();
            }

            else
            {
                isGrabbedOnMouse = false;
                this.transform.parent = null; //just to make sure its gone from PC Hand
            }

            //this.transform.SetParent(DestinationObject.transform);
            //this.GetComponent<Rigidbody>().isKinematic = true;
            TaskManager.CheckTask(DestinationObject);

            if(needConfirmationPanel)
            PanelConfirm.SetActive(true);
        }
    }

    public void Interact()
    {
        //if non VR
        if(XRManager.xrState == WebXRState.NORMAL)
        {
            isGrabbedOnMouse = !isGrabbedOnMouse;
        }

        TaskManager.CheckTask(this.gameObject);
    }
}
