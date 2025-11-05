namespace DSA_Practice;

//1710. https://leetcode.com/problems/maximum-units-on-a-truck/description/
public static class MaximumUnitsOnATruck
{
    public static void Execute()
    {
        MaximumUnits([[5, 10], [2, 5], [4, 7], [3, 9]], 10);
    }
    
   // The lambda (a, b) takes two elements from the array and compares them:
   // a[1] - Gets the second element (index 1) of the first box type
   //     b[1] - Gets the second element (index 1) of the second box type
   //     b[1] - a[1] - Subtracts them in reverse order
   // The return value determines the order:
   // Negative number → a comes before b
   // Positive number → b comes before a
   // Zero → they stay in the same relative position
    
    private static int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        // var sortedBoxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();

        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);

        var remainingCapacity = truckSize;
        var totalUnits = 0;

        foreach (var t in boxTypes)
        {
            var numberOfBoxes = t[0];
            var unitsPerBoxes = t[1];

            if (numberOfBoxes <= remainingCapacity)
            {
                totalUnits += numberOfBoxes * unitsPerBoxes;
                remainingCapacity -= numberOfBoxes;
            }
            else
            {
                totalUnits += unitsPerBoxes * remainingCapacity;
                break;
            }
        }

        return totalUnits;
    }
    
    public static int MaximumUnits_Solution2(int[][] boxTypes, int truckSize)
    {
        // Sort by units per box descending
        var sorted = boxTypes.OrderByDescending(b => b[1]);

        var totalUnits = 0;

        foreach (var box in sorted)
        {
            var boxCount = box[0];
            var unitsPerBox = box[1];

            // Take as many boxes as possible
            var boxesToTake = Math.Min(truckSize, boxCount);

            totalUnits += boxesToTake * unitsPerBox;
            truckSize -= boxesToTake;

            if (truckSize == 0) break; // truck is full
        }

        return totalUnits;
    }
}