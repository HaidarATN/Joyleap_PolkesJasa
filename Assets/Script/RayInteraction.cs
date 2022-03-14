using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class RayInteraction : MonoBehaviour
{
    private WebXRController controller;

    private Animator anim;

    public GameObject pointedGameObject, hoveredGameObject;

    RaycastHit hit;

    public bool isLeftController;

    public IdleHelper idleHelper;

    WebXRManager XRManager;

    bool buttonPressed;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<WebXRController>();
        XRManager = this.transform.parent.GetComponent<WebXRManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedTime = controller.GetButton("Trigger") ? 1 : controller.GetAxis("Grip");

        // Use the controller button or axis position to manipulate the playback time for hand model.
        anim.Play("Take", -1, normalizedTime);

        //VR
        if(XRManager.xrState == WebXRState.ENABLED)
        {
            if (!isLeftController)
            {
                if (controller.GetButtonDown("Trigger"))
                {
                    Interaction();
                    idleHelper.idleTime = 0;
                }

                if (controller.GetButtonUp("Trigger"))
                    pointedGameObject = null;
            }

            //Hovering
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.gameObject.tag == "Interactable")
                {
                    if (hit.collider.gameObject.GetComponent<IRayHovering>() != null)
                    {
                        hoveredGameObject = hit.collider.gameObject;
                        hoveredGameObject.GetComponent<IRayHovering>().OnHover();
                    }
                }
            }

            else
            {
                if (hoveredGameObject != null)
                {
                    hoveredGameObject.GetComponent<IRayHovering>().UnHover();
                    hoveredGameObject = null;
                }
            }
        }

        else
        {
            //Mouse
            if (Input.GetMouseButtonDown(0))
            {
                MouseInteraction();
                idleHelper.idleTime = 0;
            }

            else if (Input.GetMouseButtonUp(0))
            {
                pointedGameObject = null;
            }
        }
    }

    void Interaction()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.gameObject.tag == "Interactable")
            {
                pointedGameObject = hit.collider.gameObject;
                Debug.Log("It Hurts");
                Debug.DrawLine(transform.position, hit.point);
                /* GameObject enemy = GameObject.FindWithTag("Enemy");
                 EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                 enemyHealth.maxHealth = -10;*/
            }
        }

        if(pointedGameObject != null)
        {
            pointedGameObject.GetComponent<IInteraction>().Interact();
        }
    }

    void MouseInteraction()
    {
        print("hehe");
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit))
        {
            if (hit.collider.gameObject.tag == "Interactable" || hit.collider.gameObject.tag == "Grabable" || hit.collider.gameObject.tag == "TaskObject" || hit.collider.gameObject.tag == "HandR" || hit.collider.gameObject.tag == "HandL")
            {
                pointedGameObject = hit.collider.gameObject;
                Debug.Log("It Hurts");
                Debug.DrawLine(transform.position, hit.point);
                /* GameObject enemy = GameObject.FindWithTag("Enemy");
                 EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                 enemyHealth.maxHealth = -10;*/
            }
        }

        if (pointedGameObject != null)
        {
            pointedGameObject.GetComponent<IInteraction>().Interact();
        }
    }
}
