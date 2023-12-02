using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class TopDownCameraSwitch : MonoBehaviour
{


    //Set Orbit camera gameobjects in inspector


    //This keeps track of the Orbit Camera prefab, both the camera and the empty object where the OrbitCameraController code is located. 

    public GameObject OrbitCameraObject;
    public GameObject OrbitCamera;








    //Bool that is used to prevent sticking

    //the tracker is used to track the camera's rotation for the sake of specific parts of the code. 
    public float camerarotationtracker = .45f;


    //This keeps track of the Orthographic camera prefab, but the second thing is the Camera, not the camera's gameobject, since we're using a value of the camera instead of the transform. 
    public GameObject OrthographicCameraObject;
    public Camera OrthographicCamera;



    //Tracks whether or not the camera is allowed to swap. Very important for causing things to not break. 

    public bool readySwap = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Makes the tracker track the camera zoom. 
        camerarotationtracker = OrbitCamera.transform.rotation.eulerAngles.x;


        print(camerarotationtracker);

        //Re-enable swapping if zoomed in a tiny bit beyond the orbit max
        if (OrbitCamera.transform.rotation.eulerAngles.x <= 59.9 && readySwap == false)
        {
            readySwap = true;
        }









        //Swaps from orbit to orthographic if swapping is enabled and camera is active at max zoom distance. 
        if (OrbitCamera.transform.rotation.eulerAngles.x >= 60 && OrbitCameraObject.activeSelf && readySwap == true)
        {


            //Disables swapping to Orthographic again until reset with the above code
            readySwap = false;

            //Disables the Orbit Camera

            OrbitCameraObject.SetActive(false);

            RenderSettings.fog = false;

            //Sets the orthographic camera to its starting values and makes it active.
            OrthographicCamera.orthographicSize = 166;
            OrthographicCameraObject.SetActive(true);

        }








        //When the camera is zoomed in enough, and the orthographic camera is active, swaps back to orbit
        if (OrthographicCamera.orthographicSize <= 165 && OrthographicCameraObject.activeSelf)
        {

            //Same process as above, but reverse.
            //Disables and resets Orthographic to something that cannot cause issues in the future
            OrthographicCamera.orthographicSize = 170;
            OrthographicCameraObject.SetActive(false);

            //And activates the Orbit Camera 
            OrbitCameraObject.SetActive(true);

            RenderSettings.fog = true;


        }
    }
}





//This is code that can be used to manually swap cameras, mostly used for testing.
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
//}





