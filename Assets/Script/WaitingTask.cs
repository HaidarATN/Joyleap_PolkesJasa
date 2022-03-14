using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingTask : MonoBehaviour, IInteraction
{
    TaskManager TaskManager;
    public float waitingTime;
    public enum WaitingMode { Animation, Time};
    public WaitingMode mode;

    Animator anim;
    public string animationName;
    // Start is called before the first frame update
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
        anim = GetComponent<Animator>();

        switch (mode)
        {
            case WaitingMode.Animation:
                anim.Play(animationName);
                break;

            case WaitingMode.Time:
                break;
        };

        StartCoroutine(WaitingProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        print("Anim done");
        //processIndicatorImage.fillAmount = 0;
        //timeToProcess = 0;
        TaskManager.CheckTask(this.gameObject);
    }

    IEnumerator WaitingProcess()
    {
        switch (mode)
        {
            case WaitingMode.Animation:
                while(anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
                {
                    yield return new WaitForSeconds(0.01f);
                }

                if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                Interact();

                break;

            case WaitingMode.Time:
                break;
        };

    }
}
