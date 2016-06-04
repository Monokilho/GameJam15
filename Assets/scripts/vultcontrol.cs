using UnityEngine;
using System.Collections;

public class vultcontrol : MonoBehaviour {

	 public int curanim;
	bool vultactive = false;
	public bool towait;
	public AudioSource audio;
	// Update is called once per frame
	void Update () {
		if (vultactive) {
			print ("hello");
			switch (curanim) {
			case 1:
				{
					if (!towait) {
						if (!audio.isPlaying)
							audio.Play ();
						print ("moving");
						transform.Translate (new Vector3 (0.25f, 0.20f, 0f));

						if (transform.position.x > 7) {
							audio.Stop ();
							transform.position = new Vector3 (20f, 20f, 0f);
							vultactive = false;
							gameObject.SetActive (false);
						}
					}
					break;
				}
			case 2:
				{
					if (!towait) {
						if (!audio.isPlaying)
							audio.Play ();
						print ("moving");
						transform.Translate (new Vector3 (0.0f, -0.20f, 0f));
					
						if (transform.position.y < -6) {
							audio.Stop ();
							transform.position = new Vector3 (20f, 20f, 0f);
							vultactive = false;
							gameObject.SetActive (false);
						}
					}
					break;
				}
			}
		}


	}
	public void startanim(int anim){
		switch(anim){
		case 1:{
		curanim=anim;
			towait = true;
			transform.position = new Vector3(-2.5f,-4f,-0.1f);
			vultactive=true;
			break;
		}

		case 2:{
			print ("entrei 2");
			curanim=anim;
			towait = true;
			transform.position = new Vector3(-5f,3f,-0.1f);
			vultactive=true;
			break;
		}


		}

	}



}
