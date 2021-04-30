using DagtrainingStudenten.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DagtrainingStudenten.Pages
{
	public partial class Basics
	{
		[Inject] public HttpClient HttpClient { get; set; }

		public Wuppie NewWuppie { get; set; } = new Wuppie();

		List<Wuppie> Wuppies;

		protected async override Task OnInitializedAsync() // lifecycle
		{
			Wuppies = (await HttpClient.GetFromJsonAsync<IEnumerable<Wuppie>>("http://localhost:3000/wuppies")).ToList();
		}

		void AddWuppie()
		{
			NewWuppie.Id = Wuppies.Max(x => x.Id) + 1;
			Wuppies.Add(NewWuppie);
			NewWuppie = new Wuppie();
		}
	}
}
