using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {

    private int _id { get; set; }
    public int _width { get; set; }
    public int _height { get; set; }
    public Vector2 _position { get; set; }
    private bool _isStartRoom;
    private bool _isEndRoom;
    private Utils.Direction _directionToNextRoom;
    private Utils.Theme _theme;
}
