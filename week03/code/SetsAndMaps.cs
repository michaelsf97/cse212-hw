using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)


    {
          // This load all words in this set instantly
        var wordSet = new HashSet<string>(words);
        var results = new List<string>();
        
        // Search pairs asymmetric 
        foreach (var word in words)
        {
            // If the word was paired and erase out, release it.
            if (!wordSet.Contains(word))
            {
                continue;
            }

            string reverseWord = $"{word[1]}{word[0]}";
            // Special Case: Bypass words where letters are same  like 'bb'.
            if (word == reverseWord)
            {
                continue;
            }

            if (wordSet.Contains(reverseWord))
            {
                if(word[0] < reverseWord[0])
                {
                    results.Add($"{word} & {reverseWord}");
                }
                else
                {
                    results.Add($"{reverseWord} & {word}");
                }

                // Remove the pair from the set to avoid re-processing.
                wordSet.Remove(word);
                wordSet.Remove(reverseWord);
            }
        }


        
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            //1. Split the comma-separated line into fields.
            string[] fields = line.Split(",");

            // Safety check: make sure the line actually has enough columns

            if (fields.Length >= 4)
            {

                //2. Extract column 4 (index 3) and trim any accidental spaces.
                string degree = fields[3].Trim();
                
                //3. Updates the dictionary count using hashing logic
            if (degrees.ContainsKey(degree))
            {

                //4. If its already there, increment the count by 1.
                degrees[degree]++;
            }
            else
            {
                //5. If it's a brand new degree, start it at 1.
                degrees[degree] = 1;
            }
            
            
        }

        
    }
        return degrees;
     }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letterCounts = new Dictionary<char, int>();

        //1. Register and clean letters in word1
        foreach (char c in word1.ToLower())
        {
            //Ignore spaces according instructions
            if (c == ' ')
            {
                continue;
            }

            if (letterCounts.ContainsKey(c))
            {
                letterCounts[c]++;
            }
            else
            {
                letterCounts[c] = 1;
            }
        }


            // 2. Reduce letters in word2
            foreach (char c in word2.ToLower())
            {
                if (c ==  ' ')
                {
                    continue;
                }

                // If word2 does have a letter that did not appear in word1, this is not an anagram.
                if (!letterCounts.ContainsKey(c))
                {
                    return false;
                }

                letterCounts[c]--;

            }

            // 3. Check if all functions are balanced in 0.
            foreach (var pair in letterCounts)
            {
                if(pair.Value != 0)
                {
                    return false;
                }
            }

            // If al filters are passed, !It is a perfect anagram!

            return true;
        }
        // TODO Problem 3 - ADD YOUR CODE HERE
    

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        return EarthquakeDailySummary(json);
    }

        public static string[] EarthquakeDailySummary(string json)
    {
        // 1. We are using the mold step 1 to open text JSON automatic form.
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        if (data == null || data.features == null)
        {
            return results.ToArray();
        }

        // 2.  We are reviewing each earthquake one by one
        foreach (var feature in data.features)
        {
            if (feature.properties != null)
            {
                string place = feature.properties.place;
                double magnitude = feature.properties.mag;

                // 3. Save it in a clean text.
                results.Add($"{place} - Mag {magnitude}");
            }
        }

        // 4. We return result to a teacher
        return results.ToArray();
    }

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magnitude.
        // 3. Return an array of these string descriptions.

    
    }
