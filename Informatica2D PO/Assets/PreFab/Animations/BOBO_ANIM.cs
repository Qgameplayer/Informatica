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

		//Vector3 characterScale = transform.localScale;

      //  if (Input.GetKey(KeyCode.A)){
		//	characterScale.x = -0.05751192;
		//}

       // if (Input.GetKey(KeyCode.D))
       // {
       //     characterScale.x = 0.05751192;
       // }



    }
}
