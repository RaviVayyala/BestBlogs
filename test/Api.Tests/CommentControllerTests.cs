using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests
{
    public class CommentControllerTests
    {
        private static Guid CommonGuid => new Guid("f8e1d703-b139-4b07-aecb-f9695c9ef5a3");


        [Fact]
        public void GetAll_Returns_Existing_Comments()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();
            commentRepositoryMock.Setup(x => x.GetAll()).Returns(TestData.GetComments());

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).GetAll();

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as IEnumerable<Comment>;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(4, resultObj.ToList().Count);
        }

        [Fact]
        public void Get_Returns_Created_Comment()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();
            commentRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(TestData.GetComments().FirstOrDefault());
            var expected = TestData.GetComments().FirstOrDefault();

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).Get(CommonGuid);

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Comment;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }

        [Fact]
        public void Delete_Returns_True_IfDeleted()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();
           
            commentRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).Delete(CommonGuid);

            // Assert
            var result = actual as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_Returns_False_IfNotDeleted()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();

            commentRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(false);

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).Delete(CommonGuid);

            // Assert
            var result = actual as StatusCodeResult;
            Assert.Equal(204, result.StatusCode);
        }



        [Fact]
        public void Post_Returns_NewlyAdded_Comment()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();
           
            commentRepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).Returns(TestData.GetComments().LastOrDefault());
            var expected = TestData.GetComments().LastOrDefault();

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).Post(new Comment());

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Comment;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }

        [Fact]
        public void Update_Returns_Updated_Post()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<CommentController>>();
           
            commentRepositoryMock.Setup(x => x.Update(It.IsAny<Comment>())).Returns(TestData.GetComments().LastOrDefault());
            var expected = TestData.GetComments().LastOrDefault();

            // Act
            var actual = new CommentController(commentRepositoryMock.Object, loggerRepositoryMock.Object).Put(new Comment());

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Comment;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }
    }
}