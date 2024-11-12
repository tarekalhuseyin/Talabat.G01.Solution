using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;
using Talabat.Cor.Repositories;

namespace Talabat.Cor
{
	public interface IUnitOfWork:IAsyncDisposable
	{
		IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
		Task<int>CompleteAsync();

	}
}
