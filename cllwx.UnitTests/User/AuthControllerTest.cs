using cllwx.Controllers;
using cllwx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class AuthControllerTest
    {
        [Test]
        public void TestGetUser()
        {
            var authController = new AuthController();
            var actionResult = authController.Get() as ObjectResult;
            try
            {
                Assert.NotNull(actionResult);
                Assert.True(actionResult is ObjectResult);
                Assert.IsInstanceOf<User>(actionResult.Value);
                Assert.AreEqual(StatusCodes.Status200OK, actionResult.StatusCode);
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}