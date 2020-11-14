using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOpenSource.Model.Model
{
	[Table("VisitorStatics")]
	public class VisitorStatic
	{
		[Key]
		public Guid ID { set; get; }

		[Required]
		public DateTime VisitedDate { set; get; }

		[MaxLength(50)]
		public string IPAddress { set; get; }
	}
}
