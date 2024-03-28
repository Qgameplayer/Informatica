using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIBI_ANIM : MonoBehaviour
{

	private Animator anim;
    private Transform parentTransform;

    void Start(){
		anim = GetComponent<Animator>();
        parentTransform = transform.parent;
    }

	void Update(){

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){

			anim.SetBool("isRunning", true);

		} else {
			anim.SetBool("isRunning", false);
		}


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            parentTransform.localScale = new Vector3(-1, 1, 1f);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            parentTransform.localScale = new Vector3(1, 1, 1f);

        }
    }

}
