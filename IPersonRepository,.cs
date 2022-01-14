using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo04
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        Person GetById(int id);
        void Add(Person personToAdd);
        void Update(Person personToUpdate);
        void Remove(int id);

        int CountPersonOverYrs(int yearsFromCount);
    }
}
