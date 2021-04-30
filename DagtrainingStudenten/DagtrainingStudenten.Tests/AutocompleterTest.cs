using Bunit;
using DagtrainingStudenten.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DagtrainingStudenten.Tests
{
	[TestClass]
	public class AutocompleterTest
	{
		IRenderedComponent<Autocompleter<Car>> cut;
		Autocompleter<Car> sut; // system under test
		KeyboardEventArgs keyboardArgs = new KeyboardEventArgs { Key = "i" };

		[TestInitialize]
		public void Initialize()
		{
			var ctx = new Bunit.TestContext();
			cut = ctx.RenderComponent<Autocompleter<Car>>(parameters =>
			{
				parameters.Add(x => x.Data, new List<Car>
				{
					new Car { Id = 4, Make = "Opel", Model = "Astra" },
					new Car { Id = 8, Make = "Ferrari", Model = "Testarossa" },
					new Car { Id = 15, Make = "Bugati", Model = "Veyron" }
				});
			});
			sut = cut.Instance;
		}

		[TestMethod]
		public void AutocompleteWithBasicQueryShouldGiveSuggestions()
		{
			sut.Query = "i";

			sut.Autocomplete(keyboardArgs);

			Assert.AreEqual(2, sut.Suggestions.Count);
			Assert.AreEqual("Ferrari", sut.Suggestions[0].Item.Make);
			Assert.AreEqual("Bugati", sut.Suggestions[1].Item.Make);
		}

		[TestMethod]
		public void AutocompleteWithCapitalQueryShouldGiveSameSuggestions()
		{
			sut.Query = "I";

			sut.Autocomplete(keyboardArgs);

			Assert.AreEqual(2, sut.Suggestions.Count);
			Assert.AreEqual("Ferrari", sut.Suggestions[0].Item.Make);
			Assert.AreEqual("Bugati", sut.Suggestions[1].Item.Make);
		}

		[TestMethod]
		public void AutocompleteWithNoQueryShouldEmptySuggestions()
		{
			sut.Query = null;

			sut.Autocomplete(keyboardArgs);

			Assert.IsNull(sut.Suggestions);
		}

		[TestMethod]
		public void AutocompleteShouldOnlyAddItemsUniquely()
		{
			sut.Query = "a";

			sut.Autocomplete(keyboardArgs);

			Assert.AreEqual(3, sut.Suggestions.Count);
		}

		[TestMethod]
		public void NextShouldSupportGoingToTheFirstItem()
		{
			sut.Query = "e";
			sut.Autocomplete(keyboardArgs);

			sut.Next();

			Assert.IsTrue(sut.Suggestions[0].IsHighlighted);
		}

		[TestMethod]
		public void NextShouldSupportGoingBeyondTheFirstItem()
		{
			sut.Query = "e";
			sut.Autocomplete(keyboardArgs);

			sut.Next();
			sut.Next();

			Assert.AreEqual(1, sut.Suggestions.Count(x => x.IsHighlighted));
			Assert.IsTrue(sut.Suggestions[1].IsHighlighted);
		}

		[TestMethod]
		public void NextShouldSupportGoingBeyondTheLastItem()
		{
			sut.Query = "e";
			sut.Autocomplete(keyboardArgs);
			foreach(var suggestion in sut.Suggestions)
			{
				sut.Next();
			}

			sut.Next();

			Assert.IsFalse(sut.Suggestions.Any(x => x.IsHighlighted));
		}
	}
}
