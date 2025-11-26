using System;
using System.Collections.Generic;

public static class Recursion
{
    // Problem 1: Sum of squares
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2: All k-length permutations
    public static void PermutationsChoose(List<string> results, string input, int k)
    {
        void Helper(string prefix, string remaining)
        {
            if (prefix.Length == k)
            {
                results.Add(prefix);
                return;
            }

            for (int i = 0; i < remaining.Length; i++)
            {
                Helper(prefix + remaining[i], remaining.Substring(0, i) + remaining.Substring(i + 1));
            }
        }

        Helper("", input);
    }

    // Problem 3: Count ways to climb stairs (1,2,3 steps)
    public static long CountWaysToClimb(int n)
    {
        if (n < 0) return 0;
        if (n == 0) return 1;

        long[] dp = new long[n + 1];
        dp[0] = 1;

        for (int i = 1; i <= n; i++)
        {
            dp[i] = 0;
            if (i - 1 >= 0) dp[i] += dp[i - 1];
            if (i - 2 >= 0) dp[i] += dp[i - 2];
            if (i - 3 >= 0) dp[i] += dp[i - 3];
        }

        return dp[n];
    }

    // Problem 4: Wildcard binary
    public static void WildcardBinary(string pattern, List<string> results)
    {
        void Helper(char[] arr, int pos)
        {
            if (pos == arr.Length)
            {
                results.Add(new string(arr));
                return;
            }

            if (arr[pos] == '*')
            {
                arr[pos] = '0';
                Helper(arr, pos + 1);
                arr[pos] = '1';
                Helper(arr, pos + 1);
                arr[pos] = '*';
            }
            else
            {
                Helper(arr, pos + 1);
            }
        }

        Helper(pattern.ToCharArray(), 0);
    }

    // Problem 5: Solve maze
    public static void SolveMaze(List<string> results, Maze maze)
    {
        void Helper(List<(int, int)> path, int x, int y)
        {
            if (!maze.IsValidMove(path, x, y)) return;

            path.Add((x, y));

            if (maze.IsEnd(x, y))
            {
                results.Add($"<List>{{{string.Join(", ", path)}}}");
            }
            else
            {
                Helper(new List<(int, int)>(path), x + 1, y);
                Helper(new List<(int, int)>(path), x - 1, y);
                Helper(new List<(int, int)>(path), x, y + 1);
                Helper(new List<(int, int)>(path), x, y - 1);
            }
        }

        Helper(new List<(int, int)>(), 0, 0);
    }
}
