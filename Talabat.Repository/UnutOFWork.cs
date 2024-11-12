﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor;
using Talabat.Cor.Entites;
using Talabat.Cor.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
	public class UnutOFWork : IUnitOfWork
	{
		private readonly StoreContext _dbContext;
		private Hashtable _repositories;
        public UnutOFWork(StoreContext dbContext)
        {
			_repositories = new Hashtable();
			_dbContext = dbContext;
		}
        public async Task<int> CompleteAsync()
		{
		return	await _dbContext.SaveChangesAsync();
		}

		public ValueTask DisposeAsync()
		{
			return _dbContext.DisposeAsync();
		}

		public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
		{
			var type = typeof(TEntity).Name;
			if (!_repositories.ContainsKey(type)) 
			{
				var Repository=new GenericRepository<TEntity>(_dbContext);
				_repositories.Add(type, Repository);
			}
				return _repositories[type] as IGenericRepository<TEntity>;

		}
	}
}
