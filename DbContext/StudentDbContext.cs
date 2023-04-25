using System.Data.Entity;
using AspDotWebAPISample.DTO;

namespace AspDotWebAPISample.DbContext;

public class StudentDbContext : System.Data.Entity.DbContext
{
    public DbSet<Student> Students { get; set; }
    
    public StudentDbContext() : base("Server=localhost;Database=asp_demo;User Id=SA;Password=Balaji@2023;")
    {
    }

    public List<Student> FindAll()
    {
        using (var context = new StudentDbContext())
        {
            return context.Students.ToList();
        }
    }

    public List<Student> Create(Student student)
    {
        using (var context = new StudentDbContext())
        {
            context.Students.Add(student);
            context.SaveChanges();
            return context.Students.ToList();
        }
    }
    
    public List<Student> Update(int id, Student student)
    {
        using (var context = new StudentDbContext())
        {
            var exist = context.Students.FirstOrDefault(s => s.Id == id);
            if (exist != null)
            {
                exist.Name = student.Name;
                exist.Email = student.Email;
                context.SaveChanges();
                return context.Students.ToList();   
            }

            throw new BadHttpRequestException("Student Not Found", 417);
        }
    }
    
    public List<Student> Delete(int id)
    {
        using (var context = new StudentDbContext())
        {
            var exist = context.Students.FirstOrDefault(s => s.Id == id);
            if (exist != null)
            {
                context.Students.Remove(exist);
                context.SaveChanges();
                return context.Students.ToList();
            }
            throw new BadHttpRequestException("Student Not Found", 417);
        }
    }
}