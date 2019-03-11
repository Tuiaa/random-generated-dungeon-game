using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates a room according to Room object
/// </summary>
public class RoomGenerator {

    [SerializeField]
    private float _offsetPivotPoint = 0.5f;

    private Room _roomToGenerate;
    GameObject roomParent;

    public void CreateRoom(Room room)
    {
        _roomToGenerate = room;

        if(_roomToGenerate != null)
        {
            roomParent = new GameObject();
            roomParent.name = "RoomParent";

            CreateFloor();
            CreateWalls();
        }
    }

    /// <summary>
    /// Creates floor of a room
    /// </summary>
    private void CreateFloor()
    {
        for (int i = 0; i < _roomToGenerate.width; i++)
        {
            for (int j = 0; j < _roomToGenerate.height; j++)
            {
                GameObject _floorQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _floorQuad.name = "FloorQuad" + i + j;
                _floorQuad.transform.position = new Vector3(_roomToGenerate.position.x + i + _offsetPivotPoint, 0, _roomToGenerate.position.y + j + _offsetPivotPoint);
                _floorQuad.transform.Rotate(90, 0, 0, Space.World);
                _floorQuad.transform.parent = roomParent.transform;
            }
        }
    }

    /// <summary>
    /// Creates walls around a room
    /// </summary>
    private void CreateWalls()
    {
        // Bottom wall
        for (int i = 0; i < _roomToGenerate.width; i++)
        {
            for (int j = 0; j < _roomToGenerate.roomHeight; j++)
            {
                GameObject _wallQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _wallQuad.name = "WallQuadBottom" + i + j;
                _wallQuad.transform.position = new Vector3(_roomToGenerate.position.x + i + _offsetPivotPoint, 
                                                           _roomToGenerate.position.y + j + _offsetPivotPoint, 0);
                _wallQuad.transform.Rotate(0, 180, 0, Space.World);
            }
        }

        // Right wall
        for (int i = 0; i < _roomToGenerate.height; i++)
        {
            for (int j = 0; j < _roomToGenerate.roomHeight; j++)
            {
                GameObject _wallQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _wallQuad.name = "WallQuadRight" + i + j;
                _wallQuad.transform.position = new Vector3(_roomToGenerate.position.x + _roomToGenerate.width, 
                                                           _roomToGenerate.position.y + j + _offsetPivotPoint, 
                                                           i + _offsetPivotPoint);
                _wallQuad.transform.Rotate(0, 90, 0, Space.World);
            }
        }

        // Upper wall
        for (int i = 0; i < _roomToGenerate.width; i++)
        {
            for (int j = 0; j < _roomToGenerate.roomHeight; j++)
            {
                GameObject _wallQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _wallQuad.name = "WallQuadUpper" + i + j;
                _wallQuad.transform.position = new Vector3(_roomToGenerate.position.x + i + _offsetPivotPoint,
                                                           _roomToGenerate.position.y + j + _offsetPivotPoint,
                                                           _roomToGenerate.height);
                _wallQuad.transform.Rotate(0, 0, 0, Space.World);
            }
        }

        // Upper wall
        for (int i = 0; i < _roomToGenerate.height; i++)
        {
            for (int j = 0; j < _roomToGenerate.roomHeight; j++)
            {
                GameObject _wallQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _wallQuad.name = "WallQuadLeft" + i + j;
                _wallQuad.transform.position = new Vector3(_roomToGenerate.position.x,
                                                           _roomToGenerate.position.y + j + _offsetPivotPoint,
                                                           i + _offsetPivotPoint);
                _wallQuad.transform.Rotate(0, -90, 0, Space.World);
            }
        }
    }
}
