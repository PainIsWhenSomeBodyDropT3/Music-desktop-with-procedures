using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.service
{
    interface Service<T>
    {
        void create(T t);
        T readById(int id);
        T update(int id, T t);
        void delete(T t);
    }
}
