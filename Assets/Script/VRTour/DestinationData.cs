using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationData : MonoBehaviour, IInteraction, IRayHovering
{
    public int DestinationSpotIndex;
    public SpotShower SpotManager;
    public GameObject pin;
    // Start is called before the first frame update
    void Awake()
    {
        SpotManager = GameObject.Find("SpotManager").GetComponent<SpotShower>();
        StartCoroutine(IdleAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        StartCoroutine(SpotManager.UpdateSpot(DestinationSpotIndex-1, SpotManager.SpotList[DestinationSpotIndex-1].Destination));
    }

    public void OnHover()
    {
        pin.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void UnHover()
    {
        pin.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    IEnumerator IdleAnim()
    {
        Transform temp;
        temp = this.transform;
        while(this.transform.position.y <= 1)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.001f, this.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        while (this.transform.position.y >= 0.9)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.001f, this.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(IdleAnim());
    }
}
