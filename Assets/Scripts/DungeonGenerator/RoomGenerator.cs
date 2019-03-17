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
            // TODO: Fix so it works on other values too
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
        for (int i = 0; i < _roomToGenerate.width; i++)
        {
            for (int j = 0; j < _roomToGenerate.depth; j++)
            {
                GameObject _floorQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                _floorQuad.name = "FloorQuad" + i + j;
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
        _wallQuadBottom.transform.position = new Vector3(_roomToGenerate.position.x + _roomToGenerate.width / 2,
                                                         _roomToGenerate.position.y + _roomToGenerate.roomHeight / 2, 0);
        _wallQuadBottom.transform.localScale = new Vector3(_roomToGenerate.width, _roomToGenerate.roomHeight, 1);
        _wallQuadBottom.transform.Rotate(180, 0, 0, Space.World);
        _wallQuadBottom.transform.parent = _roomParent.transform;

        // Upper wall
        GameObject _wallQuadUp = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadUp.name = "WallQuadUp";
        _wallQuadUp.transform.position = new Vector3(_roomToGenerate.position.x + _roomToGenerate.width / 2,
                                                     _roomToGenerate.position.y + _roomToGenerate.roomHeight / 2,
                                                     _roomToGenerate.depth);
        _wallQuadUp.transform.localScale = new Vector3(_roomToGenerate.width, _roomToGenerate.roomHeight, 1);
        _wallQuadUp.transform.Rotate(0, 0, 0, Space.World);
        _wallQuadUp.transform.parent = _roomParent.transform;

        // Right wall
        GameObject _wallQuadRight = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadRight.name = "WallQuadRight";
        _wallQuadRight.transform.position = new Vector3(_roomToGenerate.width,
                                                        _roomToGenerate.roomHeight / 2,
                                                        _roomToGenerate.depth / 2 + _offsetPivotPoint);
        _wallQuadRight.transform.localScale = new Vector3(_roomToGenerate.depth, _roomToGenerate.roomHeight, 1);
        _wallQuadRight.transform.Rotate(0, 90, 0, Space.World);
        _wallQuadRight.transform.parent = _roomParent.transform;

        // Left wall
        GameObject _wallQuadLeft = GameObject.CreatePrimitive(PrimitiveType.Quad);
        _wallQuadLeft.name = "WallQuadLeft";
        _wallQuadLeft.transform.position = new Vector3(_roomToGenerate.position.x,
                                                       _roomToGenerate.roomHeight / 2,
                                                       _roomToGenerate.depth / 2 + _offsetPivotPoint);
        _wallQuadLeft.transform.localScale = new Vector3(_roomToGenerate.depth, _roomToGenerate.roomHeight, 1);
        _wallQuadLeft.transform.Rotate(0, -90, 0, Space.World);
        _wallQuadLeft.transform.parent = _roomParent.transform;
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
