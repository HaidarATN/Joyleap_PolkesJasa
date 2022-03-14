using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour, IInteraction
{
    [HideInInspector]
    public int mode;

    public GameObject canvas360, playerMovement, roomTourSphere, Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnMulai()
    {
        if(mode == 1)
        {
            canvas360.SetActive(true);
        }

        else if(mode == 2)
        {
            //playerMovement.GetComponent<PlayerMovement>().enabled = true;
            //Player.transform.position = new Vector3(enviRoom.transform.position.x, enviRoom.transform.position.y, enviRoom.transform.position.z);
            Player.transform.position = new Vector3(roomTourSphere.transform.position.x, 0, roomTourSphere.transform.position.z);
            canvas360.SetActive(false);
        }
    }

    public void Interact()
    {
        btnMulai();
    }
}
