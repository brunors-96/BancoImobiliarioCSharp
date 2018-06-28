﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UI.Web.Models;

namespace UI.Web.Services
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(object id);
        Task<T> GetByAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> InsertAsync(T insert);
        Task<bool> UpdateAsync(object id, T updated);
        Task<bool> RemoveAsync(object id);

        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        bool Insert(T insert);
        T Get(object id);
        bool Update(object id, T updated);
        bool Remove(object id);

        List<T> Filter(Func<T, bool> where);

    }
}
