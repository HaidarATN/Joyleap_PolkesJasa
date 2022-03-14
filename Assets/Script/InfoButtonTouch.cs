using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonTouch : MonoBehaviour
{
    public bool UiShowed;
    public GameObject GameInfoUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "HandR" || col.gameObject.tag == "HandL")
        {
            UiShowed = !UiShowed;
            GameInfoUI.SetActive(UiShowed);
        }
    }
}
