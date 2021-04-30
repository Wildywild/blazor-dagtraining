using DagtrainingStudenten.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagtrainingStudenten.Pages
{
	public partial class Basics
	{
		public Wuppie NewWuppie { get; set; } = new Wuppie();

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

		void AddWuppie()
		{
			NewWuppie.Id = Wuppies.Max(x => x.Id) + 1;
			Wuppies.Add(NewWuppie);
			NewWuppie = new Wuppie();
		}
	}
}
