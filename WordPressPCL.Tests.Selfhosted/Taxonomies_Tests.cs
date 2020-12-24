﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Utility;
using WordPressPCL.Tests.Selfhosted.Utility;

namespace WordPressPCL.Tests.Selfhosted
{
    [TestClass]
    public class Taxonomies_Tests
    {
        private static WordPressClient _clientAuth;

        [ClassInitialize]
        public static async Task Init(TestContext testContext)
        {
            _clientAuth = await ClientHelper.GetAuthenticatedWordPressClient(testContext);
        }

        [TestMethod]
        public async Task Taxonomies_Read()
        {
            var taxonomies = await _clientAuth.Taxonomies.GetAll();
            Assert.IsNotNull(taxonomies);
            Assert.AreNotEqual(taxonomies.Count(), 0);
        }

        [TestMethod]
        public async Task Taxonomies_Get()
        {
            var taxonomies = await _clientAuth.Taxonomies.Get();
            Assert.IsNotNull(taxonomies);
            Assert.AreNotEqual(taxonomies.Count(), 0);
        }

        [TestMethod]
        public async Task Taxonomies_Query()
        {
            var queryBuilder = new TaxonomiesQueryBuilder()
            {
                Type = "post"
            };
            var queryresult = await _clientAuth.Taxonomies.Query(queryBuilder);
            Assert.AreEqual(queryBuilder.BuildQueryURL(), "?type=post");
            Assert.IsNotNull(queryresult);
            Assert.AreNotSame(queryresult.Count(), 0);
        }
    }
}