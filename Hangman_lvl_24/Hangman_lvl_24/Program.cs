/*
    Hayden Hartmann
    2/7/2025
    Hangman : The catacombs of the class
*/

//got bored and almost finished :(   lol
//no comments either so this project is cooked...
//or is it -_-

public class MyMain
{
    public static void Main(string[] args)
    {
        Player player1 = new Player("Hayden");
        HangmanGame game = new HangmanGame(player1);
        game.PlayGame();

        Console.ReadKey();
    }
}

public class HangmanGame
{
    private Player _player;
    public HangmanGame(Player player)
    {
        _player = player;
    }

    public void PlayGame()
    {
        Console.WriteLine($"Hello {_player.Name}\n");

        RandomWords randomWord = new RandomWords();
        int lengthOfWord = randomWord.RandomWord.Length;
        string[] wordArray = new string[lengthOfWord];
        int numOfGuesses = 5;
        string incorrect = "";

        for (int i = 0; i <= lengthOfWord - 1; i++)
        {
            wordArray[i] = "-";
        }

        while (true)
        {
            string word = "";

            foreach (string letter in wordArray)
            {
                word += letter;
            }
            bool valid = false;
            Console.Write($"Word: {word} | Remaining: {numOfGuesses} | Incorrect: {incorrect} | Guess: ");
            char guess = Convert.ToChar(Console.ReadLine());

            for (int letterIndex = 0; letterIndex <= wordArray.Length - 1; letterIndex++)
            {
                if (randomWord.RandomWord[letterIndex] == guess)
                {
                    wordArray[letterIndex] = Convert.ToString(guess);
                    valid = true;
                }
            }
            if (!valid)
            {
                numOfGuesses--;
                incorrect += guess;
            }
            foreach (string letter in wordArray)
            {
                word += letter;
            }

        }


    }

}

public class RandomWords
{
    private string _randomWord;
    private List<string> _words = new List<string>() { "cow", "dog", "cat", "wolf", "rat"};
    Random _random = new Random();

    public RandomWords()
    {
        _randomWord = _words[_random.Next(_words.Count)];
    }

    public string RandomWord
    {
        get => _randomWord;
    }

    public List<string> Words
    {
        get => _words;
    }
    public void NewWord(string word)
    {
        _words.Add(word);
    }

}

public class Player
{
    private string _name = "n/a";

    public Player(string name)
    {
        _name = name;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public void Guess(char letter)
    {
        //some code 
    }

}


