using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCtrl : MonoBehaviour
{

    private Animator ator;
    

    private MoveAvatar moveAvatar;
    

	void Start ()
	{
	    ator = gameObject.GetComponent<Animator>();
        

	    moveAvatar = transform.parent.GetComponent<MoveAvatar>();
        
	}
	
	void Update () {
	    if (moveAvatar.animationState==MoveAvatar.AvatarAnimationState.Idle)
            
	    {
	        if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                
	        {
	            ator.SetTrigger("Idle");
            }
	            
	    }else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk)
	    {
	        if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
	        {
	            ator.SetTrigger("Walk");
            }        
        }
	    else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run)
	    {
	        if (!ator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
	        {
	            ator.SetTrigger("Run");
            }
	        
	    }
    }
}
