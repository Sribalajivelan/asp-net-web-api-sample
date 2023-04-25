using AspDotWebAPISample.DbContext;
using AspDotWebAPISample.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AspDotWebAPISample.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentDbContext _studentDbContext;

    public StudentController(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    [HttpGet(Name = "Get All Students")]
    [Produces("application/json")]
    public List<Student> GetAllStudent()
    {
        return _studentDbContext.FindAll();
    }
    
    [HttpPost(Name = "Create Students")]
    [Produces("application/json")]
    public List<Student> CreateStudent([FromBody] Student student)
    {
        return _studentDbContext.Create(student);
    }
    
    [HttpPut( "{id:int}", Name = "Update Students")]
    [Produces("application/json")]
    public List<Student> UpdateStudent([FromRoute] int id, [FromBody] Student student)   
    {
        return _studentDbContext.Update(id, student);
    }
    
    [HttpDelete( "{id:int}", Name = "Delete Students")]
    [Produces("application/json")]
    public List<Student> DeleteStudent([FromRoute] int id)   
    {
        return _studentDbContext.Delete(id);
    }
}