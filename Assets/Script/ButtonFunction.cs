using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonFunction : MonoBehaviour, IInteraction
{
    public UnityEvent ClickEvent;
    AudioSource asc;
    // Start is called before the first frame update
    void Start()
    {
        asc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        asc.Play();
        ClickEvent.Invoke();
    }
}
