/*
    Hayden Hartmann
    2/7/2025
    15-Puzzle : The Catacombs of the class
*/

//Program is not fully working, something worong with the logic in class MoveTile method StartGame were 
//the blank space wont move to certain squares near the edges.

public class MyMain
{
    public static void Main(string[] args)
    {
        ThePuzzle puzzle1 = new ThePuzzle();
        MoveTiles game1 = new MoveTiles(puzzle1);

        puzzle1.PrintBoard();
        game1.StartGame();
        

        Console.ReadLine();
    }
}

public class ThePuzzle
{
    //declaring instance variables
    private int[,] board = new int[4, 4];
    private Random random = new Random();

    //this method creates a random board
    public ThePuzzle()
    {
        int randomInt;
        int[] numbersPicked = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

        //cycles through 1st dimension of board
        for (int firstDimension = 0; firstDimension <= 3; firstDimension++)
        {
            //cycles through 2nd dimension of board
            for (int secondDimension = 0; secondDimension <= 3; secondDimension++)
            {
                //this loops till it finds unused int in numbersPicked array
                while (true)
                {
                    bool valid = false;
                    randomInt = random.Next(1, 17);

                    //cycles through numbersPicked
                    for (int i = 0; i <= 15; i++)
                    {
                        if (numbersPicked[i] != randomInt)
                        {
                            valid = true;
                            continue;
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        numbersPicked[randomInt - 1] = randomInt;
                        break;
                    }
                }
                //sets board at 1st, 2nd to random int
                board[firstDimension, secondDimension] = randomInt;
            }
        }
    }

    //this method prints the board
    public void PrintBoard()
    {
        // cycles through 1st dimension of board
        for (int firstDimension = 0; firstDimension <= 3; firstDimension++)
        {
            //cycles through 2nd dimension of board
            for (int secondDimension = 0; secondDimension <= 3; secondDimension++)
            {
                if (board[firstDimension, secondDimension] == 16)
                {
                    Console.Write($"[  ] ");
                }
                else if (board[firstDimension, secondDimension] >= 10)
                {
                    Console.Write($"[{board[firstDimension, secondDimension]}] ");
                }
                else
                {
                    Console.Write($"[ {board[firstDimension, secondDimension]}] ");
                }
            }
            Console.WriteLine();
        }
    }
    public int[,] GetBoard
    {
        get => board;
        set => board = value;
    }
}

public class MoveTiles
{
    private ThePuzzle _board;

    public MoveTiles(ThePuzzle board)
    {
        _board = board;
    }

    public void StartGame()
    {
        while (true)
        {
            Console.Write("Enter number to move (1-15): ");
            int num = Convert.ToInt32(Console.ReadLine());

            int[] numPosition = new int[2];
            int[] blankPosition = new int[2];

            for (int firstDimension = 0; firstDimension <= 3; firstDimension++)
            {
                for (int secondDimension = 0; secondDimension <= 3; secondDimension++)
                {
                    if (_board.GetBoard[firstDimension, secondDimension] == num)
                    {
                        numPosition[0] = firstDimension;
                        numPosition[1] = secondDimension;   
                    }
                    if (_board.GetBoard[firstDimension, secondDimension] == 16)
                    {
                        blankPosition[0] = firstDimension;
                        blankPosition[1] = secondDimension;
                    }
                }
            }

            //I AM HERE ON THIS PROGRAM

            //This looks complicated, but is just checking that the position of num is next to blank space
            if (_board.GetBoard[blankPosition[0], blankPosition[1]] == _board.GetBoard[numPosition[0], numPosition[1] - 1] ||  //right 1
                _board.GetBoard[blankPosition[0], blankPosition[1]] == _board.GetBoard[numPosition[0], numPosition[1] + 1] ||  //left 1
                _board.GetBoard[blankPosition[0], blankPosition[1]] == _board.GetBoard[numPosition[0] + 1, numPosition[1]] ||  //up 1
                _board.GetBoard[blankPosition[0], blankPosition[1]] == _board.GetBoard[numPosition[0] - 1, numPosition[1]])    //down 1
            {
                //TUPLE DECONSTRUCTION BABY!!!!!!!!!!!! 
                (_board.GetBoard[blankPosition[0], blankPosition[1]], _board.GetBoard[numPosition[0], numPosition[1]]) =
                    (_board.GetBoard[numPosition[0], numPosition[1]], _board.GetBoard[blankPosition[0], blankPosition[1]]);
            }

            _board.PrintBoard();

        }
    }

}





