using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName= "Celso",
                LastName = "Delfino",
                Adress = "Rio de Janeiro",
                Gender = "Masculino"
            };
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            for(int i =0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person name" + i,
                LastName = "Person Last name" + i,
                Adress = "Some Adress" + i ,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
