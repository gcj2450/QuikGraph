using System.Collections.Generic;
using UnityEngine;

public class Pipe
{
    public Vector2Int Location { get; private set; }
    public Grid ParentGrid { get; private set; }
    public Sprite Graphic { get; private set; }
    public List<Direction> ConnectionDirections { get; private set; }
    public bool Filled { get; private set; }
    public bool Leaked { get; private set; }
    public bool Pump { get; private set; }
    public string Type { get; private set; }
    public bool Replaceable { get; private set; }
    public bool CanLeak { get; private set; }

    public Pipe(Sprite graphic, List<Direction> connectionDirections, string type, bool replaceable, bool canLeak = true)
    {
        Location = Vector2Int.zero;
        ParentGrid = null;
        Graphic = graphic;
        ConnectionDirections = connectionDirections;
        Filled = false;
        Leaked = false;
        Pump = false;
        Type = type;
        Replaceable = replaceable;
        CanLeak = canLeak;
    }

    public void Attach(Grid grid, Vector2Int location)
    {
        ParentGrid = grid;
        Location = location;
    }

    public void Detach()
    {
        if (ParentGrid == null)
            return;

        var parent = ParentGrid;
        ParentGrid = null;
        parent.RemovePipe(this);
        Location = Vector2Int.zero;
    }

    public void Fill(Direction dir, List<Pipe> filledPipes = null)
    {
        if (filledPipes == null)
        {
            filledPipes = new List<Pipe>();
        }

        if (filledPipes.Contains(this))
        {
            return;
        }

        filledPipes.Add(this);

        if (Filled && Type != "Drain")
        {
            var pipeArray = GetConnections(dir);

            if (CanLeak && GetConnections(null).Count != ConnectionDirections.Count)
            {
                Leaked = true;
            }

            foreach (var pipe in pipeArray)
            {
                var delta = Location - pipe.Location;
                pipe.Fill(Direction.FromVector(delta), filledPipes);
            }
        }
        else
        {
            Filled = true;
        }
    }

    public void Draw(SpriteRenderer renderer, float x, float y)
    {
        renderer.sprite = Graphic;
        renderer.transform.position = new Vector3(x, y, 0);
    }

    public List<Pipe> GetConnections(Direction dir)
    {
        var pipeArray = new List<Pipe>();
        var pipeUp = ParentGrid.GetPipe(Location + Direction.Up.Delta);
        var pipeDown = ParentGrid.GetPipe(Location + Direction.Down.Delta);
        var pipeRight = ParentGrid.GetPipe(Location + Direction.Right.Delta);
        var pipeLeft = ParentGrid.GetPipe(Location + Direction.Left.Delta);

        if (dir== Direction.Up)
        {
            pipeUp = null;
        }
        else if (dir == Direction.Down)
        {
            pipeDown = null;
        }
        else if (dir == Direction.Right)
        {
            pipeRight = null;
        }
        else if (dir == Direction.Left)
        {
            pipeLeft = null;
        }

        foreach (var direction in ConnectionDirections)
        {
            if (dir == Direction.Up)
            {
                if (pipeUp != null && pipeUp.ConnectionDirections.Contains(Direction.Down))
                {
                    pipeArray.Add(pipeUp);
                }
            }
            else if (dir == Direction.Down)
            {
                if (pipeDown != null && pipeDown.ConnectionDirections.Contains(Direction.Up))
                {
                    pipeArray.Add(pipeDown);
                }
            }
            else if (dir == Direction.Right)
            {
                if (pipeRight != null && pipeRight.ConnectionDirections.Contains(Direction.Left))
                {
                    pipeArray.Add(pipeRight);
                }
            }
            else if (dir == Direction.Left)
            {
                if (pipeLeft != null && pipeLeft.ConnectionDirections.Contains(Direction.Right))
                {
                    pipeArray.Add(pipeLeft);
                }
            }
        }

        return pipeArray;
    }

    public void Update(float deltaTime)
    {
        // Update logic if needed
    }

    public bool ConnectedToPump()
    {
        var pipeArray = GetConnections(null);
        foreach (var pipe in pipeArray)
        {
            if (pipe.Pump)
            {
                return true;
            }
        }
        return false;
    }

    public void SetAsPump()
    {
        Pump = true;
    }

    public bool IsPump()
    {
        return Pump;
    }

    public bool IsFilled()
    {
        return Filled;
    }
    public bool IsLeaking()
    {
        return Leaked;
    }

    public bool CanReplace()
    {
        return !Filled && Replaceable;
    }
}
