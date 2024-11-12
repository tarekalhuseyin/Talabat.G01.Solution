using Talabat.APIs.DTOs;

namespace Talabat.APIs.Helpers
{
	public class Pagination<T>
	{
		private int pageInsex;
		

		public Pagination(int pageInsex, int pageSize, IReadOnlyList<T> data ,int count)
		{
			pageInsex = pageInsex;
			PageSize = pageSize;
			Data=data;
			Count=count;
		}

		public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
