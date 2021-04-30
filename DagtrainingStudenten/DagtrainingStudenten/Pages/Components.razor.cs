using DagtrainingStudenten.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagtrainingStudenten.Pages
{
    public partial class Components
    {
		List<Wuppie> Wuppies = new List<Wuppie>
		{
			new Wuppie
			{
				Id = 4,
				Color = "Orange",
				Name = "Wil-Alex",
				PhotoUrl = "https://www.johan-laurens.nl/_oranjegoed/de09775.jpg"
			},
			new Wuppie
			{
				Id = 8,
				Color = "Blue",
				Name = "Maxima",
				PhotoUrl = "https://www.dekattensite.nl/wp-content/uploads/2016/11/rl-wuppie.jpg?quality=100.3021031019220"
			},
			new Wuppie
			{
				Id = 15,
				Color = "Green",
				Name = "Alexia",
				PhotoUrl = "https://www.zintuig.nl/images/supplier/222-/xl/bugs0632_a.jpg"
			}
		};

		public bool ShowConfirmDelete { get; set; }
		public Wuppie WuppieToDelete { get; set; }

		void Ok()
		{
			Console.WriteLine("ok");
			ShowConfirmDelete = false;
			Wuppies.Remove(WuppieToDelete);
			WuppieToDelete = null;
		}
		void Cancel()
		{
			Console.WriteLine("cancel");
			ShowConfirmDelete = false;
			WuppieToDelete = null;
		}

		public void ConfirmDelete(Wuppie wuppie)
		{
			ShowConfirmDelete = true;
			WuppieToDelete = wuppie;
		}

		public void HandleSelect(object objWuppie)
		{
			var wuppie = objWuppie as Wuppie;
			Console.WriteLine("Wuppie geselecteerd! " + wuppie.Name);
		}
	}
}
