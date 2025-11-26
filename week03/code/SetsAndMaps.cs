using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // -----------------------------------------------------------
    // 1. FindPairs
    // -----------------------------------------------------------
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> pairs = new List<string>();

        foreach (string w in words)
        {
            // Skip same letters like "aa"
            if (w.Length != 2 || w[0] == w[1])
                continue;

            string rev = new string(new[] { w[1], w[0] });

            // If the reverse exists in set, make pair
            if (seen.Contains(rev))
            {
                // Tests expect: "rev & w" (e.g., "ma & am")
                pairs.Add($"{rev} & {w}");
            }

            seen.Add(w);
        }

        return pairs.ToArray();
    }

    // -----------------------------------------------------------
    // 2. SummarizeDegrees
    // -----------------------------------------------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // The file is CSV-like, column 4 is degree
            var parts = line.Split(',');
            if (parts.Length < 4)
                continue;

            string degree = parts[3].Trim();

            if (!result.ContainsKey(degree))
                result[degree] = 0;

            result[degree]++;
        }

        return result;
    }

    // -----------------------------------------------------------
    // 3. IsAnagram
    // -----------------------------------------------------------
    public static bool IsAnagram(string a, string b)
    {
        // Normalize: remove spaces, lowercase
        a = new string(a.Where(c => c != ' ').Select(char.ToLower).ToArray());
        b = new string(b.Where(c => c != ' ').Select(char.ToLower).ToArray());

        if (a.Length != b.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        // Count chars in a
        foreach (char c in a)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        // Subtract for chars in b
        foreach (char c in b)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;
            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // -----------------------------------------------------------
    // 5. Earthquake JSON Data
    // -----------------------------------------------------------

    private class FeatureCollection
    {
        public List<Feature>? features { get; set; }
    }

    private class Feature
    {
        public Properties? properties { get; set; }
    }

    private class Properties
    {
        public string? place { get; set; }
        public double? mag { get; set; }
        public long? time { get; set; }
    }

    public static string[] EarthquakeDailySummary()
    {
        using HttpClient client = new HttpClient();

        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        string json = client.GetStringAsync(url).Result;

        var data = JsonSerializer.Deserialize<FeatureCollection>(json);

        if (data?.features == null)
            return Array.Empty<string>();

        List<string> results = new List<string>();

        foreach (var f in data.features)
        {
            if (f.properties == null) continue;

            string place = f.properties.place ?? "Unknown location";
            double mag = f.properties.mag ?? 0.0;

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}
