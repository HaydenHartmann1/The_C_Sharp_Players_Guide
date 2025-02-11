/*
    Hayden Hartmann
    2/11/2025
    Packing Inventory
*/

public class MyMain
{
    public static void Main(string[] args)
    {
        // notes
        // this :(...) casts the arguments to the object constructor that it was created in to fill out other constructor
        // base :(...) same thing but instead of sending it to constructor in object, sends it to constructor in parent class constructor

        // creates new pack object
        Pack pack = new Pack(10.5, 6.5, 15);
        
        // loops infinitly to let user input objects into pack
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine($"(1) Arrow: Weight = 0.1  Volume = 0.05");
            Console.WriteLine($"(2) Bow:   Weight = 1.0  Volume = 4.0");
            Console.WriteLine($"(3) Rope:  Weight = 1.0  Volume = 1.5");
            Console.WriteLine($"(4) Water: Weight = 2.0  Volume = 3.0");
            Console.WriteLine($"(5) Food:  Weight = 1.0  Volume = 0.5");
            Console.WriteLine($"(6) Sword: Weight = 5.0  Volume = 3.0");
            Console.WriteLine();
            Console.WriteLine($"Pack Limit: Weight = {pack.GetWeightLimit}  Volume = {pack.GetVolumeLimit}");
            Console.WriteLine($"Pack contains: {pack}");
            Console.WriteLine();

            // user input
            Console.Write("Pick an item to add to your bag: ");
            int user = Convert.ToInt32(Console.ReadLine());
            
            // input run through switch case, if match -> object created and added
            switch (user)
            {
                case 1:
                    if (pack.AddItem(new Arrow()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                case 2:
                    if (pack.AddItem(new Bow()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                case 3:
                    if (pack.AddItem(new Rope()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                case 4:
                    if (pack.AddItem(new Water()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                case 5:
                    if (pack.AddItem(new Food()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                case 6:
                    if (pack.AddItem(new Sword()))
                    {
                        Console.WriteLine("Item was added");
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.WriteLine();
        }
    }
}

// pack class that hold all other objects in array, has a set weight, item count, and volume limit
public class Pack
{
    private double _weightLimit = -1.0;
    private double _volumeLimit = -1.0;
    private InventoryItem[] items;

    public Pack(double weightLimit, double volumeLimit, int totalItems)
    {
        _weightLimit = weightLimit;
        _volumeLimit = volumeLimit;

        // this sets the array to a definitive count
        items = new InventoryItem[totalItems];
    }
    public double GetWeightLimit
    {
        get => _weightLimit;
    }
    public double GetVolumeLimit
    {
        get => _volumeLimit;
    }

    // loops through items[] and if the value is null and params pass then item added and instance variables updated
    public bool AddItem(InventoryItem item)
    {
        for (int i = 0; i <= items.Length - 1; i++)
        {
            if (items[i] == null)
            {
                if (_weightLimit - item.GetWeight > 0 && _volumeLimit - item.GetVolume > 0)
                {
                    items[i] = item;
                    _weightLimit -= item.GetWeight;
                    _volumeLimit -= item.GetVolume;
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString()
    {
        string message = "";
        foreach(InventoryItem item in items)
        {
            if (item != null)
            {
                message += $"{item} ";
            }
        }
        return message;
    }
}

// Parent class of all Items in this program
public class InventoryItem
{
    private double _weight = -1.0;
    private double _volume = -1.0;

    // All items must have weight and volume
    public InventoryItem(double weight, double volume)
    {
        _weight = weight;
        _volume = volume;
    }

    public double GetWeight
    {
        get => _weight;
    }
    public double GetVolume
    {
        get => _volume;
    }
}

// all child classes below, only have weight and volume predetermined and sent to the base constructor in the parent class
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
    public override string ToString() => "Water";
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5) { }
    public override string ToString() => "Food";
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
    public override string ToString() => "Sword";
}




