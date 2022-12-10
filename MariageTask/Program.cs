using MariageTask;

const int pairsCount = 3;

var men = new List<Man>();
var women = new List<Woman>();
var generator = new HumanGenerator();
for (var i = 0; i < pairsCount; i++)
{
    var man = generator.GenerateMan();
    var woman = generator.GenerateWoman();
    men.Add(man);
    women.Add(woman);
}
Console.WriteLine("DataSet-----------------------------------");
Console.WriteLine("Men:");
foreach (var man in men)
{
    Console.WriteLine(man.Name);
    Console.WriteLine("    Data : ");
    Console.WriteLine("        Income : " + man.Data.Income);
    Console.WriteLine("        Health : " + man.Data.Health);
    Console.WriteLine("        Beauty : " + man.Data.Beauty);
    Console.WriteLine("    Preferences : ");
    Console.WriteLine("        Income : " + man.Preferences.Income);
    Console.WriteLine("        Health : " + man.Preferences.Health);
    Console.WriteLine("        Beauty : " + man.Preferences.Beauty);
}
Console.WriteLine("Women:");
foreach (var woman in women)
{
    Console.WriteLine(woman.Name);
    Console.WriteLine("    Data : ");
    Console.WriteLine("        Income : " + woman.Data.Income);
    Console.WriteLine("        Health : " + woman.Data.Health);
    Console.WriteLine("        Beauty : " + woman.Data.Beauty);
    Console.WriteLine("    Preferences : ");
    Console.WriteLine("        Income : " + woman.Preferences.Income);
    Console.WriteLine("        Health : " + woman.Preferences.Health);
    Console.WriteLine("        Beauty : " + woman.Preferences.Beauty);
}

var mariageSolver = new MariageSolver(men, women);
var pairs = mariageSolver.MakePairs();
Console.WriteLine("Pairs-----------------------------------");
foreach (var pair in pairs)
{
    Console.WriteLine(pair.Man.Name + " " + pair.Woman.Name);
}