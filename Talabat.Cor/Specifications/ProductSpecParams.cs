using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Cor.Specifications
{
	public class ProductSpecParams
	{
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
		public int PageInsex { get; set; } = 1;
		private int pageSize=5;

		public int PageSize
		{
			get { return pageSize=5; }
			set { pageSize= value>10?10 : value; }
		}

		 private string? search;

		public string? Search
		{
			get { return search; }
			set { search = value.ToLower(); }
		}
		 


		 
    }
}
