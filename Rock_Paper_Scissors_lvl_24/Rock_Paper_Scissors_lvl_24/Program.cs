/*
    Hayden Hartmann
    2/5/2025
    Rock Paper Scissors Game
*/


public class MainClass
{
    public static void Main(string[] args)
    {
        //human objects
        Human human1 = new Human("Hayden");
        Human human2 = new Human("Dylan");
        
        //game loop
        while (true)
        {
            //human1 gives response, put through checker method and then assigner. If checker returns false, game restarts
            Console.Write($"{human1.Name} pick rock, paper, scissors: ");
            string? choice1 = Console.ReadLine();
            if (Checker(choice1))
            {
                Assigner(choice1, human1);
            }
            else
            {
                continue;
            }

            //code above copied, probobly can make a method to reduce code...
            Console.Write($"{human2.Name} pick rock, paper, scissors: ");
            string? choice2 = Console.ReadLine();
            if (Checker(choice2))
            {
                Assigner(choice2, human2);
            }
            else
            {
                continue;
            }

            //Checkwin method just prints who wins 
            CheckWin(human1, human2);
            Console.WriteLine("\n---------------------------------------");
        }

        Console.ReadKey();
    }

    //method checks if user input is either rock, paper, or scissors 
    public static bool Checker(string choice)
    {
        if (choice != "rock" && choice != "paper" && choice != "scissors")
        {
            Console.WriteLine("You must pick rock, paper, or scissors!\n");
            Console.WriteLine("---------------------------------------\n");
            return false;
        }
        else
        {
            return true;
        }
    }
    
    //method assigns human.Choice to a Grade enum
    public static void Assigner(string choice, Human human)
    {
        switch (choice)
        {
            case "rock":
                human.Choice = Game.Rock;
                break;
            case "paper":
                human.Choice = Game.Paper;
                break;
            case "scissors":
                human.Choice = Game.Scissors;
                break;
        }
    }

    //method checks win condition of Rock Paper Scissors
    public static void CheckWin(Human human1, Human human2)
    {
        //If both are equal. Simplifies code. Otherwise simple if else block to test human.Choices against each other
        if (human1.Choice == human2.Choice)
        {
            Console.WriteLine("Its a tie!");
        }
        else
        {
            if (human1.Choice == Game.Paper)
            {
                if (human2.Choice == Game.Rock)
                {
                    Console.WriteLine($"{human1.Name} wins!");
                }
                else
                {
                    Console.WriteLine($"{human2.Name} wins!");
                }
            }
            else if (human1.Choice == Game.Rock)
            {
                if (human2.Choice == Game.Paper)
                {
                    Console.WriteLine($"{human2.Name} wins!");
                }
                else
                {
                    Console.WriteLine($"{human1.Name} wins!");
                }
            }
            else if (human1.Choice == Game.Scissors)
            {
                if (human2.Choice == Game.Rock)
                {
                    Console.WriteLine($"{human2.Name} wins!");
                }
                else
                {
                    Console.WriteLine($"{human1.Name} wins!");
                }
            }
        }
    }
}






