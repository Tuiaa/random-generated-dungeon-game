using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHandler : MonoBehaviour {
    
	void Start () {
        Room room = new Room();
        room.width = 3;
        room.depth = 7;
        room.roomHeight = 2;
        room.position = new Vector2(0, 0);

        RoomGenerator roomGener = new RoomGenerator();
        roomGener.CreateRoom(room);
	}
	
	void Update () {
		
	}
}
