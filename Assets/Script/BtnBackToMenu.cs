using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBackToMenu : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        //Application.Quit();
        Destroy(GameObject.Find("WebXRCameraSet"));
        SceneManager.LoadScene(0);
    }
}
