namespace DSA_Practice;

// 1792 https://leetcode.com/problems/maximum-average-pass-ratio/description/
public static class MaxAveragePassRatio
{
    public static void Execute()
    {
      var value =   Solution([[2,4],[3,9],[4,5],[2,10]],4);
    }
    
    public  static double Solution(int[][] classes, int extraStudents) 
    {
        var queue = new PriorityQueue<(double totalStudent, double passedStudent), double>();
        
        for (var j = 0; j < classes.Length; j++)
        {
            double totalStudent = classes[j][1];
            double passedStudent = classes[j][0];
                
            var gain = Gain(passedStudent, totalStudent);
            
            queue.Enqueue((totalStudent,passedStudent),-gain);
        }

        while (extraStudents > 0)
        {
           var element = queue.Dequeue();
           
           double totalStudent = element.totalStudent;
           double passedStudent = element.passedStudent;
                
           var gain = Gain(passedStudent+1, totalStudent+1);

           queue.Enqueue((totalStudent+1,passedStudent+1),-gain);
           extraStudents -= 1;
        }
        
        double totalRatio = 0.0;
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            totalRatio += c.passedStudent / c.totalStudent;
        }
        
        return totalRatio/classes.Length;
    }

    private static double Gain(double passedStudent, double totalStudent)
    {
        double ratio = passedStudent/totalStudent;
        double newRatio = (passedStudent+1)/(totalStudent+1);
        return newRatio - ratio;
    }
}