using Microsoft.EntityFrameworkCore;
using Assignment.Entities;
using Assignment.Entities.Models;
using AssignmentApi.Services.Interface;

namespace AssignmentApi.Services.Class
{
    public class PersonService : IPersonService
    {
        private readonly AssignmentContext context;
        public PersonService(AssignmentContext assignmentContext)
        {
            context = assignmentContext;
        }
        public List<Person> GetPersons()
        {
            return context.People.ToList();
        }

        public Person? GetPersonById(int id)
        {
            return context.People.SingleOrDefault(person => person.Id == id);   
        }
        public void AddPerson(Person person)
        {
            context.Add(person);
            context.SaveChanges();
        }
        public void UpdatePerson(Person person)
        {
            context.Update(person);
            context.SaveChanges();
        }
        public void DeletePerson(int Id)
        {
            var person = new Person { Id = Id };
            context.Entry(person).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
