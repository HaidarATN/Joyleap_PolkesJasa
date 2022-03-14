using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelFollow : MonoBehaviour
{
    public GameObject _Camera;
    public Vector3 Offset;
    public float Smooth;
    // Start is called before the first frame update
    void Awake()
    {
        //_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _Camera.transform.position + _Camera.transform.forward * Offset.z + _Camera.transform.right * Offset.x + _Camera.transform.up * Offset.y, Time.deltaTime * Smooth);
        //transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
}
