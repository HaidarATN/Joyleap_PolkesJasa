using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KembaliScript : MonoBehaviour, IInteraction
{
    public GameObject GameInfoUI;
    public InfoButtonTouch InfoButton;
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
        //Only for PC
        GameInfoUI.transform.parent.GetComponent<UIPanelFollowCamera>().enabled = true;
        //

        GameInfoUI.SetActive(false);
        InfoButton.UiShowed = false;
    }
}
