using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
  {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
	if(Input.GetKeyDown(KeyCode.A))
		{ mAnimator.SetTrigger("attack"); }
	if(Input.GetKeyDown(KeyCode.D))
		{ mAnimator.SetTrigger("die"); }
        
    }
}