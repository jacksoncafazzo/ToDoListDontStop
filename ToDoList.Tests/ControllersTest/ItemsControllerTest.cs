using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemsControllerTest
    {
        [Fact]
        public void Get_ViewResult_index_Test()
        {
            //Arrange
            ItemsController controller = new ItemsController();
            IActionResult actionResult = controller.Edit(2);
            ViewResult editView = controller.Edit(2) as ViewResult;

            //Act
            var result = editView.ViewData.Model;

            //Assert
            Assert.IsType<Item>(result);
        }
    }
}