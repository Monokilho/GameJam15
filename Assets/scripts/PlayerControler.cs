using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public float maxSpeed = 1f;
	public float maxdist;
	public Hall currentroom;
	public Hall nextroom;
	public bool[] items;
	public bool roomchanging;
	public CameraControl camera;
	public Animator anim;
	bool right = true;
	float lightvalue;
	bool founddoor;
	public float fadevalue;
	public AudioSource audio;
	public AudioClip dooropen;
	public AudioSource footsteps;
	public vultcontrol vult;

	Vector3 newposition;

	GameObject[] doors;
	GameObject[] roomitems;

	Rigidbody2D rigid;
	// Use this for initialization

	void Start () {
		lightvalue = camera.light.intensity;
		getDoors ();
	}

	void flip(){
		right = ! right;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!roomchanging) {
			float move = Input.GetAxis ("Horizontal");
			if(move < 0 && right == true)
				flip();
			else if(move > 0 && right == false)
				flip();


			if(move != 0.0f){
				if(!footsteps.isPlaying)
				footsteps.Play();
				anim.SetBool("moving",true);
			}
		
			else{
				footsteps.Stop();
				anim.SetBool("moving",false);


			}
			//comment this out to not limit movement
			if(move<0 && transform.position.x>currentroom.minX || move>0&& transform.position.x<currentroom.maxX)
			transform.Translate (new Vector3 (move*0.03f, 0, 0));
			//action
			if (Input.GetButtonDown ("Jump")) {
				// door action
				for (int i=0; i<doors.Length; i++) {
					float distance = doors [i].transform.position.x - transform.position.x;

					if (distance < 0)
						distance = -1 * distance;
					//print ("door number:" + i + " door pos:" + doors[i].transform.position.x + " player por:" + transform.position.x + " dist:" +distance);;
					if (distance < maxdist) {
						Door door = (Door)doors [i].GetComponent (typeof(Door));

						if (door.Interact ()) {
							audio.PlayOneShot(dooropen);
							newposition = door.targetdoor.transform.position;
							nextroom = (Hall)door.target;

							vult.towait=true;
							roomchanging=true;
						}
						//missing bool to return
						founddoor=true;
						break;
					}

				}

				//object action
				if(!founddoor && roomitems != null)
				for(int i=0; i<roomitems.Length;i++){
					float distance = roomitems[i].transform.position.x - transform.position.x;
					print ("player:"+transform.position.x);
					print ("items:"+roomitems[i].transform.position.x);
					if(distance<0)
					distance = -1*distance;
				
				//print ("door number:" + i + " door pos:" + doors[i].transform.position.x + " player por:" + transform.position.x + " dist:" +distance);;
					Item curitem = (Item) roomitems[i].GetComponent(typeof(Item));
					if(distance < maxdist && curitem.isActiveAndEnabled){
					curitem.Interact();
						break;
				}
				
			}

			}
		
		} 

		else {
			if(camera.fade(fadevalue)==0f){
				print ("blackning");
				currentroom.hideroom (true);
				nextroom.hideroom (false);
				currentroom = nextroom;
				transform.position = new Vector3 (newposition.x,transform.position.y,transform.position.z);
				fadevalue= fadevalue*-1;
				getDoors ();
				getItems();
			}

			if(camera.fade(fadevalue)>lightvalue){
				print ("whitening");
				fadevalue= fadevalue*-1;
				roomchanging=false;
				founddoor=false;
				vult.towait=false;
				vult.gameObject.SetActive(true);
			}
		}

	}
	void getItems(){
		roomitems = currentroom.items;
	
	}
	void getDoors(){
		doors = currentroom.doors;
		for (int i=0; i<doors.Length; i++) {
			Door door = (Door)doors [i].GetComponent (typeof(Door));
			door.setglitchanim();
		}
	}
}
