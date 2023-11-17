using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class TopDownCameraSwitch : MonoBehaviour
{
    public GameObject OrbitCameraObject;
    public GameObject OrbitCamera;

    public float camerarotationtracker = 45f; 



    public GameObject OrthographicCameraObject;
    public Camera OrthographicCamera;

    public bool readySwap = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        camerarotationtracker = OrbitCamera.transform.rotation.x;

        if (camerarotationtracker <= .45f && readySwap == false)
        {
            readySwap = true;
        }

        print(Quaternion.Euler(55f, 0f, 0f));

        //print(OrthographicCamera.orthographicSize);
        if (OrbitCamera.transform.rotation.x == .5f && OrbitCameraObject.activeSelf && readySwap == true)
        {
            print(55f);
            readySwap = false;
            OrbitCamera.transform.rotation = Quaternion.Euler(55f, 0f, 0f);
            OrbitCameraObject.SetActive(false);
            OrthographicCamera.orthographicSize = 166;
            OrthographicCameraObject.SetActive(true);
        }

        if (OrthographicCamera.orthographicSize <= 165 && OrthographicCameraObject.activeSelf)
        {
            //print("Swap Camera to Orbit!");
            OrthographicCamera.orthographicSize = 170;
            OrthographicCameraObject.SetActive(false);
            OrbitCamera.transform.rotation = Quaternion.Euler(55f, 0f, 0f);
            OrbitCameraObject.SetActive(true);
            print(camerarotationtracker);
            
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



    

