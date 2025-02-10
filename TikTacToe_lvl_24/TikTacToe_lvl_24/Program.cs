/*
    Hayden Hartmann
    2/7/2025
    Tic Tac Toe Game: THE CATACOMBS OF THE CLASS
*/

//game needs comments... :(

public class MyMain
{
    public static void Main(string[] args)
    {
        TicTacToe game1 = new TicTacToe();

        Console.ReadKey();
    }
}

public class TicTacToe
{
    private string _next = "X";
    public TicTacToe()
    {
        BoardCreator board = new BoardCreator();
        BoardChecker checkBoard = new BoardChecker(board);
        Display display = new Display(board, _next);

        Players player1 = new Players("Hayden");
        Players player2 = new Players("Dylan");

        while (true)
        {
            display.DisplayBoard();

            Console.Write("What square do you want to play in (0-8): ");
            int square = Convert.ToInt32(Console.ReadLine());

            if (board.GetBoard[square] != " ")
            {
                Console.WriteLine("INVALID CHOICE");
                continue;
            }
            else
            {
                board.GetBoard[square] = _next;

                if (checkBoard.CheckBoard() == true)
                {
                    display.DisplayBoard();
                    bool catsGame = true;
                    foreach (string tile in board.GetBoard)
                    {
                        if (tile == " ")
                        {
                            catsGame = false;
                        }
                    }

                    if (catsGame)
                    {
                        Console.WriteLine("\nCats Game");
                    }
                    else
                    {
                        Console.WriteLine($"\n{_next} wins the game");
                    }

                    break;
                }

                if (_next == "X")
                {
                    _next = "O";
                    display.Next = "O";
                }
                else
                {
                    _next = "X";
                    display.Next = "X";
                }
            }
        }
    }

}

public class Players
{
    private string _name = "n/a";
    public Players(string name)
    {
        _name = name;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
}

public class BoardCreator
{
    private string[] _board = {
        " ", " ", " ", 
        " ", " ", " ",
        " ", " ", " "
    };

    public BoardCreator() { }

    public string[] GetBoard
    {
        get => _board;
    }

}

public class Display
{
    private BoardCreator _board;
    private string _next = "n/a";
    public Display(BoardCreator board, string next)
    {
        _board = board;
        _next = next;
    }

    public string Next
    {
        set => _next = value;
    }

    public void DisplayBoard()
    {
        Console.WriteLine($"It is {_next}'s turn.");
        Console.WriteLine($" {_board.GetBoard[0]} | {_board.GetBoard[1]} | {_board.GetBoard[2]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {_board.GetBoard[3]} | {_board.GetBoard[4]} | {_board.GetBoard[5]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {_board.GetBoard[6]} | {_board.GetBoard[7]} | {_board.GetBoard[8]} ");
    }

}

public class BoardChecker
{
    private BoardCreator _board;
    public BoardChecker(BoardCreator board)
    {
        _board = board;
    }

    public bool CheckBoard()
    {
        //probobly a better way to check endgame... hard checks each tile
        if ((_board.GetBoard[0] != " " && _board.GetBoard[0] == _board.GetBoard[1] && _board.GetBoard[0] == _board.GetBoard[2]) || //top
            (_board.GetBoard[3] != " " && _board.GetBoard[3] == _board.GetBoard[4] && _board.GetBoard[3] == _board.GetBoard[5]) || //middle
            (_board.GetBoard[6] != " " && _board.GetBoard[6] == _board.GetBoard[7] && _board.GetBoard[6] == _board.GetBoard[8]) || //bottem
            (_board.GetBoard[0] != " " && _board.GetBoard[0] == _board.GetBoard[3] && _board.GetBoard[0] == _board.GetBoard[6]) || //verticle 1
            (_board.GetBoard[1] != " " && _board.GetBoard[1] == _board.GetBoard[4] && _board.GetBoard[1] == _board.GetBoard[7]) || //verticle 2
            (_board.GetBoard[2] != " " && _board.GetBoard[2] == _board.GetBoard[5] && _board.GetBoard[2] == _board.GetBoard[8]) || //verticle 3
            (_board.GetBoard[0] != " " && _board.GetBoard[0] == _board.GetBoard[4] && _board.GetBoard[0] == _board.GetBoard[8]) || //horizantal right
            (_board.GetBoard[2] != " " && _board.GetBoard[2] == _board.GetBoard[4] && _board.GetBoard[2] == _board.GetBoard[6]))   //horizantal left
        {
            return true;
        }
        else
        {
            foreach (string tile in _board.GetBoard)
            {
                if (tile == " ")
                {
                    return false;
                }
            }
            Console.WriteLine("Cats Game");
            return true;
        }
    }

}







