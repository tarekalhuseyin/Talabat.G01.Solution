﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Cor.Specifications
{
	public interface ISpecifications<T>where T: BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get; set; }

		public List<Expression<Func<T, object>>> Includes { get; set; }

        //order by 
        public Expression<Func<T,object>> OrderBy { get; set; } 
		//order by desc
        public Expression<Func<T,object>> OrderByDescending { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }

    }
}
