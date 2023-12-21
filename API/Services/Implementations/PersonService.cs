using API.Model;
using API.Services.Contracts;

namespace API.Services.Implementations
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            person.Id = Guid.NewGuid();
            return person;
        }

        public void Delete(Guid id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = [];
            for (var i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);

                people.Add(person);
            }

            return people;
        }

        public Person FindById(Guid id)
        {
            return new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Victor",
                LastName = "Campos",
                Address = "Somewhere over the rainbow",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return MockPerson(10);
        }

        private static Person MockPerson(int i)
        {
            return new Person
            {
                Id = Guid.NewGuid(),
                FirstName = $"Person {i} ",
                LastName = "Last Name",
                Address = $"Person {i} Address",
                Gender = "Female"
            };
        }
    }
}
