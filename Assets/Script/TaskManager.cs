using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebXR;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public List<Task> TaskList;

    public int currentTaskIndex;
    public Text TaskName, TaskName_Shd, TaskInstruction, TaskInstruction_Shd;
    public int score, maxWrong;
    public WebXRManager XRManager;
    int wrongCount;

    public AudioClip wrong, correct;
    AudioSource asc;
    public enum GameMode { Learn, Test };
    public GameMode mode;
    // Start is called before the first frame update
    void Start()
    {
        asc = GetComponent<AudioSource>();
        //UpdateTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTask(GameObject other)
    {
        if(other == TaskList[currentTaskIndex].taskObject)
        {
            print("Task Done");
            asc.clip = correct;
            asc.Play();

            if(mode == GameMode.Test)
            {
                if (wrongCount > 0)
                {
                    score++;
                }
            }

            if (TaskList[currentTaskIndex].isCurrentTaskObjectMustDestroyed)
            {
                TaskList[currentTaskIndex].taskObject.SetActive(false);
            }

            if(TaskList[currentTaskIndex].MustDestroyedOtherObjectOnTaskFinish != null)
            {
                foreach(GameObject go in TaskList[currentTaskIndex].MustDestroyedOtherObjectOnTaskFinish)
                {
                    //Destroy(go);
                    go.SetActive(false);
                }
            }

            //Learn Mode atau test mode, outline akan selalu dimatikan setelah check task benar
            if(TaskList[currentTaskIndex].taskObject.GetComponent<Outline>())
            TaskList[currentTaskIndex].taskObject.GetComponent<Outline>().enabled = false;

            //Turn off current task object collider before updating to next task if the task object is stationary
            if (TaskList[currentTaskIndex].taskObject.GetComponent<Collider>() && TaskList[currentTaskIndex].taskObject.GetComponent<Rigidbody>() == null)
            {
                if (TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled == true)
                {
                    TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled = false;
                }
            }
            currentTaskIndex++;
            UpdateTask();
        }

        else if(other != TaskList[currentTaskIndex].taskObject)
        {
            if(mode == GameMode.Test)
            {
                if (wrongCount > 0)
                {
                    //Hint chance -1
                    wrongCount--;
                    //Play wrong sound
                    asc.clip = wrong;
                    asc.Play();

                    if (wrongCount == 0)
                    {
                        ActivateHint();
                    }
                }
                
            }
        }

    }

    public void UpdateTask()
    {
        //Check first if skipped in PC or not
        if(XRManager.xrState == WebXRState.NORMAL)
        {
            if (TaskList[currentTaskIndex].isSkippedOnPCMode)
            {
                currentTaskIndex++;
            }
        }

        //Update Task Session From here
        TaskName.text = TaskList[currentTaskIndex].TaskName;
        TaskInstruction.text = TaskList[currentTaskIndex].TaskInstruction;
        TaskName_Shd.text = TaskList[currentTaskIndex].TaskName;
        TaskInstruction_Shd.text = TaskList[currentTaskIndex].TaskInstruction;

        //Play Sound
        if (TaskList[currentTaskIndex].audioClip != null)
        {
            asc.clip = TaskList[currentTaskIndex].audioClip;
            asc.Play();
        }

        if(TaskList[currentTaskIndex].taskObject != null)
        {
            if (!TaskList[currentTaskIndex].taskObject.activeSelf)
            {
                TaskList[currentTaskIndex].taskObject.SetActive(true);
            }
        }

        if (TaskList[currentTaskIndex].taskObject.GetComponent<Collider>())
        {
            if(TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled == false)
            {
                TaskList[currentTaskIndex].taskObject.GetComponent<Collider>().enabled = true;
            }
        }

        if (TaskList[currentTaskIndex].mustActivateGameObjectOnTaskStart != null)
        {
            foreach (GameObject go in TaskList[currentTaskIndex].mustActivateGameObjectOnTaskStart)
            {
                //Destroy(go);
                go.SetActive(true);
            }
        }

        if (TaskList[currentTaskIndex].isCurrentObjectMoveable && TaskList[currentTaskIndex].originObjectPos == new Vector3(0,0,0))
        {
            TaskList[currentTaskIndex].originObjectPos = TaskList[currentTaskIndex].taskObject.transform.position;
        }

        if (mode == GameMode.Learn)
        {
            if (TaskList[currentTaskIndex].taskObject.GetComponent<Outline>())
                TaskList[currentTaskIndex].taskObject.GetComponent<Outline>().enabled = true;
        }

        else if (mode == GameMode.Test)
        {
            wrongCount = maxWrong;
        }
    }

    void ActivateHint()
    {
        if (TaskList[currentTaskIndex].taskObject.GetComponent<Outline>())
            TaskList[currentTaskIndex].taskObject.GetComponent<Outline>().enabled = true;
    }
}

[System.Serializable]
public class Task
{
    public string TaskName, TaskInstruction;
    public GameObject taskObject;
    public GameObject[] MustDestroyedOtherObjectOnTaskFinish, mustActivateGameObjectOnTaskStart;
    public bool isCurrentTaskObjectMustDestroyed, isCurrentObjectMoveable, isSkippedOnPCMode;
    public Vector3 originObjectPos;
    public AudioClip audioClip;
}
