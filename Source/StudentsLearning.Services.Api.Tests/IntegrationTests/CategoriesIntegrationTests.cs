﻿namespace StudentsLearning.Services.Api.Tests.IntegrationTests
{
    #region

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class CategoriesIntegrationTests
    {
        [Test]
        public void CategoriesShouldReturnCorrrectResponse()
        {

            //using (TestInit.HttpInvoker)
            //{
            //    var request = new HttpRequestMessage
            //    {
            //        RequestUri = new Uri("http://test.com/api/Categories"),
            //        Method = HttpMethod.Get
            //    };

            //    var result = TestInit.HttpInvoker.SendAsync(request, CancellationToken.None).Result;

            //    Assert.IsNotNull(result);
            //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //}
        }
    }
}