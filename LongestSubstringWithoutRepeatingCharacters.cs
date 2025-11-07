namespace DSA_Practice;

public class LongestSubstringWithoutRepeatingCharacters
{
    public static void Execute()
    {
        LongestSubstring("abcdbea");
    }

    private static int LongestSubstring(String s)
    {
        int maxLength = 0;
        int windowStart = 0;
        Dictionary<char, int> charFrequency = new Dictionary<char, int>();
    
        for (int windowEnd = 0; windowEnd < s.Length; windowEnd++) 
        {
            char currentChar = s[windowEnd];
        
            charFrequency[currentChar] = charFrequency.GetValueOrDefault(currentChar, 0) + 1;
        
            // Shrink window from left until no duplicates exist
            while (charFrequency[currentChar] > 1) 
            {
                char leftChar = s[windowStart];
                charFrequency[leftChar]--;
                windowStart++;
            }
        
            int currentWindowSize = windowEnd - windowStart + 1;
            maxLength = Math.Max(maxLength, currentWindowSize);
        }
    
        return maxLength;
    }
    
    public static int LongestSubstringWithoutRepeatingCharacters2(string s) 
    {
        int maxLength = 0;
        int windowStart = 0;
        Dictionary<char, int> lastSeenPosition = new Dictionary<char, int>();
    
        for (int windowEnd = 0; windowEnd < s.Length; windowEnd++) 
        {
            char currentChar = s[windowEnd];
        
            // If character was seen before and is within current window,
            // move window start to position after the last occurrence
            if (lastSeenPosition.ContainsKey(currentChar)) 
            {
                windowStart = Math.Max(windowStart, lastSeenPosition[currentChar] + 1);
            }
        
            // Update the last seen position of current character
            lastSeenPosition[currentChar] = windowEnd;
        
            // Update maximum length
            maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
        }
    
        return maxLength;
    }
}