using RestWithAspNet.Data;
using RestWithAspNet.Model;
using RestWithAspNet.Repository;
using System;

namespace RestWithAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
