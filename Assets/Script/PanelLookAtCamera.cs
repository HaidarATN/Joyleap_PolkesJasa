using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLookAtCamera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("CameraMain").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(2 * transform.position - target.position);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
