namespace DalTest;
using DalApi;
using DO;

public static class Initialization
{
    private static IEngineer? s_dalEngineer;
    private static ITask? s_dalTask;
    private static IDependency? s_dalDependency;

    private static void createEngineers()
    {
        RandomGenerator r = new RandomGenerator();
        string[] names = new string[10];
        for(int i = 0; i < names.Length; i++)
        {
            names[i] = r.GenerateName();
        }

        foreach (var _name in names)
        {
            int _id;
            do
                _id = s_rand.Next(MIN_ID, MAX_ID);
            while (s_dalEngineer!.Read(_id) != null);

            bool? _b = (_id % 2) == 0 ? true : false;
            Year _year =
            (Year)s_rand.Next((int)Year.FirstYear, (int)Year.ExtraYear + 1);

            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            DateTime _bdt = start.AddDays(s_rand.Next(range));

            Student newStu = new(_id, _name, null, _b, _year, _bdt);

            s_dalStudent!.Create(newStu);

        }

    }
}
