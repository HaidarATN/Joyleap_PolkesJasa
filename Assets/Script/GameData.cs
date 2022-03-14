using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public string PlayerName, playerNIM;

    public Text playerNameText, playerNIMText, praktikumText, modeText;
    public TaskManager taskManager;
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = PlayerName;
        playerNIMText.text = playerNIM;
        //praktikumText.text = praktikumName;
        praktikumText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        modeText.text = taskManager.mode.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
