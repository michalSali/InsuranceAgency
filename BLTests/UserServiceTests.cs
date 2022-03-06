using Autofac.Extras.Moq;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.User;
using BLL.QueryObjects;
using BLL.QueryObjects.FilterDTOs;
using BLL.QueryObjects.Filters;
using BLL.Services.User;
using DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLTests
{
    public class UserServiceTests
    {                      

        [Fact]
        public async Task GetAllUsersAsync_WithInclude()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Setup(x => x.ExecuteQuery(null))
                    .Returns(Task.FromResult<QueryResultDTO<UserGetDTO>>(null));
               
                var cls = mock.Create<UserService>();

                QueryResultDTO<UserGetDTO> expected = null;
                var actual = await cls.GetAllUsersAsync(true);
               
                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.AddFilter(It.IsAny<QueryFilterDTO<User>>()), Times.Once);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.ExecuteQuery(null), Times.Once);

                Assert.Equal(expected, actual);
            }
        }

        
        [Fact]
        public async Task GetAllUsersAsync_WithoutInclude()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Setup(x => x.ExecuteQuery(null))
                    .Returns(Task.FromResult<QueryResultDTO<UserGetDTO>>(null));

                var cls = mock.Create<UserService>();

                QueryResultDTO<UserGetDTO> expected = null;
                var actual = await cls.GetAllUsersAsync(false);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.AddFilter(It.IsAny<QueryFilterDTO<User>>()), Times.Never);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.ExecuteQuery(null), Times.Once);

                Assert.Equal(expected, actual);
            }
        }


        [Fact]
        public async Task GetUserByNameAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var name = "Pepega";
                UserGetDTO user = new UserGetDTO { Id = 1, Name = name };
                List<UserGetDTO> userDTOs = new List<UserGetDTO> { user };
                QueryResultDTO<UserGetDTO> queryResult = new QueryResultDTO<UserGetDTO>(userDTOs, null);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Setup(x => x.ExecuteQuery(null))
                    .Returns(Task.FromResult(queryResult));

                var cls = mock.Create<UserService>();

                var expected = user;
                var actual = await cls.GetByNameAsync(name, true);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.AddFilter(It.IsAny<QueryFilterDTO<User>>()), Times.Once);

                mock.Mock<IQueryObject<UserGetDTO, User>>()
                    .Verify(x => x.ExecuteQuery(null), Times.Once);

                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Id, actual.Id);
            }
        }
        
    }
}
