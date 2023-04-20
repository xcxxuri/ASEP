﻿using System;
namespace ApplicationCore.Contract.Repositories
{
	public interface IBaseRepository<T> where T : class
    {
        int Insert(T obj);
        int Update(T obj);
        int DeleteById(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}

