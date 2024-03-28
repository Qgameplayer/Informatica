using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBO_ANIM : MonoBehaviour {

	private Animator anim;
    private Transform parentTransform;

    void Start(){
		anim = GetComponent<Animator>();
        parentTransform = transform.parent;
    }

	void Update(){

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){

			anim.SetBool("isRunning", true);

		} else {
			anim.SetBool("isRunning", false);
		}

		if(Input.GetKeyDown(KeyCode.W)){
			anim.SetTrigger("jump");
		}

        if (Input.GetKey(KeyCode.A))
        {

            parentTransform.localScale = new Vector3(-1, 2, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            parentTransform.localScale = new Vector3(1, 2, 1f);
        }



    }
}
