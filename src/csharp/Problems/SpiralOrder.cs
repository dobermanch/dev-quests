//https://leetcode.com/problems/spiral-matrix/
public class SpiralOrder {

    public static void Run(){
        //var d = Run(new int[][] { new [] { 1,2,3 }, new [] { 4,5,6 }, new [] { 7,8,9 }}); //[1,2,3,6,9,8,7,4,5]
        var d = Run(new int[][] { new [] { 1,2,3,4 }, new [] { 5,6,7,8 }, new [] { 9,10,11,12 }}); //[1,2,3,4,8,12,11,10,9,5,6,7]
        //var d = Run(new int[][] { new [] { 1,2,3,4,5 }, new [] { 6,7,8,9,10 }, new [] { 11,12,13,14,15 }, new [] { 16,17,18,19,20 }, new [] { 21,22,23,24,25 }}); //[1,2,3,4,5,10,15,20,25,24,23,22,21,16,11,6,7,8,9,14,19,18,17,12,13]
    }

    private static IList<int> Run(int[][] matrix)
    {
        var width = matrix[0].Length;
        var height = matrix.Length;
        var lenght = width * height;

        var result = new List<int>(lenght);
        var x = 0;
        var y = 0;
        var dy = 1;
        var dx = 1;

        while(result.Count < lenght)
        {
            result.Add(matrix[y][x]);

            if (y == dy - 1 && x < width - dx)
            {
                x++;
            }
            else if (x == width - dx && y < height - dy)
            {
                y++;
            }
            else if (x > dx - 1)
            {
                x--;
            }
            else if (y > dy)
            {
                y--;
                if (y == dy && x == dx - 1)
                {
                    dx++;
                    dy++;
                }
            }
        }

        return result;
    }
}