using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnChooseMode : MonoBehaviour, IInteraction
{
    public int mode; //0 360; 1 3D
    public Sprite modePreview;
    public Image modeImage;
    public ModeManager mm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoosenMode()
    {
        modeImage.sprite = modePreview;
        mm.mode = mode;
    }

    public void Interact()
    {
        ChoosenMode();
    }
}
