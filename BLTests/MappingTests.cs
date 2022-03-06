using AutoMapper;
using AutoMapper.Configuration;
using BLL.Config;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using DAL.Models;
using DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BLTests
{
    public class MappingTests
    {
        private IMapper mapper;

        #region Initalize Data

        private List<User> users;
        private List<Client> clients;
        private List<BackgroundInfo> backgroundInfos;
        private List<InsuranceAgent> insuranceAgents;
        private List<Conflict> conflicts;
        private List<Gear> gears;
        private List<Director> directors;

        private void InitializeData()
        {
            // Users
            var user_1 = new User() { Id = 1, Name = "Terry Fisher", Birth = new DateTime(1987, 5, 14), Gender = Gender.Male };
            var user_2 = new User() { Id = 2, Name = "Richard Clarkson", Birth = new DateTime(1986, 3, 8), Gender = Gender.Male };
            var user_3 = new User() { Id = 3, Name = "George Hammond", Birth = new DateTime(1984, 9, 12), Gender = Gender.Male };
            var user_4 = new User() { Id = 4, Name = "Grigoriy Korolev", Birth = new DateTime(1992, 12, 10), Gender = Gender.Male };
            var user_5 = new User() { Id = 5, Name = "Vladimir Korolev", Birth = new DateTime(1994, 1, 25), Gender = Gender.Male };
            var user_6 = new User() { Id = 6, Name = "Christopher Judge", Birth = new DateTime(1987, 8, 14), Gender = Gender.Male };
            var user_7 = new User() { Id = 7, Name = "Cliff Simon", Birth = new DateTime(1983, 6, 6), Gender = Gender.Male };
            var user_8 = new User() { Id = 8, Name = "Charles Shaw", Birth = new DateTime(1988, 6, 11), Gender = Gender.Male };
            var user_9 = new User() { Id = 9, Name = "Rebecca Pearson", Birth = new DateTime(1989, 4, 5), Gender = Gender.Female };
            var user_10 = new User() { Id = 10, Name = "Maria Mitchell", Birth = new DateTime(1991, 5, 4), Gender = Gender.Female };

            users = new List<User> { user_1, user_2, user_3, user_4, user_5, user_6, user_7, user_8, user_9, user_10 };

            // Gear
            var rifle_1 = new Gear() { Id = 1, ClientId = 1, Type = GearType.Rifle, Name = "M4A1-S", };
            var rifle_2 = new Gear() { Id = 2, ClientId = 2, Type = GearType.Rifle, Name = "Kar98k", };
            var rifle_3 = new Gear() { Id = 3, ClientId = 3, Type = GearType.Rifle, Name = "FN P90", };
            var rifle_4 = new Gear() { Id = 4, ClientId = 4, Type = GearType.Rifle, Name = "Galil AR", };
            var rifle_5 = new Gear() { Id = 5, ClientId = 5, Type = GearType.Rifle, Name = "AK-47", };

            int offset = 5;
            var handgun_1 = new Gear() { Id = offset + 1, ClientId = 1, Type = GearType.Handgun, Name = "HK P2000", };
            var handgun_2 = new Gear() { Id = offset + 2, ClientId = 2, Type = GearType.Handgun, Name = "Glock-18", };
            var handgun_3 = new Gear() { Id = offset + 3, ClientId = 3, Type = GearType.Handgun, Name = "CZ 75", };

            offset += 3;
            var helmet_1 = new Gear() { Id = offset + 1, ClientId = 1, Type = GearType.Helmet, Name = "Lightweight Helmet", };
            var helmet_2 = new Gear() { Id = offset + 2, ClientId = 2, Type = GearType.Helmet, Name = "F2 SPECTRA", };
            var helmet_3 = new Gear() { Id = offset + 3, ClientId = 3, Type = GearType.Helmet, Name = "BK-3 Helmet", };

            offset += 3;
            var armor_4 = new Gear() { Id = offset + 1, ClientId = 4, Type = GearType.Armor, Name = "Kevlar Armour Vest", };
            var armor_5 = new Gear() { Id = offset + 2, ClientId = 5, Type = GearType.Armor, Name = "Hard Ballistic Plates", };

            offset += 2;
            var throwable_5 = new Gear() { Id = offset + 1, ClientId = 5, Type = GearType.ThrowableWeapon, Name = "Frag grenade", };

            // Client's gear
            var client_1_gear = new List<Gear> { rifle_1, handgun_1, helmet_1 };
            var client_2_gear = new List<Gear> { rifle_2, handgun_2, helmet_2 };
            var client_3_gear = new List<Gear> { rifle_3, handgun_3, helmet_3 };
            var client_4_gear = new List<Gear> { rifle_4, armor_4 };
            var client_5_gear = new List<Gear> { rifle_5, armor_5, throwable_5 };

            gears = client_1_gear.Concat(client_2_gear).Concat(client_3_gear).Concat(client_4_gear).Concat(client_5_gear).ToList();

            // Client's background info
            var bg_info_1 = new BackgroundInfo() { Id = 1, ClientId = 1, Text = "Nationality: American", Date = new DateTime(2020, 9, 12) };
            var bg_info_2 = new BackgroundInfo() { Id = 2, ClientId = 1, Text = "Family Status: Married", Date = new DateTime(2020, 10, 8) };
            var bg_info_3 = new BackgroundInfo() { Id = 3, ClientId = 4, Text = "Nationality: Russian", Date = new DateTime(2019, 8, 3) };

            backgroundInfos = new List<BackgroundInfo>() { bg_info_1, bg_info_2, bg_info_3 };

            var client_1_info = new List<BackgroundInfo>
            {
                bg_info_1, bg_info_2
            };

            var client_4_info = new List<BackgroundInfo>
            {
                bg_info_3
            };

            // Clients
            var user_1_client = new Client() { Id = user_1.Id, User = user_1, BackgroundInfos = client_1_info, Gears = client_1_gear };
            var user_2_client = new Client() { Id = user_2.Id, User = user_2, Gears = client_2_gear };
            var user_3_client = new Client() { Id = user_3.Id, User = user_3, Gears = client_3_gear };
            var user_4_client = new Client() { Id = user_4.Id, User = user_4, BackgroundInfos = client_4_info, Gears = client_4_gear };
            var user_5_client = new Client() { Id = user_5.Id, User = user_5, Gears = client_5_gear };
            
            clients = new List<Client> { user_1_client, user_2_client, user_3_client, user_4_client, user_5_client };
            

            var client_connection_4_5 = new ClientConnection()
            {
                Id = 1,
                SubjectId = user_4_client.Id,
                ObjectId = user_5_client.Id,
                Description = "Subject and object are brothers"
            };

            var client_4_subject_connections = new List<ClientConnection> { client_connection_4_5 };
            var client_5_object_connections = new List<ClientConnection> { client_connection_4_5 };

            var user_6_agent = new InsuranceAgent() { Id = user_6.Id, User = user_6, DirectorId = 7, Clients = clients };
            insuranceAgents = new List<InsuranceAgent> { user_6_agent };

            var conflict_1 = new Conflict() { Id = 1, DirectorId = 7, Name = "conflict_1", Location = "Location_1", Beginning = new DateTime(2016, 4, 14) };
            var conflict_2 = new Conflict() { Id = 2, DirectorId = 7, Name = "conflict_2", Location = "Location_2", Beginning = new DateTime(2018, 6, 22) };
            conflicts = new List<Conflict> { conflict_1, conflict_2 };
            
            var user_7_director = new Director()
            {
                Id = user_7.Id,
                User = user_7,
                InsuranceAgents = insuranceAgents,
                InsuranceOffers = new List<InsuranceOffer>(),
                Section = "section_1",
                Conflicts = conflicts
            };
            directors = new List<Director>() { user_7_director };
        }

        #endregion Initalize Data

        private void ConfigureMapper()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;
            MappingConfig.ConfigureMapping(cfg);
            MapperConfiguration config = new MapperConfiguration(cfg);
            mapper = new Mapper(config);
        }

        [Fact]
        public void ValidConfigurationTest()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;
            MappingConfig.ConfigureMapping(cfg);
            MapperConfiguration config = new MapperConfiguration(cfg);
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void GearTest()
        {

            ConfigureMapper();

            var rifle_1 = new Gear() { Id = 1, ClientId = 1, Type = GearType.Rifle, Name = "M4A1-S", };
            var rifle_2 = new Gear() { Id = 2, ClientId = 2, Type = GearType.Rifle, Name = "Kar98k", };
            var rifle_3 = new Gear() { Id = 3, ClientId = 3, Type = GearType.Rifle, Name = "FN P90", };
            var rifle_4 = new Gear() { Id = 4, ClientId = 4, Type = GearType.Rifle, Name = "Galil AR", };
            var rifle_5 = new Gear() { Id = 5, ClientId = 5, Type = GearType.Rifle, Name = "AK-47", };

            List<Gear> gears = new List<Gear>() { rifle_1, rifle_2, rifle_3, rifle_4, rifle_5 };
            var gearGetDTOs = mapper.Map<List<GearGetDTO>>(gears);

            foreach (var gearGetDTO in gearGetDTOs)
            {
                Assert.NotNull(gearGetDTO.Name);
                Assert.NotEmpty(gearGetDTO.Name);
            }

            var gears_revert = mapper.Map<List<Gear>>(gearGetDTOs);

            foreach (var gear in gears_revert)
            {
                Assert.NotNull(gear.Name);
                Assert.NotEmpty(gear.Name);
            }
        }

        [Fact]
        public void GearTestClient()
        {

            ConfigureMapper();

            var rifle_1 = new Gear() { Id = 1, ClientId = 1, Type = GearType.Rifle, Name = "M4A1-S", };
            var rifle_2 = new Gear() { Id = 2, ClientId = 2, Type = GearType.Rifle, Name = "Kar98k", };
            var rifle_3 = new Gear() { Id = 3, ClientId = 3, Type = GearType.Rifle, Name = "FN P90", };
            var rifle_4 = new Gear() { Id = 4, ClientId = 4, Type = GearType.Rifle, Name = "Galil AR", };
            var rifle_5 = new Gear() { Id = 5, ClientId = 5, Type = GearType.Rifle, Name = "AK-47", };

            List<Gear> gears = new List<Gear>() { rifle_1, rifle_2, rifle_3, rifle_4, rifle_5 };

            Client client = new Client() { Id = 1, Gears = gears };
            ClientGetDTO clientGetDTO = mapper.Map<ClientGetDTO>(client);
            ClientGetAggregatedDTO clientGetAggregatedDTO = mapper.Map<ClientGetAggregatedDTO>(client);

            foreach (var gearGetDTO in clientGetDTO.Gears)
            {
                Assert.NotNull(gearGetDTO.Name);
                Assert.NotEmpty(gearGetDTO.Name);
            }

            foreach (var gearGetDTO in clientGetAggregatedDTO.Gears)
            {
                Assert.NotNull(gearGetDTO.Name);
                Assert.NotEmpty(gearGetDTO.Name);
            }

            var clientGetDTO_revert = mapper.Map<Client>(clientGetDTO);
            var clientGetAggregatedDTO_revert = mapper.Map<Client>(clientGetAggregatedDTO);

            foreach (var gear in clientGetDTO_revert.Gears)
            {
                Assert.NotNull(gear.Name);
                Assert.NotEmpty(gear.Name);
            }

            foreach (var gear in clientGetAggregatedDTO_revert.Gears)
            {
                Assert.NotNull(gear.Name);
                Assert.NotEmpty(gear.Name);
            }
        }

        [Fact]
        public void UserBasicTest()
        {
            ConfigureMapper();

            User user = new User() { Id = 1, Name = "John Smith", Gender = Gender.Male, Birth = new DateTime(1993, 6, 12) };            

            // User => UserGetDTO => User
            UserGetDTO userGetDTO = mapper.Map<UserGetDTO>(user);
            User user_test = mapper.Map<User>(userGetDTO);

            Assert.Equal(user.Id, userGetDTO.Id);
            Assert.Equal(user.Name, userGetDTO.Name);
            Assert.Equal(user.Gender.ToString(), userGetDTO.Gender.ToString()); // cannot compare Genders directly, as it's different Enum Classes
            Assert.Equal(user.Birth, userGetDTO.Birth);

            Assert.Equal(user_test.Id, userGetDTO.Id);
            Assert.Equal(user_test.Name, userGetDTO.Name);
            Assert.Equal(user_test.Gender.ToString(), userGetDTO.Gender.ToString());
            Assert.Equal(user_test.Birth, userGetDTO.Birth);

            // User => UserInfoDTO => User
            UserInfoDTO userInfoDTO = mapper.Map<UserInfoDTO>(user);
            user_test = mapper.Map<User>(userInfoDTO);

            Assert.Equal(user.Id, userInfoDTO.Id);
            Assert.Equal(user.Name, userInfoDTO.Name);
            Assert.Equal(user.Gender.ToString(), userInfoDTO.Gender.ToString());
            Assert.Equal(user.Birth, userInfoDTO.Birth);

            Assert.Equal(user_test.Id, userInfoDTO.Id);
            Assert.Equal(user_test.Name, userInfoDTO.Name);
            Assert.Equal(user_test.Gender.ToString(), userInfoDTO.Gender.ToString());
            Assert.Equal(user_test.Birth, userInfoDTO.Birth);
        }

        [Fact]
        public void UserRoleTest()
        {
            /*
            None = 0,
            Administrator = 1 << 0,
            Director = 1 << 1,
            Client = 1 << 2,
            InsuranceAgent = 1 << 3,
            */

            ConfigureMapper();

            Administrator admin = new Administrator() { Id = 1 };
            Client client = new Client() { Id = 1, InsuranceAgentId = 1 };
            Director director = new Director() { Id = 1 };
            InsuranceAgent agent = new InsuranceAgent() { Id = 1, DirectorId = 1 };

            User user_all = new User() { Id = 1, Administrator = admin, Client = client, Director = director, InsuranceAgent = agent };
            UserGetDTO user_all_GetDTO = mapper.Map<UserGetDTO>(user_all);           

            User user_none = new User() { Id = 2, Administrator = null, Client = null, Director = null, InsuranceAgent = null };
            UserGetDTO user_none_GetDTO = mapper.Map<UserGetDTO>(user_none);           

            User user_admin_client = new User() { Id = 3, Administrator = admin, Client = client, Director = null, InsuranceAgent = null };
            UserGetDTO user_admin_client_GetDTO = mapper.Map<UserGetDTO>(user_admin_client);
          
            Assert.Equal(1 + 2 + 4 + 8, (int)user_all_GetDTO.Role);
            Assert.Equal(0, (int)user_none_GetDTO.Role);
            Assert.Equal(1 + 4, (int)user_admin_client_GetDTO.Role);
        }

        [Fact]
        public void ConflictRecordTest()
        {
            InitializeData();
            ConfigureMapper();

            ConflictRecord record_1 = new ConflictRecord() { Id = 1, ConflictInvolvementId = 1, BalanceChange = 20 };
            ConflictRecord record_2 = new ConflictRecord() { Id = 2, ConflictInvolvementId = 1, BalanceChange = 10 };
            var records = new List<ConflictRecord>() { record_1, record_2 };

            ConflictInvolvement involvement = new ConflictInvolvement() { Id = 1, ConflictRecords = records };
        }

        [Fact]
        public void DirectorTest()
        {
            InitializeData();
            ConfigureMapper();

            var director = directors[0];
            DirectorGetDTO directorGetDTO = mapper.Map<DirectorGetDTO>(director);

            Assert.Equal(director.Id, directorGetDTO.Id);
            Assert.Equal(director.Section, directorGetDTO.Section);

            // User => UserInfoDTO => User
            User user = director.User;
            UserInfoDTO userInfoDTO = mapper.Map<UserInfoDTO>(user);
            User user_test = mapper.Map<User>(userInfoDTO);

            Assert.Equal(user.Id, userInfoDTO.Id);
            Assert.Equal(user.Name, userInfoDTO.Name);
            Assert.Equal(user.Gender.ToString(), userInfoDTO.Gender.ToString());
            Assert.Equal(user.Birth, userInfoDTO.Birth);

            Assert.Equal(user_test.Id, userInfoDTO.Id);
            Assert.Equal(user_test.Name, userInfoDTO.Name);
            Assert.Equal(user_test.Gender.ToString(), userInfoDTO.Gender.ToString());
            Assert.Equal(user_test.Birth, userInfoDTO.Birth);

            // Conflict => ConflictGetDTO => Conflict
            Conflict conflict_1 = director.Conflicts.ToList()[0];
            Conflict conflict_2 = director.Conflicts.ToList()[1];

            ConflictGetDTO conflictGetDTO = mapper.Map<ConflictGetDTO>(conflict_1);
            Conflict conflict_test = mapper.Map<Conflict>(conflictGetDTO);

            // no conflictInvolvements for the time being
            Assert.Equal(conflict_1.Beginning, conflictGetDTO.Beginning);
            Assert.Equal(conflict_1.Description, conflictGetDTO.Description);
            Assert.Equal(conflict_1.End, conflictGetDTO.End);
            Assert.Equal(conflict_1.Id, conflictGetDTO.Id);
            Assert.Equal(conflict_1.Location, conflictGetDTO.Location);
            Assert.Equal(conflict_1.Name, conflictGetDTO.Name);

            Assert.Equal(conflict_test.Beginning, conflictGetDTO.Beginning);
            Assert.Equal(conflict_test.Description, conflictGetDTO.Description);           
            Assert.Equal(conflict_test.End, conflictGetDTO.End);
            Assert.Equal(conflict_test.Id, conflictGetDTO.Id);
            Assert.Equal(conflict_test.Location, conflictGetDTO.Location);
            Assert.Equal(conflict_test.Name, conflictGetDTO.Name);

            // InsuranceAgent => InsuranceAgentGetDTO => Insurance
            InsuranceAgent agent = director.InsuranceAgents.ToList()[0];
            InsuranceAgentGetDTO agentGetDTO = mapper.Map<InsuranceAgentGetDTO>(agent);
            InsuranceAgent agent_test = mapper.Map<InsuranceAgent>(agentGetDTO);
                 
            Assert.Equal(agent.Id, agentGetDTO.Id);
            Assert.Equal(agent.User.Id, agentGetDTO.UserInfo.Id);

            // Client => ClientGetDTO => Client
            foreach (var client in agent.Clients)
            {
                ClientGetDTO clientGetDTO = mapper.Map<ClientGetDTO>(client);
                Client client_test = mapper.Map<Client>(clientGetDTO);

                // not testing Connections/Insurance/ConflictInvolvements as of now
                Assert.Equal(client.Id, clientGetDTO.Id);               
                Assert.Equal(client.User.Id, clientGetDTO.UserInfo.Id);
                
                if (client.BackgroundInfos == null)
                {
                    Assert.True(clientGetDTO.BackgroundInfos == null);
                }
                else
                {
                    // BackgroundInfo => BackgroundInfoGetDTO => BackgroundInfo
                    for (int i = 0; i < client.BackgroundInfos.Count; ++i)
                    {
                        BackgroundInfo bg_info = client.BackgroundInfos.ToList()[i];                        
                        BackgroundInfoGetDTO bg_infoGetDTO = clientGetDTO.BackgroundInfos.ToList()[i];
                        BackgroundInfo bg_info_test = mapper.Map<BackgroundInfo>(bg_infoGetDTO);

                        Assert.Equal(bg_info.Id, bg_infoGetDTO.Id);                       
                        Assert.Equal(bg_info.Date, bg_infoGetDTO.Date);
                        Assert.Equal(bg_info.Text, bg_infoGetDTO.Text);

                        Assert.Equal(bg_info_test.Id, bg_infoGetDTO.Id);                        
                        Assert.Equal(bg_info_test.Date, bg_infoGetDTO.Date);
                        Assert.Equal(bg_info_test.Text, bg_infoGetDTO.Text);
                    }
                }

                if (client.Gears == null)
                {
                    Assert.True(clientGetDTO.Gears == null);
                }
                else
                {
                    // Gear => GearGetDTO => Gear
                    for (int i = 0; i < client.Gears.Count; ++i)
                    {
                        Gear gear = client.Gears.ToList()[i];                        
                        GearGetDTO gearGetDTO = clientGetDTO.Gears.ToList()[i];
                        Gear gear_test = mapper.Map<Gear>(gearGetDTO);

                        Assert.Equal(gear.Id, gearGetDTO.Id);                       
                        Assert.Equal(gear.Name, gearGetDTO.Name);
                        Assert.Equal(gear.Type.ToString(), gearGetDTO.Type.ToString());
                        Assert.Equal(gear.Value, gearGetDTO.Value);

                        Assert.Equal(gear_test.Id, gearGetDTO.Id);                        
                        Assert.Equal(gear_test.Name, gearGetDTO.Name);
                        Assert.Equal(gear_test.Type.ToString(), gearGetDTO.Type.ToString());
                        Assert.Equal(gear_test.Value, gearGetDTO.Value);
                    }
                }
            }
        }
    }
}