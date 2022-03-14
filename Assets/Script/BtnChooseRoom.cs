using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnChooseRoom : MonoBehaviour, IInteraction
{
    public string RoomName;
    public GameObject Player, PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseRoom(string RoomName)
    {
        GameObject room = GameObject.Find(RoomName);
        Player.transform.position = new Vector3(room.transform.position.x, Player.transform.position.y, room.transform.position.z);
        PlayerMovement.GetComponent<PlayerMovement>().enabled = false;
    }

    public void Interact()
    {
        ChooseRoom(RoomName);
    }
}
