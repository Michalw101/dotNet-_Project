namespace BlApi;

public interface IEngineer
{
    public int Create(BO.Engineer item);
    public BO.Engineer? Read(int id);
    IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null);
    public void Update(BO.Engineer item);
    public void Delete(int id);
}

