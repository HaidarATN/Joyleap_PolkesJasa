using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnShowMenu : MonoBehaviour, IInteraction
{
    public GameObject UIMain, UIImage360;
    public Text btnText;

    bool isShow;
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
        isShow = !isShow;

        if (isShow)
        {
            UIMain.GetComponent<UIPanelFollow>().Offset = new Vector3(0, 1.3f, 0.4f);
            UIImage360.GetComponent<UIPanelFollow>().Offset = new Vector3(0, 1.3f, 0.4f);
            btnText.text = "Sembunyikan Menu";
        }

        else
        {
            UIMain.GetComponent<UIPanelFollow>().Offset = new Vector3(0, 0f, 0.4f);
            UIImage360.GetComponent<UIPanelFollow>().Offset = new Vector3(0, 0f, 0.4f);
            btnText.text = "Munculkan Menu";
        }
    }
}
