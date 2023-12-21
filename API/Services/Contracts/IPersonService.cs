using API.Model;

namespace API.Services.Contracts;

public interface IPersonService
{
    Person Create(Person person);
    Person FindById(Guid id);
    List<Person> FindAll();
    Person Update(Person person);
    void Delete(Guid id);
}
