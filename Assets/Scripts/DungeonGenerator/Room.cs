using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room object
/// - width, height and depth are defined as int because dungeon is grid based
/// </summary>
public class Room {

    private int _id { get; set; }
    public int width { get; set; }
    public int depth { get; set; }
    public int roomHeight { get; set; }
    public Vector2 position { get; set; }
    private bool _isStartRoom;
    private bool _isEndRoom;
    private Utils.Direction _directionToNextRoom;
    private Utils.Theme _theme;
}
