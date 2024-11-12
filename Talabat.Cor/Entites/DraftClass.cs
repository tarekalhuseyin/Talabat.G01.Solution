using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Cor.Entites
{
	internal class Employee:BaseEntity
	{
		public string Name { get; set; }
		public decimal Salary { get; set; }

		public string Age { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}

	public class Department : BaseEntity 
	{
		public string Name { get; set; }
		//public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
		
	}
}
