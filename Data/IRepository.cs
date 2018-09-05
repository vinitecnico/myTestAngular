using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using myTestAngular.Models;

namespace myTestAngular.Interfaces {
    public interface INoteRepository<T>
        where T : class {
            Task<IEnumerable<T>> GetAll ();
            Task<T> GetById (string id);
            Task Add (T item);
            Task<bool> Remove (string id);
            Task<bool> Update (string id, T item);
        }
}