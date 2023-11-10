namespace DalTest;
using DalApi;
using DO;

public static class Initialization
{
    private static IEngineer? s_dalEngineer;
    private static ITask? s_dalTask;
    private static IDependency? s_dalDependency;

    public static void createEngineers()
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
            if(s_dalEngineer != null)
            {
                do
                    _id = r.GenerateID();
                while (s_dalEngineer!.Read(_id) != null);
            }
            else
                _id = r.GenerateID();
            string _email = _name.Split(" ")[0]+"@gmail.com";
            EngineerExperience _level = (EngineerExperience)r.GenerateLevel();
            Engineer newEngineer = new(_id, _name, _email, _level);
            s_dalEngineer!.Create(newEngineer);
        }
    }
    
    public static void DO(IEngineer? dalEngineer)
    {
        s_dalEngineer = dalEngineer ?? throw new NullReferenceException("DAL can not be null!");
        createEngineers();
    }
}
