using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHandler : MonoBehaviour {
    
	void Start () {
        Room room = new Room();
        room.width = 4;
        room.depth = 2;
        room.roomHeight = 1;
        room.position = new Vector2(0, 0);

        RoomGenerator roomGener = new RoomGenerator();
        roomGener.CreateRoom(room);
	}
	
	void Update () {
		
	}
}
