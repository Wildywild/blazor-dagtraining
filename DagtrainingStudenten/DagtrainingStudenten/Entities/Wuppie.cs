using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagtrainingStudenten.Entities
{
    public class Wuppie
    {
		public int Id { get; set; }

		[Required]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Alleen letters graag")]
		public string Name { get; set; }

		[Required]
		public string Color { get; set; }

		[Required]
		public string PhotoUrl { get; set; }
	}
}
