class Program
{
    static char[,] grid = new char[3, 3];

    static void Main(string[] args)
    {
        InitializeGrid();

        while (true)
        {
            DisplayGrid();

            PlayMove('X');

            if (CheckWinner('X'))
            {
                Console.WriteLine("Player X wins!");
                break;
            }

            if (IsDraw())
            {
                Console.WriteLine("Draw!");
                break;
            }

            DisplayGrid();

            PlayMove('O');

            if (CheckWinner('O'))
            {
                Console.WriteLine("Player O wins!");
                break;
            }

            if (IsDraw())
            {
                Console.WriteLine("Draw!");
                break;
            }
        }
    }

    static void InitializeGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                grid[i, j] = ' ';
            }
        }
    }

    static void DisplayGrid()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void PlayMove(char player)
    {
        while (true)
        {
            Console.WriteLine("Player " + player + ", enter the coordinates (row column) of your move: ");
            string[] input = Console.ReadLine().Split(' ');
            int row = int.Parse(input[0]);
            int column = int.Parse(input[1]);

            if (IsValidMove(row, column))
            {
                grid[row, column] = player;
                break;
            }
            else
            {
                Console.WriteLine("Invalid move. Please try again.");
            }
        }
    }

    static bool IsValidMove(int row, int column)
    {
        if (row < 0 || row >= 3 || column < 0 || column >= 3)
        {
            return false;
        }
        if (grid[row, column] != ' ')
        {
            return false;
        }
        return true;
    }

    static bool CheckWinner(char player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                return true;
            if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                return true;
        }

        if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
            return true;
        if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
            return true;

        return false;
    }

    static bool IsDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (grid[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}