using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebXR;

public class TriggerTask : MonoBehaviour, IInteraction
{
    TaskManager TaskManager;
    public enum ObjectUsedForTrigger { Hand, Object};

    public ObjectUsedForTrigger mode;
    public GameObject otherObject;
    float timeToProcess = 0, processTime = 2f;

    bool isProcessing;
    Image processIndicatorImage;
    WebXRManager XRManager;
    GameObject PCGrabPos;
    // Start is called before the first frame update
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        processIndicatorImage = GameObject.Find("ProcessIndicator").GetComponent<Image>();
        XRManager = GameObject.FindObjectOfType<WebXRManager>();
        PCGrabPos = GameObject.Find("PCGrabPos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(TaskManager.mode == TaskManager.GameMode.Learn)
        {
            if (TaskManager.TaskList[TaskManager.currentTaskIndex].taskObject == this.gameObject)
            {
                switch (mode)
                {
                    case ObjectUsedForTrigger.Hand:
                        if (other.gameObject.tag == "HandR" || other.gameObject.tag == "HandL")
                        {
                            isProcessing = true;
                            StartCoroutine(ProcessTime());
                            //Interact();
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            isProcessing = true;
                            StartCoroutine(ProcessTime());
                        }

                        break;
                }
            }
        }

        else if (TaskManager.mode == TaskManager.GameMode.Test)
        {
            switch (mode)
            {
                case ObjectUsedForTrigger.Hand:
                    if (other.gameObject.tag == "HandR" || other.gameObject.tag == "HandL")
                    {
                        isProcessing = true;
                        StartCoroutine(ProcessTime());
                        //Interact();
                    }

                    break;

                case ObjectUsedForTrigger.Object:
                    if (other.gameObject == otherObject)
                    {
                        isProcessing = true;
                        StartCoroutine(ProcessTime());
                    }

                    break;
            }
        }




    }

    void OnTriggerExit(Collider other)
    {
        if (TaskManager.mode == TaskManager.GameMode.Learn)
        {
            if (TaskManager.TaskList[TaskManager.currentTaskIndex].taskObject == this.gameObject)
            {
                switch (mode)
                {
                    case ObjectUsedForTrigger.Hand:
                        if (other.gameObject.tag == "HandR" || other.gameObject.tag == "HandL")
                        {
                            isProcessing = false;
                            processIndicatorImage.fillAmount = 0;
                            timeToProcess = 0;
                            StopCoroutine(ProcessTime());
                        }

                        break;

                    case ObjectUsedForTrigger.Object:
                        if (other.gameObject == otherObject)
                        {
                            isProcessing = false;
                            processIndicatorImage.fillAmount = 0;
                            timeToProcess = 0;
                            StopCoroutine(ProcessTime());
                        }

                        break;
                }
            }
        }

        else if (TaskManager.mode == TaskManager.GameMode.Test)
        {
            switch (mode)
            {
                case ObjectUsedForTrigger.Hand:
                    if (other.gameObject.tag == "HandR" || other.gameObject.tag == "HandL")
                    {
                        isProcessing = false;
                        processIndicatorImage.fillAmount = 0;
                        timeToProcess = 0;
                        StopCoroutine(ProcessTime());
                    }

                    break;

                case ObjectUsedForTrigger.Object:
                    if (other.gameObject == otherObject)
                    {
                        isProcessing = false;
                        processIndicatorImage.fillAmount = 0;
                        timeToProcess = 0;
                        StopCoroutine(ProcessTime());
                    }

                    break;
            }
        }



    }

    public void Interact()
    {
        print("Hand Washed");
        //Drop the object on "PC Mode" hand
        if (XRManager.xrState == WebXRState.NORMAL)
        {
            if (PCGrabPos.transform.childCount != 0)
            {
                if (PCGrabPos.transform.GetChild(0).GetComponent<BringObjectTask>())
                {
                    PCGrabPos.transform.GetChild(0).GetComponent<BringObjectTask>().isGrabbedOnMouse = false;
                }
                //PCGrabPos.transform.GetChild(0).transform.parent = null;
            }
        }
        processIndicatorImage.fillAmount = 0;
        timeToProcess = 0;
        TaskManager.CheckTask(this.gameObject);

       
    }

    IEnumerator ProcessTime()
    {
        while (isProcessing)
        {
            timeToProcess += 0.01f;
            processIndicatorImage.fillAmount = timeToProcess / processTime;

            if(timeToProcess >= processTime)
            {
                Interact();
                isProcessing = false;
            }

            yield return new WaitForSeconds(0.01f);
        }

        yield break;
    }
}
