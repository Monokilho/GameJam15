using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Events : MonoBehaviour {

	public Door[] doors;
	public Hall[] halls;
	public Image[] itemsimg;
	public Item[] items;
	public bool[] haveitems;
	public PlayerControler player;
	public GameObject[] backgrounds;
	public AudioSource sfxsound;
	public AudioClip fallingobject;
	public AudioClip doorunlocked;
	public AudioClip itempickup;
	public vultcontrol vult;
	public void startEvent(Door door){


		switch (door.eventID) {
		case 1:{

			//to do stuff
			sfxsound.PlayOneShot(doorunlocked);
			doors[3].glithed=false;
			doors[27].glithed=false;
			//doors[27].anim.SetBool("glitch",false);
			doors[3].anim.SetBool("glitch",false);
			door.eventID = 0;
			doors[2].glithed=false;
			break;
			}
		case 2:{
			sfxsound.PlayOneShot(fallingobject);
			items[1].gameObject.SetActive(true);
			door.eventID = 0;
			//sound cue
			break;
		}

		case 3:{
			if(haveitems[1]){
				sfxsound.PlayOneShot(doorunlocked);;
				doors[6].targetdoor=doors[20];
				doors[6].target=halls[5];
				doors[6].glithed=false;
				doors[6].anim.SetBool("glitch",false);
				doors[20].target=halls[13];
				doors[20].targetdoor=doors[6];
				doors[20].glithed=false;
				doors[22].target=halls[13];
				doors[22].targetdoor=doors[7];
				doors[6].eventID=4;
				door.eventID = 0;
			}

			//sound cue
			break;
		}

		case 4:{
			sfxsound.PlayOneShot(doorunlocked);
			sfxsound.PlayOneShot(fallingobject);
			items[2].gameObject.SetActive(true);
			doors[2].targetdoor=doors[18];
			doors[18].targetdoor=doors[2];
			doors[2].target=halls[2];
			doors[18].target=halls[0];
			//sound cue
			break;
		}
		case 5:{
			backgrounds[1].SetActive(false);
			backgrounds[2].SetActive(true);
			doors[4].eventID=6;
			doors[17].eventID=6;
			doors[18].eventID=6;

			break;
		}
		case 6:{
			backgrounds[2].SetActive(false);
			backgrounds[3].SetActive(true);
			doors[4].eventID=7;
			doors[17].eventID=7;
			doors[18].eventID=7;
			break;
		}
		case 7:{
			sfxsound.PlayOneShot(doorunlocked);
			sfxsound.PlayOneShot(fallingobject);
			backgrounds[3].SetActive(false);
			backgrounds[0].SetActive(true);
			doors[4].eventID=0;
			doors[17].eventID=0;
			doors[18].eventID=0;
			doors[4].target=halls[0];
			doors[4].targetdoor=doors[10];
			doors[17].target=halls[3];
			doors[17].targetdoor=doors[19];
			doors[18].target=halls[4];
			doors[18].targetdoor=doors[5];
			items[3].gameObject.SetActive(true);

			break;
		}
		case 8:{
			sfxsound.PlayOneShot(doorunlocked);
			doors[29].glithed=false;
			doors[29].anim.SetBool("glitch",false);
			doors[29].target=halls[7];
			doors[29].targetdoor=doors[23];
			doors[23].target=halls[13];
			doors[23].targetdoor=doors[29];
			doors[23].glithed=true;
			//doors[23].anim.SetBool("glitch",true);
			break;
		}

		case 9:{
			vult.startanim(1);
			doors[19].eventID=0;
			break;
		}
		case 10:{
			vult.startanim(2);
			doors[22].eventID=0;
			break;

		}
		}


	}
	public void startEvent(Item item){
		switch (item.eventID) {
		case 1:{
			sfxsound.PlayOneShot(itempickup);
			items[1].gameObject.SetActive(false);
			itemsimg[1].gameObject.SetActive(true);
			haveitems[1]=true;
			item.eventID = 0;
			break;
		}

		case 2:{
			sfxsound.PlayOneShot(itempickup);
			sfxsound.PlayOneShot(doorunlocked);
			items[2].gameObject.SetActive(false);
			itemsimg[2].gameObject.SetActive(true);
			haveitems[2]=true;
			doors[4].target=halls[2];
			doors[4].targetdoor=doors[18];
			doors[17].target=halls[2];
			doors[17].targetdoor=doors[18];
			doors[18].target=halls[2];
			doors[18].targetdoor=doors[18];
			doors[4].eventID=5;
			doors[17].eventID=5;
			doors[18].eventID=5;
			backgrounds[0].SetActive(false);
			backgrounds[1].SetActive(true);
			item.eventID = 0;
			break;

		}
		case 3:{
			sfxsound.PlayOneShot(itempickup);
				items[3].gameObject.SetActive(false);
			itemsimg[3].gameObject.SetActive(true);
		haveitems[3]=true;
			doors[2].eventID=8;
				item.eventID = 0;

			break;
		}
		


		}


	}
}
