using System.Collections.Generic;
public class FeatureCollection
{
    public List<EarthquakeFeature> features { get; set; } = new();
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
}

public class EarthquakeFeature
{
    public EarthquakeProperties properties { get; set; } = new();
}

public class EarthquakeProperties
{
    public double mag { get; set; }
    public string place { get; set; } = "";
}

