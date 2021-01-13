﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Concrete.EntityFramework;
using System.Linq;
using Shop.DataAccess.Tests.EntityFramework.Configuration;


namespace Shop.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void Create_database_with_mappings()
        {
            var db = new ShopTestContext();
            var categories = db.Categories.ToList();
        }

    }

}
