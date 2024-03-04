using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIBI_ANIM : MonoBehaviour
{

	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void Update(){

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){

			anim.SetBool("isRunning", true);

		} else {
			anim.SetBool("isRunning", false);
		}
	}

}
