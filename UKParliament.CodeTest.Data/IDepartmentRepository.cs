namespace UKParliament.CodeTest.Data;

public interface IDepartmentRepository<T> where T : class
{
    IEnumerable<T> GetAll();
}
