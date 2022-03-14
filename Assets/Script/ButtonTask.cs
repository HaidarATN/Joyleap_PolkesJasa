using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTask : MonoBehaviour, IInteraction
{
    TaskManager TaskManager;
    public GameObject ParentObject;
    // Start is called before the first frame update
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        TaskManager.CheckTask(ParentObject);
        print("hehe");
    }
}
