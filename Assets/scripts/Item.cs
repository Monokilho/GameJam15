using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public int itemID;
	public int eventID;
	public Events events;

	public void Interact(){
		
		events.startEvent (this);
	
	}

}
