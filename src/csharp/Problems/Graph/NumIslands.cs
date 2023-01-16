//https://leetcode.com/problems/number-of-islands/description
public class NumIslands {

    public static void Run(){
        var d = Run(new char[][] { 
                new [] {'1','1','0','0','0'},
                new [] {'1','1','0','0','0'},
                new [] {'0','0','1','0','0'},
                new [] {'0','0','0','1','1'}
            });
    }
//OPTION 1
    private static int Run(char[][] grid) 
    {
        var result = 0;
        var height = grid.Length;
        var width = grid[0].Length;
        var visited = new bool[height, width];

        for(var y = 0; y < grid.Length; y++)
        {
            for(var x = 0; x < grid[y].Length; x++)
            {
                if (visited[y,x] || grid[y][x] == '0')
                {
                    visited[y,x] = true;
                    continue;
                }

                var stack = new Stack<(int x, int y)>();
                stack.Push((x,y));
                (int x, int y) current;
                while(stack.Any()) 
                {
                    current = stack.Pop();

                    if (current.y < 0 || current.y >= height
                        || current.x < 0 || current.x >= width
                        || visited[current.y, current.x])
                    {
                        continue;
                    }

                    visited[current.y, current.x] = true;

                    if (grid[current.y][current.x] == '0')
                    {
                        continue;
                    }

                    stack.Push((current.x + 1, current.y));
                    stack.Push((current.x - 1, current.y));
                    stack.Push((current.x, current.y + 1));
                    stack.Push((current.x, current.y - 1));
                }

                result++;
            }
        }

        return result;
    }

//OPTION 1
    // private static int Run(char[][] grid)
    // {
    //     var result = 0;
    //     var visited = new bool[grid.Length, grid[0].Length];
    //     for(var y = 0; y < grid.Length; y++)
    //     {
    //         for(var x = 0; x < grid[y].Length; x++)
    //         {
    //             if (!visited[y,x] && grid[y][x] == '1')
    //             {
    //                 result += Search(grid, x, y, visited);
    //             }

    //             visited[y,x] = true;
    //         }
    //     }

    //     return result;
    // }

    // private static int Search(char[][] grid, int x, int y, bool[,] visited)
    // {
    //     if (y < 0 || y >= grid.Length
    //      || x < 0 || x >= grid[y].Length
    //      || visited[y,x])
    //     {
    //         return 0;
    //     }

    //     visited[y,x] = true;

    //     if (grid[y][x] == '0')
    //     {
    //         return 0;
    //     }

    //     Search(grid, x + 1, y, visited);
    //     Search(grid, x - 1, y, visited);
    //     Search(grid, x, y + 1, visited);
    //     Search(grid, x, y - 1, visited);

    //     return 1;
    // }
}
