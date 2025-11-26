using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int, int), bool[]> _map;
    private int _x = 1;
    private int _y = 1;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        _map = map;
    }

    public string GetStatus()
    {
        return $"Current location (x={_x}, y={_y})";
    }

    private void Fail()
    {
        throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveLeft()
    {
        var moves = _map[(_x, _y)];
        if (!moves[0])
            Fail();

        _x -= 1;
    }

    public void MoveRight()
    {
        var moves = _map[(_x, _y)];
        if (!moves[1])
            Fail();

        _x += 1;
    }

    public void MoveUp()
    {
        var moves = _map[(_x, _y)];
        if (!moves[2])
            Fail();

        _y += 1;
    }

    public void MoveDown()
    {
        var moves = _map[(_x, _y)];
        if (!moves[3])
            Fail();

        _y -= 1;
    }
}
