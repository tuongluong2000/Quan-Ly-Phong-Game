using DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBIO
{
    public class Create
    {
        DB db = new DB();

        public void Add<T>(T obj)
        {
            db.Set(obj.GetType()).Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
