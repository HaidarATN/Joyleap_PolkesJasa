using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChooser : MonoBehaviour, IInteraction
{
    public TaskManager taskManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (taskManager.currentTaskIndex != 0)
        {
            if(taskManager.TaskList[taskManager.currentTaskIndex].taskObject.GetComponent<Outline>())
            taskManager.TaskList[taskManager.currentTaskIndex].taskObject.GetComponent<Outline>().enabled = false;

            if(taskManager.TaskList[taskManager.currentTaskIndex].taskObject.tag == "PanelObject")
            {
                taskManager.TaskList[taskManager.currentTaskIndex].taskObject.SetActive(false);
            }
            taskManager.currentTaskIndex--;

            if (taskManager.TaskList[taskManager.currentTaskIndex].isCurrentObjectMoveable) //Mereset object setelah index berkurang
            {
                taskManager.TaskList[taskManager.currentTaskIndex].taskObject.transform.position = taskManager.TaskList[taskManager.currentTaskIndex].originObjectPos;
            }

            taskManager.UpdateTask();
            print("updated");
        }

        else
            print("hehe");
        
    }
}
