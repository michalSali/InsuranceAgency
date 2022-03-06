using Autofac.Extras.Moq;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.People.Client;
using BLL.Facades.Client;
using BLL.Services.BackgroundInfo;
using BLL.Services.Client;
using BLL.Services.Connection;
using DAL;
using DAL.Infrastructure.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLTests
{
    public class ClientFacadeTests
    {
        
        
        [Fact]
        public async Task AddBackgroundInfoAsync_Fail()
        {

            BackgroundInfoCreateDTO bgInfo = new BackgroundInfoCreateDTO
            {
                ClientId = 1,
                Text = "sample text"
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IClientService>()
                    .Setup(x => x.GetAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult<ClientGetDTO>(null));
               
                var cls = mock.Create<ClientFacade>();

                var expected = -1;
                var actual = await cls.AddBackgroundInfoAsync(bgInfo);               

                Assert.Equal(expected, actual);
            }
        }
       

        [Fact]
        public async Task AddClientConnectionAsync_Fail()
        {
            ClientGetDTO client_1 = new ClientGetDTO { Id = 1 };
            ClientGetDTO client_2 = new ClientGetDTO { Id = 2 };


            ClientConnectionCreateDTO connection = new ClientConnectionCreateDTO
            {
                ObjectId = 1,
                SubjectId = 2,
                Description = "Brothers"
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IClientService>()
                    .Setup(x => x.GetAsync(1))
                    .Returns(Task.FromResult(client_1));

                mock.Mock<IClientService>()
                    .Setup(x => x.GetAsync(2))
                    .Returns(Task.FromResult<ClientGetDTO>(null));

                
                var cls = mock.Create<ClientFacade>();

                var expected = -1;
                var actual = await cls.AddClientConnectionAsync(connection);
                               
                Assert.Equal(expected, actual);
            }
        }
       

        [Fact]
        public async Task ChangeAgentAsync_Fail()
        {           
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IClientService>()
                    .Setup(x => x.GetAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult<ClientGetDTO>(null));

                
                var cls = mock.Create<ClientFacade>();

                var expected = false;
                var actual = await cls.ChangeAgentAsync(1, 1);


                mock.Mock<IClientService>()
                    .Verify(x => x.UpdateAsync(It.IsAny<ClientUpdateDTO>()), Times.Never);
              
                Assert.Equal(expected, actual);
            }
        }
    
        
    }   
    
}
