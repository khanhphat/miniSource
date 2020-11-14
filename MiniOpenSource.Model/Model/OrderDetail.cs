using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Model.Model
{
	[Table("OrderDetails")]
	public class OrderDetail
	{
		[Key]
		[Column(Order = 1)]
		public int OrderID { get; set; }

		[Key]
		[Column(Order = 2)]
		public int ProductID { get; set; }

		public int Quantity { get; set; }

		public decimal Price { set; get; }

		[ForeignKey("OrderID")]
		public virtual Order Order { set; get; }

		[ForeignKey("ProductID")]
		public virtual Product Product { set; get; }
	}
}
