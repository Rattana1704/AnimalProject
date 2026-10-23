using System.Reflection.Metadata.Ecma335;

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

class Cat : Animal 

class Bird : Animal 

class Program 

