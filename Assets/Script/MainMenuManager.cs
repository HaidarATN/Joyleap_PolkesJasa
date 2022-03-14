using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public UnityEvent MaiEvent;
    public Text playerName, NIM, prakName;
    public Image ScreenFade;
    public GameData data;

    public GameObject MainUI, ModeUI, Player, InGameCanvasUI, handL;
    public TaskManager taskManager;
    public Vector3 playerStartPos;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(MyEvent, 1f);
        //MyEvent.Invoke();
        MaiEvent.Invoke();

        playerName.text = data.PlayerName;
        NIM.text = data.playerNIM;
        prakName.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //taskManager.mode = TaskManager.GameMode.Learn;
        //StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVR()
    {
        MainUI.SetActive(false);
        ModeUI.SetActive(true);
    }

    public void Kembali()
    {
        MainUI.SetActive(true);
        ModeUI.SetActive(false);

        //False UI2 lainnya
    }

    public void KeluarApp()
    {
        Application.Quit();
    }

    public void LearnMode()
    {
        taskManager.mode = TaskManager.GameMode.Learn;
        StartCoroutine(StartGame());
    }

    public void PostTestMode()
    {
        taskManager.mode = TaskManager.GameMode.Test;
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        //////Screen Fade In/////////
        Color tempColor = ScreenFade.color;

        while (ScreenFade.color.a < 1)
        {
            tempColor.a += 0.05f;
            ScreenFade.color = tempColor;
            yield return new WaitForSeconds(0.01f);
        }
        //////////////////////////////
        ///
        //Player.transform.position = new Vector3(22.57f, 0f, 8.284f);
        Player.transform.position = playerStartPos;

        yield return new WaitForSeconds(0.5f);
        //Fade Out
        while (true)
        {
            if (ScreenFade.color.a > 0)
            {
                tempColor.a -= 0.05f;
                ScreenFade.color = tempColor;
                yield return new WaitForSeconds(0.01f);
            }

            else
            {
                break;
            }
        }

        taskManager.UpdateTask();
        //InGameCanvasUI.SetActive(true);
        InGameCanvasUI.GetComponent<UIPanelFollowCamera>().Offset.y = -0.02f;
        handL.GetComponent<PlayerMovement>().canMove = true;
    }
}