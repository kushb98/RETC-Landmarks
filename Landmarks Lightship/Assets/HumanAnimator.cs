using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimator : MonoBehaviour
{

    public Transform playerLoc;
    public Animator PlayerAnim;
    public Vector3 currentPos;
    public Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = playerLoc.position;
        prevPos = playerLoc.position;
    }

    // Update is called once per frame
    void Update()
    {


        currentPos = playerLoc.position;



        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            print("Is Moving!");
            PlayerAnim.SetBool("IsMoving", true);

        }

        else if (Vector3.Distance(currentPos, prevPos) < 0.05f)
        {
            print("Is not moving!");
            PlayerAnim.SetBool("IsMoving", false);
        }

        prevPos = currentPos;
    }
}
