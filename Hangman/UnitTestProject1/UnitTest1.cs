using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using Hangman.Data;
using Hangman.Models;
using Hangman.Repository;
using Hangman.Web;
using Hangman.Web.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country() { Name = "New country1" });
            countries.Add(new Country() { Name = "New country2" });

            var countryRepoMoc = new Mock<IRepository<Country>>();
            countryRepoMoc.Setup(x => x.All()).Returns(countries.AsQueryable());

            var uowMoc = new Mock<IUowData>();

            uowMoc.Setup(x => x.SaveChanges()).Returns(() => { return 5; });
            uowMoc.Setup(x => x.Countries).Returns(countryRepoMoc.Object);

            var controller = new CountryController(uowMoc.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result, "The view is null");

            var model = result.Model as IEnumerable<Country>;

            Assert.IsNotNull(model, "The model should be not null");

            int expected = 2;

            Assert.AreEqual(expected, model.Count());
        }
    }
}
