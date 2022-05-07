using System;
using System.Collections.Generic;
using System.Linq;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using Repository;
using Xunit;

namespace Api.Tests
{
    public class PostControllerTests
    {
        private static Guid CommonGuid => new Guid("f8e1d703-b139-4b07-aecb-f9695c9ef5a3");

        [Fact]
        public void GetAll_Returns_Existing_Posts()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.GetAll()).Returns(TestData.GetPosts());
            var expected = new List<Comment>();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).GetAll();

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as IEnumerable<Post>;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(3, resultObj.ToList().Count);
        }

        [Fact]
        public void Post_Returns_Created_Post()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.Create(It.IsAny<Post>())).Returns(TestData.GetPosts().FirstOrDefault());
            var expected = TestData.GetPosts().FirstOrDefault();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).Post(new Post());

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Post;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }

        [Fact]
        public void Delete_Returns_Created_Delete()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);
            var expected = TestData.GetPosts().FirstOrDefault();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).Delete(CommonGuid);

            // Assert
            var result = actual as OkResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_Returns_Created_Delete_False()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(false);
            var expected = TestData.GetPosts().FirstOrDefault();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).Delete(CommonGuid);

            // Assert
            var result = actual as StatusCodeResult;
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void Get_Returns_Existing_Post()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(TestData.GetPosts().LastOrDefault());
            var expected = TestData.GetPosts().LastOrDefault();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).Get(CommonGuid);

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Post;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }

        [Fact]
        public void Update_Returns_Updated_Post()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.Update(It.IsAny<Post>())).Returns(TestData.GetPosts().LastOrDefault());
            var expected = TestData.GetPosts().LastOrDefault();

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).Put(new Post());

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as Post;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultObj);
        }


        [Fact]
        public void GetComments_Returns_Comments_Post()
        {
            // Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();
            var loggerRepositoryMock = new Mock<ILogger<PostController>>();
            var postRepositoryMock = new Mock<IPostRepository>();
            commentRepositoryMock.Setup(x => x.GetByPostId(It.IsAny<Guid>())).Returns(TestData.GetComments(TestData.GetPosts().FirstOrDefault().Id));
            var expected = TestData.GetComments(TestData.GetPosts().FirstOrDefault().Id);

            // Act
            var actual = new PostController(commentRepositoryMock.Object, postRepositoryMock.Object, loggerRepositoryMock.Object).GetComments(CommonGuid);

            // Assert
            var result = actual.Result as OkObjectResult;
            var resultObj = result.Value as IEnumerable<Comment>;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, resultObj.ToList().Count);
        }
    }

}