using RestWithAspNet.Data;
using RestWithAspNet.Model;

namespace RestWithAspNet.Repository.Implementations
{
    //REPOSITORY - RESPONSÁVEL APENAS PELA PERSISTÊNCIA DOS DADOS

    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        private volatile int count;

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(_ => _.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges(); 
            }
            catch(Exception ex)
            {
                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(_ => _.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context
                .Persons
                .SingleOrDefault(_ => _.Id == person.Id);

            if(result != null) 
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(_=>_.Id == id);
        }
    }
}
