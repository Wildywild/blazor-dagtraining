using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagtrainingStudenten.Shared
{
	public partial class Autocompleter<TItem>
	{
		[Parameter] public List<TItem> Data { get; set; }

		public string Query { get; set; }
		public List<AutocompleterItem> Suggestions { get; set; }

		[Parameter] public EventCallback OnSelect { get; set; }

		[Parameter] public RenderFragment<AutocompleterItem> ItemTemplate { get; set; }


		public void Autocomplete(KeyboardEventArgs args)
		{
			if (new string[] { "ArrowDown", "ArrowUp", "Enter" }.Contains(args.Key))
			{
				return;
			}

			if (Query == null)
			{
				Suggestions = null;
				return;
			}

			Suggestions = new List<AutocompleterItem>();

			foreach (var item in Data)
			{
				var props = item.GetType().GetProperties();

				foreach (var prop in props.Where(x => x.PropertyType == typeof(string)))
				{
					var value = prop.GetValue(item) as string;
					if (value.ToLower().Contains(Query.ToLower()))
					{
						Suggestions.Add(new AutocompleterItem { Item = item });
						break;
					}
				}
			}
		}

		public async Task HandleKeyDown(KeyboardEventArgs args)
		{
			if (args.Key == "ArrowDown")
			{
				Next();
			}
			else if (args.Key == "ArrowUp")
			{
				// Previous();
			}
			else if (args.Key == "Enter")
			{
				await Select();
			}
		}

		public void Next()
		{
			for (int i = 0; i < Suggestions.Count; i++)
			{
				if (Suggestions[i].IsHighlighted)
				{
					Suggestions[i].IsHighlighted = false;

					if (i != Suggestions.Count - 1)
					{
						Suggestions[i + 1].IsHighlighted = true;
					}

					return;
				}
			}

			Suggestions[0].IsHighlighted = true;
		}

		public async Task Select()
		{
			var item = Suggestions.Find(x => x.IsHighlighted).Item;
			await OnSelect.InvokeAsync(item);
		}

		public class AutocompleterItem
		{
			public bool IsHighlighted { get; set; }

			public TItem Item { get; set; }
		}
	}
}
