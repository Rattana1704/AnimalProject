
class Animal
{ 
    public string Name { get;}
    public int Age {get ;}
    public bool IsHungry { get ; private set;}
    public Animal (string name , int age)
    {
        Name = name ;
        Age = age ;
        IsHungry = true ;
    }

    public virtual void Sound ()
    {
        Console.WriteLine ($"{Name} makes an animal sound.");
    }

    public void ShowInformation ()
    {
        Console.WriteLine ($"Name : {Name}, Type : {GetType}().Name, Age : {Age}");
    }

    public void Feed ()
    {
        if (IsHungry)
        {
            Console.WriteLine($"{Name} eats some food");
            IsHungry = false ;
        }
        else
        {
            Console.WriteLine($"{Name} is not hungry.");
        }
    }
}

class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {
    }
    public override void Sound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

class Cat : Animal 

class Bird : Animal 

class Program
{
    static void Main ()
    {
        List <Animal> animals = new List<Animal>
         {
            new Dog("Buddy", 4),
            new Cat("Luna", 2),
            new Bird("Kiwi", 1),
            new Dog("Max", 6)
        };
        bool running = true ;
        while (running)
        {
            Console.WriteLine("\n--- Animal Menu ---");
            Console.WriteLine("1. Show all animals");
            Console.WriteLine("2. Hear all animal sounds");
            Console.WriteLine("3. Feed all animals");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? input = Console.ReadLine();

            if (!int.TryParse (input, out int choice))
            {
                Console.WriteLine("Please enter a number from 0 to 3.");
                continue;
            }
            switch ( choice)
            {
                case 1:
                foreach (Animal animal in animals)
                animal.ShowInformation();
                break;
                case 2:
                case 3:
                case 0:
                running = false;
                Console.WriteLine ("goodbye!");
                break;
                default : 
                Console.WriteLine ("please choose a number from 0 to 3.");
                break;
            }


        }
    }
}
