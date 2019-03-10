using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {
    
    private Room _roomToGenerate;

	public void CreateRoom(Room room)
    {
        _roomToGenerate = room;

        if(_roomToGenerate != null)
        {
            CreateFloor(_roomToGenerate._width, _roomToGenerate._height);
            CreateWalls();
        }
    }

    private void CreateFloor(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject _floorQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _floorQuad.transform.position = new Vector3(_roomToGenerate._position.x + i, 0, _roomToGenerate._position.y + j);
                _floorQuad.transform.Rotate(90, 0, 0, Space.World);
            }
        }
    }

    private void CreateWalls()
    {

    }

    private void PositionCamera()
    {

    }
}
