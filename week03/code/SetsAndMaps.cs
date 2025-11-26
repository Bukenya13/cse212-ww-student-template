using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class SetsAndMaps
{
    // ---------------------------------------------------------------
    // Problem 1: FindPairs
    // ---------------------------------------------------------------
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> results = new List<string>();

        foreach (string w in words)
        {
            if (w.Length != 2) continue;

            // Skip palindromes like "aa"
            if (w[0] == w[1]) continue;
1
            string rev = new string(new char[] { w[1], w[0] });

            if (seen.Contains(rev))
                results.Add($"{rev} & {w}");

            seen.Add(w);
        }

        return results.ToArray();
    }

    // ---------------------------------------------------------------
    // Problem 2: Degree Summary
    // ---------------------------------------------------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degreeCount = new Dictionary<string, int>();

        string[] lines = File.ReadAllLines(filename);

        // Skip header line → start at index 1
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');

            if (parts.Length < 4) continue;

            string degree = parts[3].Trim();

            if (!degreeCount.ContainsKey(degree))
                degreeCount[degree] = 0;

            degreeCount[degree]++;
        }

        return degreeCount;
    }

    // ---------------------------------------------------------------
    // Problem 3: Anagram Checker
    // ---------------------------------------------------------------
    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null)
            return false;

        string w1 = new string(word1.ToLower().Where(char.IsLetter).ToArray());
        string w2 = new string(word2.ToLower().Where(char.IsLetter).ToArray());

        if (w1.Length != w2.Length)
            return false;

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }

        foreach (char c in w2)
        {
            if (!freq.ContainsKey(c)) return false;

            freq[c]--;
            if (freq[c] < 0) return false;
        }

        return true;
    }

    // ---------------------------------------------------------------
    // Problem 5: Earthquake JSON Data
    // ---------------------------------------------------------------
    public static string[] EarthquakeDailySummary(string json)
    {
        FeatureCollection data = JsonSerializer.Deserialize<FeatureCollection>(json);

        List<string> results = new List<string>();

        foreach (var feature in data.features)
        {
            string place = feature.properties.place;
            double mag = feature.properties.mag;

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}

// ---------------------------------------------------------------
// JSON classes for Problem 5
// ---------------------------------------------------------------
public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Properties properties { get; set; }
}

public class Properties
{
    public string place { get; set; }
    public double mag { get; set; }
}
