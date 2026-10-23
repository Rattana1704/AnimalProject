

List<Djur> djurLista = new List<Djur>
{
    new Hund("Bosse", 5),
    new Katt("Misse", 3),
    new Fagel("Koko", 2)
};

bool running = true;

while (running)
{
    Console.WriteLine("\n===== DJURREGISTER =====");
    Console.WriteLine("1. Visa alla djur");
    Console.WriteLine("2. Lägg till ett djur");
    Console.WriteLine("3. Visa alla djurs ljud");
    Console.WriteLine("4. Sök efter ett djur");
    Console.WriteLine("5. Visa antal djur");
    Console.WriteLine("6. Avsluta");
    Console.Write("Välj: ");

    string? input = Console.ReadLine();

    if (int.TryParse(input, out int choice))
    {
        switch (choice)
        {
            case 1:
                VisaAllaDjur(djurLista);
                break;
            case 2:
                LaggTillDjur(djurLista);
                break;
            case 3:
                VisaLjud(djurLista);
                break;
            case 4:
                SokDjur(djurLista);
                break;
            case 5:
                Console.WriteLine($"Antal djur: {djurLista.Count}");
                break;
            case 6:
                running = false;
                Console.WriteLine("Programmet avslutas.");
                break;
            default:
                Console.WriteLine("Välj ett nummer mellan 1 och 6.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Skriv ett giltigt heltal.");
    }
}

static void VisaAllaDjur(List<Djur> lista)
{
    Console.WriteLine("\n--- Alla djur ---");

    foreach (Djur djur in lista)
    {
        djur.VisaInfo();
    }
}

static void LaggTillDjur(List<Djur> lista)
{
    Console.WriteLine("1. Hund  2. Katt  3. Fågel");
    Console.Write("Välj djurtyp: ");
    string? typeInput = Console.ReadLine();

    if (!int.TryParse(typeInput, out int type) ||
        type < 1 || type > 3)
    {
        Console.WriteLine("Ogiltig djurtyp.");
        return;
    }

    Console.Write("Ange namn: ");
    string? name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Namnet får inte vara tomt.");
        return;
    }

    Console.Write("Ange ålder: ");
    string? ageInput = Console.ReadLine();

    if (!int.TryParse(ageInput, out int age) || age < 0)
    {
        Console.WriteLine("Ogiltig ålder.");
        return;
    }

    if (type == 1)
        lista.Add(new Hund(name, age));
    else if (type == 2)
        lista.Add(new Katt(name, age));
    else
        lista.Add(new Fagel(name, age));

    Console.WriteLine($"{name} har lagts till!");
}

static void VisaLjud(List<Djur> lista)
{
    Console.WriteLine("\n--- Djuren gör ljud ---");

    foreach (Djur djur in lista)
    {
        Console.Write($"{djur.Namn}: ");
        djur.Ljud();
    }
}

static void SokDjur(List<Djur> lista)
{
    Console.Write("Skriv namnet du söker efter: ");
    string? searchName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(searchName))
    {
        Console.WriteLine("Du måste skriva ett namn.");
        return;
    }

    bool found = false;

    foreach (Djur djur in lista)
    {
        if (djur.Namn.Equals(
            searchName.Trim(),
            StringComparison.OrdinalIgnoreCase))
        {
            djur.VisaInfo();
            found = true;
        }
    }

    if (!found)
        Console.WriteLine("Djuret hittades inte.");
}

class Djur
{
    public string Namn { get; set; }
    public int Alder { get; set; }

    public Djur(string namn, int alder)
    {
        Namn = namn;
        Alder = alder;
    }

    public virtual void Ljud()
    {
        Console.WriteLine("Djuret gör ett ljud.");
    }

    public virtual void VisaInfo()
    {
        Console.WriteLine($"Namn: {Namn}, Ålder: {Alder}");
    }
}

class Hund : Djur
{
    public Hund(string namn, int alder) : base(namn, alder) { }

    public override void Ljud()
    {
        Console.WriteLine("Voff!");
    }
}

class Katt : Djur
{
    public Katt(string namn, int alder) : base(namn, alder) { }

    public override void Ljud()
    {
        Console.WriteLine("Mjau!");
    }
}

class Fagel : Djur
{
    public Fagel(string namn, int alder) : base(namn, alder) { }

    public override void Ljud()
    {
        Console.WriteLine("Pip pip!");
    }
}
