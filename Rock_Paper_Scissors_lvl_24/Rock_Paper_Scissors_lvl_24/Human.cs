
// This class is only for creating a person that has a Name for the game (Rock Paper Scissors)
public class Human
{
    private string _name = "n/a";
    private Game _choice;

    public Human(string name)
    {
        _name = name;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    //pointer sets the _choice to be one of the Game enum values
    public Game Choice
    {
        get => _choice;
        set => _choice = value;
    }
}

public enum Game { Rock, Paper, Scissors}