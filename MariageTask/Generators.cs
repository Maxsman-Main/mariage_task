namespace MariageTask;

public class HumanGenerator
{
    public Man GenerateMan()
    {
        var data = CreateRandomParameters(0, 10);
        var preferences = CreateRandomParameters(0, 3);
        var name = CreateRandomName(5);
        return new Man(data, preferences, name);
    }
    
    public Woman GenerateWoman()
    {
        var data = CreateRandomParameters(1, 11);
        var preferences = CreateRandomParameters(1, 4);
        var name = CreateRandomName(5);
        return new Woman(data, preferences, name);
    }

    private Parameters CreateRandomParameters(int minValue, int maxValue)
    {
        var income = GetRandomValue(minValue, maxValue);
        var health = GetRandomValue(minValue, maxValue);
        var beauty = GetRandomValue(minValue, maxValue);
        return new Parameters(income, health, beauty);
    }

    private static int GetRandomValue(int leftBound, int rightBound)
    {
        var random = new Random();
        return random.Next(leftBound, rightBound);
    }

    private static string CreateRandomName(int length)
    {
        var name = "";
        for (var i = 0; i < length; i++)
        {
            var nextSymbol = GetRandomValue(0, 9).ToString();
            name += nextSymbol;
        }

        return name;
    }
}