namespace MariageTask;

public struct Parameters
{
    public int Income { get; }
    public int Health { get; }
    public int Beauty { get; }

    public Parameters(int income, int health, int beauty)
    {
        if (income < 1)
            income = 1;
        
        if (income > 10)
            income = 10;
        
        if (health < 1)
            health = 1;
        
        if (health > 10)
            health = 10;
        
        if (beauty < 1)
            beauty = 1;
        
        if (beauty > 10)
            beauty = 10;
        
        
        Income = income;
        Health = health;
        Beauty = beauty;
    }
}

public enum Answer
{
    Maybe,
    No
}

public abstract class Human
{
    public Parameters Data { get; }
    public Parameters Preferences { get; }
    public string Name { get; }
    
    protected Human(Parameters data, Parameters preferences, string name)
    {
        Preferences = preferences;
        Data = data;
        Name = name;
    }
    
    public int CalculateScore(Parameters preferences)
    {
        return  Data.Health * preferences.Health +
                Data.Income * preferences.Income +
                Data.Health * preferences.Beauty;
    }
}

public class Man : Human
{
    public Answer CurrentAnswer { get; set; }
    
    public Man(Parameters data, Parameters preferences, string name) : base(data, preferences, name)
    {
        CurrentAnswer = Answer.No;
    }

    public void FindTheBestWoman(List<Woman> women)
    {
        var sortedWomen = SortWomenList(women);
        AskWomanUntilFindSome(sortedWomen);
    }
    
    private void AskWomanUntilFindSome(List<Woman> sortedWomen)
    {
        foreach (var woman in sortedWomen)
        {
            var answer = woman.AnswerToMan(this);
            if (answer is not Answer.Maybe) continue;
            CurrentAnswer = answer;
            return;
        }
    }

    private List<Woman> SortWomenList(List<Woman> women)
    {
        for (var i = 0; i < women.Count; i++)
        {
            for (var j = 0; j < women.Count - i - 1; j++)
            {
                if (women[j].CalculateScore(Preferences) < women[j + 1].CalculateScore(Preferences))
                {
                    (women[j], women[j + 1]) = (women[j + 1], women[j]);
                }
            }
        }

        return women;
    }
}

public class Woman : Human
{
    public Man? ChosenMan { get; private set; }

    public Woman(Parameters data, Parameters preferences, string name) : base(data, preferences, name)
    {
        ChosenMan = null;
    }

    public Answer AnswerToMan(Man man)
    {
        if (ChosenMan is null)
        {
            ChosenMan = man;
            man.CurrentAnswer = Answer.Maybe;
            return Answer.Maybe;
        }

        var newManScore = man.CalculateScore(Preferences);
        var oldManScore = ChosenMan.CalculateScore(Preferences);

        if (newManScore <= oldManScore)
        {
            man.CurrentAnswer = Answer.No;
            return Answer.No;
        }

        ChosenMan.CurrentAnswer = Answer.No;
        man.CurrentAnswer = Answer.Maybe;
        ChosenMan = man;
        return Answer.Maybe;
    }
}