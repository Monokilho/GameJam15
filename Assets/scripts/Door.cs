using UnityEngine;
using System.Collections;

public class Door:MonoBehaviour	 {

	public Hall target;
	public Door targetdoor;
	public bool glithed;
	public bool interactable;
	public Animator anim;
	public int eventID;
	public Events events;


	void Start(){
		if (anim != null)
		anim.SetBool ("glitch", glithed);
	
	}

	 public void setglitchanim(){
		if (anim != null)
			anim.SetBool ("glitch", glithed);
	}

	public bool Interact(){


		events.startEvent(this);


		if (!glithed && anim != null) {
			anim.SetBool ("interact", true);
		}

		return !glithed;
	}
	
}