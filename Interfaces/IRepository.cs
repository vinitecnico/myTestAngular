using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mvcUploadFile.Models;

namespace myTestAngular.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
         Task<List<T>> GetAll ();
        Task<T> GetById (string id);
        Task Add (T item);
        Task<bool> Remove (string id);
        Task<bool> Update (string id, string body);
        Task<bool> RemoveAll ();
    }
}