/*
    Hayden Hartmann
    2/11/2025
    The old Robot
*/

public class MyMain
{
    public static void Main(string[] args)
    {
        // create robot object 
        Robot robot = new Robot();

        Console.WriteLine("(1) = on, (2) = off, (3) = north, (4) = east, (5) = south, (6) = west");

        // cycles through 3 times and adds the command object to array declared in Robot object
        Console.WriteLine("Commands: ");
        for (int i = 0; i <= 2; i++)
        {
            // user input read and converted to int
            int userInput = Convert.ToInt32(Console.ReadLine());

            // command added once per loop
            if (userInput == 1) { robot.Commands[i] = new OnCommand(); }
            else if (userInput == 2) { robot.Commands[i] = new OffCommand(); }
            else if (userInput == 3) { robot.Commands[i] = new NorthCommand(); }
            else if (userInput == 4) { robot.Commands[i] = new EastCommand(); }
            else if (userInput == 5) { robot.Commands[i] = new SouthCommand(); }
            else if (userInput == 6) { robot.Commands[i] = new WestCommand(); }
        }
        // runs robot's Run() method
        robot.Run();

        Console.ReadKey();
    }
}

// class that is altered by Command classes
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    // creates an array of RobotCommand type objects for its child classes to go into
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    // method cycles through commands and uses their Run() methods to change the Robot instance variables
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            // this : refers to the current instance
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

// parent class to all commands, abstract with abstract method so that all child classes MUST have a Run() method
public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

// child classes all below. All override parent Run() method and they alter Robot instance variables
public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y += 1;
        }
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}






