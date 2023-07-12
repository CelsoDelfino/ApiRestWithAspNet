using RestWithAspNet.Model;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);

        Person FindById(long id);
        Person Update(Person person);   
        void Delete(long id);

        List<Person> FindAll();  
    }
}
