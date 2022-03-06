using Autofac.Extras.Moq;
using AutoMapper;
using AutoMapper.Configuration;
using BLL.Config;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.Facades.Conflict;
using BLL.Services.Conflict;
using BLL.Services.ConflictInvolvement;
using BLL.Services.ConflictRecord;
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
    public class ConflictFacadeTests
    {
        
        private IMapper mapper;
        private void ConfigureMapper()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();
            MappingConfig.ConfigureMapping(cfg);
            MapperConfiguration config = new MapperConfiguration(cfg);
            mapper = new Mapper(config);
        }


        [Fact]
        public async Task UpdateAsync_Fail()
        {            
            ConflictUpdateDTO conflict = new ConflictUpdateDTO { Id = 1 };            

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConflictService>()
                    .Setup(x => x.GetAsync(It.IsAny<int>(), false))
                    .Returns(Task.FromResult<ConflictGetDTO>(null));


                var cls = mock.Create<ConflictFacade>();

                var expected = false;
                var actual = await cls.UpdateAsync(conflict);

                mock.Mock<IConflictService>()
                    .Verify(x => x.UpdateAsync(conflict), Times.Never);

                mock.Mock<IUnitOfWork>()
                    .Verify(x => x.CommitAsync(), Times.Never);

                Assert.Equal(expected, actual);
            }
        }


        [Fact]
        public async Task DeleteAsync_Fail()
        {           
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConflictService>()
                    .Setup(x => x.GetAsync(It.IsAny<int>(), false))
                    .Returns(Task.FromResult<ConflictGetDTO>(null));                

                var cls = mock.Create<ConflictFacade>();

                var expected = false;
                var actual = await cls.DeleteAsync(1);

                mock.Mock<IConflictService>()
                    .Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Never);

                mock.Mock<IUnitOfWork>()
                    .Verify(x => x.CommitAsync(), Times.Never);

                Assert.Equal(expected, actual);
            }
        }
     


        [Fact]
        public async Task AddConflictRecordAsync_Fail()
        {
            ConflictRecordCreateDTO conflictRecord = new ConflictRecordCreateDTO { ConflictInvolvementId = 1 };
            ConflictInvolvementGetDTO conflictInvolvement = new ConflictInvolvementGetDTO() { Id = 1 };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConflictInvolvementService>()
                    .Setup(x => x.GetAsync(It.IsAny<int>(), false))
                    .Returns(Task.FromResult<ConflictInvolvementGetDTO>(null));
               
               
                var cls = mock.Create<ConflictFacade>();

                var expected = -1;
                var actual = await cls.AddConflictRecordAsync(conflictRecord);

                mock.Mock<IUnitOfWork>()
                    .Verify(x => x.CommitAsync(), Times.Never);

                mock.Mock<IConflictRecordService>()
                    .Verify(x => x.CreateAsync(It.IsAny<ConflictRecordCreateDTO>()), Times.Never);

                Assert.Equal(expected, actual);
            }
        }
        
    }
}
