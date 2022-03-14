using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class PlayerMovement : MonoBehaviour
{
    private WebXRController controller;
    WebXRManager XRManager;
    public bool canMove = false;
    public GameObject player, playerOrientation;
    public GameObject GameInfoUI;
    public float speed;

    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
        //transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, rotation.y * lookSpeed, 0);
    }
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<WebXRController>();
        XRManager = this.transform.parent.GetComponent<WebXRManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //player.transform.Translate(new Vector3(controller.GetAxis("JoystickX"), 0, controller.GetAxis("JoystickY"))*speed);
            //If VR
            if (XRManager.xrState == WebXRState.ENABLED)
            {
                player.transform.Translate(playerOrientation.transform.right * controller.GetAxis("JoystickX") * Time.deltaTime * speed, Space.World);
                player.transform.Translate(playerOrientation.transform.forward * controller.GetAxis("JoystickY") * -1 * Time.deltaTime * speed, Space.World);
            }

            //If PC
            else if (XRManager.xrState == WebXRState.NORMAL)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    player.transform.Translate(playerOrientation.transform.forward * 1 * Time.deltaTime * speed, Space.World);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    player.transform.Translate(playerOrientation.transform.forward * -1 * Time.deltaTime * speed, Space.World);
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Translate(playerOrientation.transform.right * Time.deltaTime * speed, Space.World);
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Translate(playerOrientation.transform.right * -1 * Time.deltaTime * speed, Space.World);
                }

                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameInfoUI.SetActive(!GameInfoUI.activeSelf);
                    GameInfoUI.transform.parent.GetComponent<UIPanelFollowCamera>().enabled = !GameInfoUI.activeSelf;
                }
            }
        }

        if (XRManager.xrState == WebXRState.NORMAL)
            Look();
    }
}
