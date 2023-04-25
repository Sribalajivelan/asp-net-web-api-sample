using AspDotWebAPISample.DTO;

namespace AspDotWebAPISample.Services;

public interface IStudentServices
{
    public List<Student> findAll();
}
public class StudentServices : IStudentServices
{
    public List<Student> findAll()
    {
        throw new NotImplementedException();
    }
}