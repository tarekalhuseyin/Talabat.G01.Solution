using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;
using Talabat.Cor.Specifications;

namespace Talabat.Cor.Repositories
{
	public interface IGenericRepository<T>where T : BaseEntity
	{
		#region without specification
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		#endregion

		Task <IReadOnlyList<T>> GetallWithSpecAsync(ISpecifications<T> Spec);
		Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec);
		Task<int> GetCountWithSpecAsync(ISpecifications<T> Spec);
		Task AddAsync(T item);
		void Update (T item);
		void Delete (T item);
		
	}
}
