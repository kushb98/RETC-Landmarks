using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarkerSystem : MonoBehaviour
{

    public GameObject marker;
    public GameObject MarkerUI;
    public GameObject MarkerIndicator;
    




    
    void Start()
    {
        
    }

    public void EnterMarkerMode()
    {
      MarkerUI.SetActive(true);
      Instantiate(MarkerIndicator);
      //MarkerIndicator.transform.position = Input.mousePosition;
       
       




               
    }

    public void ExitMarkerMode()
    {
        MarkerUI.SetActive(false);
        //MarkerIndicator.SetActive(false);
        Debug.Log("Exit Marker Mode");
        Destroy(MarkerIndicator);

    }

    public void PlaceMarker()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 pos = hit.point;
            pos.y += 0.1f;
            Instantiate(marker, pos, Quaternion.identity);
        }     
    }

    public void RemoveMarker()
    {
        //remove all markers
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker");
        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        } 
    }



    
    void Update()
    {
        //if in marker mode and left click down, place marker
        if (MarkerUI.activeSelf && Input.GetMouseButtonDown(0))
        {
            PlaceMarker();
        }

        //if EnterMarkerMode, marker indicator follows mouse
        if (MarkerUI.activeSelf)
        {
            //Use camera to screen point to have the indicator follow the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            MarkerIndicator.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        }







    }
}
