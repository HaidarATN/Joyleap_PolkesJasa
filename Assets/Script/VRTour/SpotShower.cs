using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotShower : MonoBehaviour
{
    public int CurrentSpot;
    public GameObject DestinationPrefab, mainSphere;
    public Texture newTexture;
    public Image ScreenFade;

    [SerializeField]
    public List<SpotData> SpotList;

    public List<GameObject> tempDestGroup = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateSpot(CurrentSpot-1, SpotList[CurrentSpot-1].Destination));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateSpot(int spotDestIndex, SpotDestination[] destination)
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

        yield return new WaitForSeconds(0.1f);
        //Update Spot memunculkan tekstur 360 baru + memunculkan prefab destination dengan parse nilai dari spot destination
        CurrentSpot = spotDestIndex; //Karena list gambar dimulai dari 1

        StartCoroutine(EndUpdateSpot(spotDestIndex, destination));

        //yield return new WaitForSeconds(0.1f);

        
        yield break;
    }

    void RemoveLastDestinationObject()
    {
        if (tempDestGroup != null)
        {
            foreach (GameObject i in tempDestGroup)
            {
                //tempDestGroup.Remove(i);
                Destroy(i);
            }
        }

        tempDestGroup.Clear();
    }

    void AddNewDestinationObject(SpotDestination[] destination)
    {
        GameObject temp;

        foreach (SpotDestination i in destination)
        {
            temp = Instantiate(DestinationPrefab, i.IconPosition, Quaternion.identity);
            temp.GetComponent<DestinationData>().DestinationSpotIndex = i.SpotDestinationIndex;
            tempDestGroup.Add(temp);
            temp = null;
        }
    }

    IEnumerator EndUpdateSpot(int spotDestIndex, SpotDestination[] destination)
    {
        yield return new WaitForSeconds(0.1f);
        //Fungsi destroy, ganti texture, dan add object dipisah, karena objek prefab yang start coroutine tidak boleh hancur dulu, apabila hancur maka coroutinenya hancur juga. Jadi di hancurkan di coroutine yang dipanggil diobjek ini, bukan di prefab
        //Destroy Last Destination Object
        RemoveLastDestinationObject();

        mainSphere.GetComponent<Renderer>().material.mainTexture = SpotList[spotDestIndex].SpotImage;
        //mainSphere.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));

        AddNewDestinationObject(destination);
        //////Screen Fade Out//////////////
        Color tempColor = ScreenFade.color;

        //print("hhh4");
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
        ///////////////////////////////////
    }

}

[System.Serializable]
public class SpotData
{
    public int SpotIndex;
    public SpotDestination[] Destination;
    public Texture SpotImage;
}

[System.Serializable]
public class SpotDestination
{
    public int SpotDestinationIndex;
    public Vector3 IconPosition;
}
