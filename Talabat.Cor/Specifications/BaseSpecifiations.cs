using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Cor.Specifications
{
	public class BaseSpecifiations<T> : ISpecifications<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get ; set ; }
		public List<Expression<Func<T, object>>> Includes { get; set; }   = new List<Expression<Func<T, object>>>();
		public Expression<Func<T, object>> OrderBy { get ; set  ; }
		public Expression<Func<T, object>> OrderByDescending { get  ; set ; }
		public int Take { get  ; set ; }
		public int Skip { get  ; set  ; }
		public bool IsPaginationEnabled { get ; set  ; }

		public BaseSpecifiations()
        {
            
          //  Includes=new List<Expression<Func<T, object>>> ();
        }
        public BaseSpecifiations(Expression<Func<T,bool>> criteriaExpration)
        {
            Criteria = criteriaExpration;
          //  Includes = new List<Expression<Func<T, object>>>();
        }
        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
    public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending= orderByDescExpression;
        }
        public void ApplyPagination(int skip,int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
