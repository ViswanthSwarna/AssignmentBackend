using Assignment.Entities.Models;

namespace AssignmentApi.Services.Interface
{
    public interface IPersonService
    {
        List<Person> GetPersons();
        Person? GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}
