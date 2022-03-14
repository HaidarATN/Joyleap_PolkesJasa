using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralTask : MonoBehaviour, IInteraction
{
    TaskManager TaskManager;
    Image processIndicatorImage;
    //USE THIS SCRIPT ONLY FOR MOUSE AND KEYBOARD CLICK
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        processIndicatorImage = GameObject.Find("ProcessIndicator").GetComponent<Image>();
    }

    public void Interact()
    {
        print("Hand Washed");
        processIndicatorImage.fillAmount = 0;
        TaskManager.CheckTask(this.gameObject);
    }
}
