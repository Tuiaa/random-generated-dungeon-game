using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHandler : MonoBehaviour {
    
	void Start () {
        Room room = new Room();
        room._width = 10;
        room._height = 5;
        room._position = new Vector2(0, 0);

        RoomGenerator roomGener = new RoomGenerator();
        roomGener.CreateRoom(room);
	}
	
	void Update () {
		
	}
}
