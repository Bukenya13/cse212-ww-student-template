using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze;
    private (int x, int y) currentPosition;

    public Maze(Dictionary<(int, int), (bool, bool, bool, bool)> map)
    {
        maze = map;
        currentPosition = (1, 1);
    }

    public (int, int) GetCurrentPosition() => currentPosition;

    // ---------------------------------------------------------------
    // Move Left
    // ---------------------------------------------------------------
    public bool MoveLeft()
    {
        if (!maze.ContainsKey(currentPosition)) return false;

        var paths = maze[currentPosition];

        if (!paths.left) return false;

        currentPosition = (currentPosition.x - 1, currentPosition.y);
        return true;
    }

    // ---------------------------------------------------------------
    // Move Right
    // ---------------------------------------------------------------
    public bool MoveRight()
    {
        if (!maze.ContainsKey(currentPosition)) return false;

        var paths = maze[currentPosition];

        if (!paths.right) return false;

        currentPosition = (currentPosition.x + 1, currentPosition.y);
        return true;
    }

    // ---------------------------------------------------------------
    // Move Up
    // ---------------------------------------------------------------
    public bool MoveUp()
    {
        if (!maze.ContainsKey(currentPosition)) return false;

        var paths = maze[currentPosition];

        if (!paths.up) return false;

        currentPosition = (currentPosition.x, currentPosition.y + 1);
        return true;
    }

    // ---------------------------------------------------------------
    // Move Down
    // ---------------------------------------------------------------
    public bool MoveDown()
    {
        if (!maze.ContainsKey(currentPosition)) return false;

        var paths = maze[currentPosition];

        if (!paths.down) return false;

        currentPosition = (currentPosition.x, currentPosition.y - 1);
        return true;
    }
}
