using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBO_ANIM : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
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
            
            transform.localScale = new Vector3(-0.05751192f, 0.02875596f, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            transform.localScale = new Vector3(0.05751192f, 0.02875596f, 1f);
        }



    }
}
