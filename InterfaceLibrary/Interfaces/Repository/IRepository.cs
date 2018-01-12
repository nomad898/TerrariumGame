﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces.Repository
{
    public interface IRepository<T, V> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(V id);
        void Create(T item);
        void Update(T item);
        void Delete(V id);
    }
}
