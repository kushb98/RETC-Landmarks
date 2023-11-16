using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownFollow : MonoBehaviour
{
   public Transform CameraPosition;
   public Transform PlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition.position = PlayerPosition.position;
    }
}
