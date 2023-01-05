string folderPath = @"C:\data";
string HeroFile = "Heroes.txt";
string VillainFile = "Villains.txt";
string Weapons = "Weapons.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, HeroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, VillainFile));
string[] Weapon = File.ReadAllLines(Path.Combine(folderPath, Weapons));


//string[] heroes = { "Captain America", "Thor", "Spider-Man", "Iron Man", "Doctor Strange" };
//string[] villains = { "Loki", "Thanos", "Dormammu", "Aldrich Killian", "Malekith" };
//string[] weapon = { "Mjolnir", "Eye of Agamoto","Infinity Gauntlet", "Captain America's shield"};
//Ma panin text failis rohkem tegelasi ja relvi 


string hero = GetRandomValueFromArray(heroes);
string heroweapon = GetRandomValueFromArray(Weapon);
int heroHp = GetCharacterHP(hero);
int heroStrikeStrength = heroHp;
Console.WriteLine($"Today {hero} ({heroHp}) with {heroweapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(Weapon);
int villainHp = GetCharacterHP(villain);
int villainStrikeStrength = villainHp;
Console.WriteLine($"Today {villain} ({villainHp}) with {villainWeapon} tries to take over the world!");



while(heroHp > 0 && villainHp > 0)
{
    villainHp = villainHp - Hit(hero, heroStrikeStrength);
    heroHp = heroHp - Hit(villain, villainStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHp}");
Console.WriteLine($"Villain {villain} HP: {villainHp}");

if (heroHp > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHp > 0)
{
    Console.WriteLine($"Dark side wins...");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}


static int GetCharacterHP(string characterName)
{
     if (characterName.Length == 4)
    {
        return 20;
    }
     else if (characterName.Length == 6)
    {
        return 30;
    }
     else if (characterName.Length == 8)
    {
        return 30;
    }
     else
    {
        return 15;
    }    
}

static int Hit(string characterName, int characterHp)
{
    Random rnd = new Random();
    int Strike = rnd.Next(0, characterHp);

    if (Strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (Strike == characterHp - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {Strike}!");
    }

    return Strike;
}

