namespace MariageTask;

public struct Pair
{
    public Man Man { get; }
    public Woman Woman { get; }

    public Pair(Man man, Woman woman)
    {
        Man = man;
        Woman = woman;
    }
}

public class MariageSolver
{
    private readonly List<Man> _men;
    private readonly List<Woman> _women;
    
    public MariageSolver(List<Man> men, List<Woman> women)
    {
        _men = men;
        _women = women;
    }

    public List<Pair> MakePairs()
    {
        while (!AreAllMenHavePair())
        {
            foreach (var man in _men.Where(man => man.CurrentAnswer is Answer.No))
            {
                man.FindTheBestWoman(_women);
            }
        }

        return (from woman in _women where woman.ChosenMan != null select new Pair(woman.ChosenMan, woman)).ToList();
    }

    private bool AreAllMenHavePair()
    {
        return _men.All(man => man.CurrentAnswer is not Answer.No);
    }
}