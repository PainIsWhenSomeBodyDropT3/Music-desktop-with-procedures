using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.dao
{
    interface Dao<T>
    {
        void create(T t);
        T readById(int id);
        T update(int id, T t);
        void delete(T t);
    }
}
