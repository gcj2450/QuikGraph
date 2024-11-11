using System.Collections.Generic;
using UnityEngine;

public class Pipes
{
    public static readonly PipeType Vertical = new PipeType(0, "gfx/vertical.png", new List<Direction> { Direction.Up, Direction.Down }, true);
    public static readonly PipeType Horizontal = new PipeType(1, "gfx/horizontal.png", new List<Direction> { Direction.Left, Direction.Right }, true);
    public static readonly PipeType RightDown = new PipeType(2, "gfx/rightDown.png", new List<Direction> { Direction.Right, Direction.Down }, true);
    public static readonly PipeType LeftDown = new PipeType(3, "gfx/leftDown.png", new List<Direction> { Direction.Left, Direction.Down }, true);
    public static readonly PipeType RightUp = new PipeType(4, "gfx/rightUp.png", new List<Direction> { Direction.Right, Direction.Up }, true);
    public static readonly PipeType LeftUp = new PipeType(5, "gfx/leftUp.png", new List<Direction> { Direction.Left, Direction.Up }, true);

    public static readonly PipeType FixedVertical = new PipeType(6, "gfx/vertical.png", new List<Direction> { Direction.Up, Direction.Down }, false);
    public static readonly PipeType FixedHorizontal = new PipeType(7, "gfx/horizontal.png", new List<Direction> { Direction.Left, Direction.Right }, false);
    public static readonly PipeType FixedRightDown = new PipeType(8, "gfx/rightDown.png", new List<Direction> { Direction.Right, Direction.Down }, false);
    public static readonly PipeType FixedLeftDown = new PipeType(9, "gfx/leftDown.png", new List<Direction> { Direction.Left, Direction.Down }, false);
    public static readonly PipeType FixedRightUp = new PipeType(10, "gfx/rightUp.png", new List<Direction> { Direction.Right, Direction.Up }, false);
    public static readonly PipeType FixedLeftUp = new PipeType(11, "gfx/leftUp.png", new List<Direction> { Direction.Left, Direction.Up }, false);

    public static readonly PipeType Pump = new PipeType(12, "gfx/pump.png", new List<Direction> { Direction.Down }, false, true);
    public static readonly PipeType Drain = new PipeType(13, "gfx/drain.png", new List<Direction> { Direction.Up, Direction.Down, Direction.Left, Direction.Right }, false, false);
    public static readonly PipeType Obstacle = new PipeType(14, "gfx/demoblock.png", new List<Direction>(), false);
    public static readonly PipeType LeftRightDown = new PipeType(15, "gfx/leftRightDown.png", new List<Direction> { Direction.Down, Direction.Left, Direction.Right }, false);
    public static readonly PipeType LeftRightUp = new PipeType(16, "gfx/leftRightUp.png", new List<Direction> { Direction.Up, Direction.Left, Direction.Right }, false);
    public static readonly PipeType LeftUpDown = new PipeType(17, "gfx/leftUpDown.png", new List<Direction> { Direction.Down, Direction.Left, Direction.Up }, false);
    public static readonly PipeType RightUpDown = new PipeType(18, "gfx/rightUpDown.png", new List<Direction> { Direction.Down, Direction.Up, Direction.Right }, false);
    public static readonly PipeType CrossPipe = new PipeType(19, "gfx/crossPipe.png", new List<Direction> { Direction.Down, Direction.Up, Direction.Right, Direction.Left }, false);

    public static List<PipeType> Values(bool includeComplex)
    {
        var array = new List<PipeType>
        {
            Vertical,
            Horizontal,
            RightDown,
            LeftDown,
            RightUp,
            LeftUp
        };

        if (includeComplex)
        {
            array.AddRange(new[] { LeftRightDown, LeftRightUp, LeftUpDown, RightUpDown });
        }

        return array;
    }

    public static List<PipeType> ComplexValues()
    {
        return new List<PipeType> { LeftRightDown, LeftRightUp, LeftUpDown, RightUpDown };
    }

    public static List<PipeType> Obstacles()
    {
        return new List<PipeType>
        {
            Obstacle,
            FixedVertical,
            FixedHorizontal,
            FixedRightDown,
            FixedLeftDown,
            FixedRightUp,
            FixedLeftUp
        };
    }
}

public class PipeType
{
    public int Value { get; }
    public string GraphicPath { get; }
    public List<Direction> Directions { get; }
    public bool Replaceable { get; }
    public bool IsPump { get; }

    public PipeType(int value, string graphicPath, List<Direction> directions, bool replaceable, bool isPump = false)
    {
        Value = value;
        GraphicPath = graphicPath;
        Directions = directions;
        Replaceable = replaceable;
        IsPump = isPump;
    }

    //public Pipe Create()
    //{
    //    var graphic = LoadGraphic(GraphicPath);
    //    var pipe = new Pipe(graphic, Directions, this, Replaceable);
    //    if (IsPump)
    //    {
    //        pipe.SetAsPump();
    //    }
    //    return pipe;
    //}

    //private Sprite LoadGraphic(string path)
    //{
    //    // Load graphic from resources or asset bundle
    //    return Resources.Load<Sprite>(path);
    //}
}