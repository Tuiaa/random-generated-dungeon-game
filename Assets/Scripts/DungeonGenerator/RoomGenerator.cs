using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates a room according to Room object
/// </summary>
public class RoomGenerator
{

    [SerializeField]
    private float _offsetPivotPoint = 0.5f;
    [SerializeField]
    private int _borderThickness = 2;

    private Room _roomToGenerate;
    private GameObject _roomParent;

    public void CreateRoom(Room room)
    {
        _roomToGenerate = room;

        if (_roomToGenerate != null)
        {
            _roomParent = new GameObject();
            _roomParent.name = "RoomParent";

            CreateFloor();
            CreateWalls();

            // TODO: Fix so it works on other values too
            //CreateBorders();
        }
    }

    /// <summary>
    /// Creates floor of a room
    /// </summary>
    private void CreateFloor()
    {
        for (int j = 0; j < _roomToGenerate.depth; j++)
        {
            for (int i = 0; i < _roomToGenerate.width; i++)
            {
                GameObject _floorQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _floorQuad.name = "FloorQuad" + j + i;
                _floorQuad.transform.position = new Vector3(_roomToGenerate.position.x + i + _offsetPivotPoint, 0, _roomToGenerate.position.y + j + _offsetPivotPoint);
                _floorQuad.transform.Rotate(90, 0, 0, Space.World);
                _floorQuad.transform.parent = _roomParent.transform;
            }
        }
    }

    /// <summary>
    /// Creates walls around a room
    /// </summary>
    private void CreateWalls()
    {
        // Bottom wall
        GameObject _wallQuadBottom = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadBottom.name = "WallQuadBottom";

        // Casting from int to float so we get correct values from calculations
        float posX = _roomToGenerate.position.x + (float)_roomToGenerate.width / 2;
        float posY = (float)_roomToGenerate.roomHeight / 2;
        float posZ = _roomToGenerate.position.y;

        _wallQuadBottom.transform.position = new Vector3(posX, posY, posZ);
        _wallQuadBottom.transform.localScale = new Vector3(_roomToGenerate.width, _roomToGenerate.roomHeight, 1);
        _wallQuadBottom.transform.Rotate(0, 180, 0, Space.World);
        _wallQuadBottom.transform.parent = _roomParent.transform;

        // Upper wall
         GameObject _wallQuadUp = GameObject.CreatePrimitive(PrimitiveType.Quad);
         _wallQuadUp.name = "WallQuadUp";

        // Casting from int to float so we get correct values from calculations
        float posXUp = _roomToGenerate.position.x + (float)_roomToGenerate.width / 2;
        float posYUp = (float)_roomToGenerate.roomHeight / 2;
        float posZUp = _roomToGenerate.position.y + _roomToGenerate.depth;
        
        _wallQuadUp.transform.position = new Vector3(posXUp, posYUp, posZUp);
        _wallQuadUp.transform.localScale = new Vector3(_roomToGenerate.width, _roomToGenerate.roomHeight, 1);
        _wallQuadUp.transform.Rotate(0, 0, 0, Space.World);
        _wallQuadUp.transform.parent = _roomParent.transform;

        // Left wall
        GameObject _wallQuadLeft = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadLeft.name = "WallQuadLeft";

        // Casting from int to float so we get correct values from calculations
        float posXLeft = _roomToGenerate.position.x;
        float posYLeft = (float)_roomToGenerate.roomHeight / 2;
        float posZLeft = _roomToGenerate.position.y + (float)_roomToGenerate.depth / 2;

        _wallQuadLeft.transform.position = new Vector3(posXLeft, posYLeft, posZLeft);
        _wallQuadLeft.transform.localScale = new Vector3(_roomToGenerate.depth, _roomToGenerate.roomHeight, 1);
        _wallQuadLeft.transform.Rotate(0, -90, 0, Space.World);
        _wallQuadLeft.transform.parent = _roomParent.transform;

        // Right wall
        GameObject _wallQuadRight = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadRight.name = "WallQuadRight";

        // Casting from int to float so we get correct values from calculations
        float posXRight = _roomToGenerate.position.x + _roomToGenerate.width;
        float posYRight = (float)_roomToGenerate.roomHeight / 2;
        float posZRight = _roomToGenerate.position.y + (float)_roomToGenerate.depth / 2;

        _wallQuadRight.transform.position = new Vector3(posXRight, posYRight, posZRight);
        _wallQuadRight.transform.localScale = new Vector3(_roomToGenerate.depth, _roomToGenerate.roomHeight, 1);
        _wallQuadRight.transform.Rotate(0, 90, 0, Space.World);
        _wallQuadRight.transform.parent = _roomParent.transform;
    }

    /// <summary>
    /// Creates borders between rooms
    /// </summary>
    private void CreateBorders()
    {
        // Bottom wall border
        GameObject _borderQuadBottom = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _borderQuadBottom.name = "BorderQuadBottom";
        _borderQuadBottom.transform.position = new Vector3(_roomToGenerate.position.x + _roomToGenerate.width / 2,
                                                           _roomToGenerate.position.y + _roomToGenerate.roomHeight,
                                                           -_borderThickness / 2);
        _borderQuadBottom.transform.localScale = new Vector3(_roomToGenerate.width, _borderThickness, 1);
        _borderQuadBottom.transform.Rotate(90, 0, 0, Space.World);
        _borderQuadBottom.transform.parent = _roomParent.transform;

        // Upper wall border
        GameObject _borderQuadUp = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _borderQuadUp.name = "BorderQuadUp";
        _borderQuadUp.transform.position = new Vector3(_roomToGenerate.position.x + _roomToGenerate.width / 2,
                                                       _roomToGenerate.position.y + _roomToGenerate.roomHeight,
                                                       _roomToGenerate.depth + _borderThickness / 2);
        _borderQuadUp.transform.localScale = new Vector3(_roomToGenerate.width, _borderThickness, 1);
        _borderQuadUp.transform.Rotate(90, 0, 0, Space.World);
        _borderQuadUp.transform.parent = _roomParent.transform;

        // Right wall border
        GameObject _borderQuadRight = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _borderQuadRight.name = "BorderQuadRight";
        _borderQuadRight.transform.position = new Vector3(_roomToGenerate.width +_borderThickness / 2,
                                                       _roomToGenerate.position.y + _roomToGenerate.roomHeight,
                                                       _roomToGenerate.depth / 2 + _offsetPivotPoint);
        _borderQuadRight.transform.localScale = new Vector3(_roomToGenerate.depth + _borderThickness * 2, _borderThickness, 1);
        _borderQuadRight.transform.Rotate(90, 90, 0, Space.World);
        _borderQuadRight.transform.parent = _roomParent.transform;

        // Left wall border
        GameObject _borderQuadLeft = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _borderQuadLeft.name = "BorderQuadLeft";
        _borderQuadLeft.transform.position = new Vector3(_roomToGenerate.position.x - _borderThickness / 2,
                                                       _roomToGenerate.position.y + _roomToGenerate.roomHeight,
                                                       _roomToGenerate.depth / 2 + _offsetPivotPoint);
        _borderQuadLeft.transform.localScale = new Vector3(_roomToGenerate.depth + _borderThickness * 2, _borderThickness, 1);
        _borderQuadLeft.transform.Rotate(90, 90, 0, Space.World);
        _borderQuadLeft.transform.parent = _roomParent.transform;
    }
}
