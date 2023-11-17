using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class TopDownCameraSwitch : MonoBehaviour
{

    //Set Orbit camera gameobjects in inspector
    public GameObject OrbitCameraObject;
    public GameObject OrbitCamera;


    //Track camera rotation to prevent sticking
    public float camerarotationtracker = 45f; 


    //Set Orthographic camera gameobject and camera in inspector
    public GameObject OrthographicCameraObject;
    public Camera OrthographicCamera;

    //Bool that is used to prevent sticking
    public bool readySwap = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the tracker track the camera zoom. 
        camerarotationtracker = OrbitCamera.transform.rotation.x;

        //Re-enable swapping if zoomed in a tiny bit beyond the orbit max
        if (camerarotationtracker <= .49f && readySwap == false)
        {
            readySwap = true;
        }

       

        //Swaps from orbit to orthographic if swapping is enabled and camera is active at max zoom distance. 
        if (OrbitCamera.transform.rotation.x == .5f && OrbitCameraObject.activeSelf && readySwap == true)
        {

            readySwap = false;
   
            OrbitCameraObject.SetActive(false);
            OrthographicCamera.orthographicSize = 166;
            OrthographicCameraObject.SetActive(true);
        }


        //Swaps back to orbit if at minimum designated zoom for Orthographic. 
        if (OrthographicCamera.orthographicSize <= 165 && OrthographicCameraObject.activeSelf)
        {

            OrthographicCamera.orthographicSize = 170;
            OrthographicCameraObject.SetActive(false);

            OrbitCameraObject.SetActive(true);
            
            
        }
    }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{ readySwap = true;
         //   if (OrbitCameraObject.activeInHierarchy == true)
          //  {
          //      OrbitCameraObject.SetActive(false);
          //      OrthographicCameraObject.SetActive(true);
          //  }

          //  else if (OrthographicCameraObject.activeInHierarchy == true)
         //   {
           //     OrbitCameraObject.SetActive(true);
          //      OrthographicCameraObject.SetActive(false);
          //  }
        }



    

