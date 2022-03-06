using AutoMapper;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.DTOs.People.Administrator;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Config
{
    /// <summary>
    /// Class that is used to configure mapping for AutoMapper
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Configures mapping based on config
        /// </summary>
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Administrator, AdministratorCreateDTO>().ReverseMap();
            config.CreateMap<Administrator, AdministratorGetDTO>().ReverseMap();

            config.CreateMap<BackgroundInfo, BackgroundInfoCreateDTO>().ReverseMap();
            config.CreateMap<BackgroundInfo, BackgroundInfoGetDTO>().ReverseMap();
            config.CreateMap<BackgroundInfo, BackgroundInfoUpdateDTO>().ReverseMap();

            config.CreateMap<Client, ClientCreateDTO>().ReverseMap();
            config.CreateMap<Client, ClientUpdateDTO>().ReverseMap();
            config.CreateMap<Client, ClientGetDTO>()
                .ForMember(cd => cd.Connections, c => c.MapFrom(cp => cp.SubjectConnections.Union(cp.ObjectConnections)))
                .ForMember(cd => cd.Conflicts, c => c.MapFrom(cp => cp.ConflictInvolvements.Select(ci => ci.Conflict).Distinct()))
                .ForMember(cd => cd.UserInfo, c => c.MapFrom(cp => cp.User))
                .ForMember(cd => cd.Insurances, c => c.MapFrom(cp => cp.ClientInsurances))
                .ForMember(cd => cd.InsuranceAgentInfo, c => c.MapFrom(cp => cp.InsuranceAgent))
                .ReverseMap();

            config.CreateMap<Client, ClientGetAggregatedDTO>()
                .ForMember(cd => cd.ActiveConflicts, c => c.MapFrom(cp => cp.ConflictInvolvements.Select(ci => ci.Conflict).Where(c => c.End != null).Count()))
                .ForMember(cd => cd.TotalConflicts, c => c.MapFrom(cp => cp.ConflictInvolvements.Count()))
                .ForMember(cd => cd.TotalBalanceRecord, c => c.MapFrom(cp => cp.ConflictInvolvements.Sum(ci => ci.ConflictRecords.Sum(cr => cr.BalanceChange))))
                .ForMember(cd => cd.ActiveInsurances, c => c.MapFrom(cp => cp.ClientInsurances.Where(ci => ci.ExpirationDate == null || ci.ExpirationDate.Value > DateTime.Now).Count()))
                .ForMember(cd => cd.TotalInsurances, c => c.MapFrom(cp => cp.ClientInsurances.Count()))
                .ForMember(cd => cd.ConnectionCount, c => c.MapFrom(cp => cp.ObjectConnections.Union(cp.SubjectConnections).Count()))
                .ForMember(cd => cd.UserInfo, c => c.MapFrom(cp => cp.User))
                .ReverseMap();

            config.CreateMap<ClientGetDTO, ClientGetAggregatedDTO>()
                .ForMember(cd => cd.ActiveConflicts, c => c.MapFrom(cp => cp.Conflicts.Where(c => c.End != null).Count()))
                .ForMember(cd => cd.TotalConflicts, c => c.MapFrom(cp => cp.Conflicts.Count()))
                .ForMember(cd => cd.TotalBalanceRecord, c => c.MapFrom(cp => cp.Conflicts.Sum(c => c.ConflictRecords.Sum(cr => cr.BalanceChange))))
                .ForMember(cd => cd.ActiveInsurances, c => c.MapFrom(cp => cp.Insurances.Where(ci => ci.ExpirationDate == null || ci.ExpirationDate.Value > DateTime.Now).Count()))
                .ForMember(cd => cd.TotalInsurances, c => c.MapFrom(cp => cp.Insurances.Count()))
                .ForMember(cd => cd.ConnectionCount, c => c.MapFrom(cp => cp.Connections.Count()))
                .ReverseMap();
            

            config.CreateMap<ClientConnection, ClientConnectionCreateDTO>().ReverseMap();
            config.CreateMap<ClientConnection, ClientConnectionGetDTO>().ReverseMap();
            config.CreateMap<ClientConnection, ClientConnectionUpdateDTO>().ReverseMap();

            config.CreateMap<ClientInsurance, InsuranceCreateDTO>().ReverseMap();
            config.CreateMap<ClientInsurance, InsuranceGetDTO>().ReverseMap();
            config.CreateMap<ClientInsurance, InsuranceUpdateDTO>().ReverseMap();

            config.CreateMap<Conflict, ConflictCreateDTO>().ReverseMap();
            config.CreateMap<Conflict, ConflictGetDTO>()
                .ForMember(cd => cd.ConflictRecords, c => c.MapFrom(cp => cp.ConflictInvolvements.SelectMany(ci => ci.ConflictRecords)))
                .ForMember(cd => cd.Participants, c => c.MapFrom(cp => cp.ConflictInvolvements.Select(ci => ci.Client).Distinct()))
                .ReverseMap();

            config.CreateMap<Conflict, ConflictUpdateDTO>().ReverseMap();
            config.CreateMap<ConflictGetDTO, ConflictUpdateDTO>().ReverseMap();

            config.CreateMap<ConflictInvolvement, ConflictInvolvementCreateDTO>().ReverseMap();
            config.CreateMap<ConflictInvolvement, ConflictInvolvementGetDTO>().ReverseMap();

            config.CreateMap<ConflictRecord, ConflictRecordCreateDTO>().ReverseMap();
            config.CreateMap<ConflictRecord, ConflictRecordGetDTO>()
                .ForMember(cd => cd.Paricipant, c => c.MapFrom(cp => cp.ConflictInvolvement.Client))
                .ForMember(cd => cd.Conflict, c => c.MapFrom(cp => cp.ConflictInvolvement.Conflict))
                .ReverseMap();

            config.CreateMap<ConflictRecord, ConflictRecordUpdateDTO>().ReverseMap();

            config.CreateMap<Director, DirectorCreateDTO>().ReverseMap();
            config.CreateMap<Director, DirectorGetDTO>()
                .ForMember(cd => cd.UserInfo, c => c.MapFrom(cp => cp.User))
                .ReverseMap();

            config.CreateMap<Director, DirectorUpdateDTO>().ReverseMap();

            config.CreateMap<Gear, GearCreateDTO>().ReverseMap();
            config.CreateMap<Gear, GearGetDTO>().ReverseMap();
            config.CreateMap<Gear, GearUpdateDTO>().ReverseMap();

            config.CreateMap<InsuranceAgent, InsuranceAgentCreateDTO>().ReverseMap();
            config.CreateMap<InsuranceAgent, InsuranceAgentGetDTO>()
                .ForMember(cd => cd.UserInfo, c => c.MapFrom(cp => cp.User))
                .ReverseMap();

            config.CreateMap<InsuranceGetDTO, InsuranceUpdateDTO>()
                .ForMember(cd => cd.ClientId, c => c.MapFrom(cp => cp.Client.Id))
                .ForMember(cd => cd.InsuranceOfferId, c => c.MapFrom(cp => cp.InsuranceOffer.Id))
                .ReverseMap();


            config.CreateMap<InsuranceOffer, InsuranceOfferCreateDTO>().ReverseMap();
            config.CreateMap<InsuranceOffer, InsuranceOfferGetDTO>()
                .ForMember(cd => cd.Insurances, c => c.MapFrom(cp => cp.ClientInsurances))
                .ReverseMap();
            config.CreateMap<InsuranceOffer, InsuranceOfferUpdateDTO>().ReverseMap();

            config.CreateMap<User, UserCreateDTO>().ReverseMap();
            config.CreateMap<User, UserGetDTO>()
                .ForMember(cd => cd.Role, c => c.MapFrom(cp => ((cp.Administrator == null) ? UserRoleDTO.None : UserRoleDTO.Administrator) |
                                                               ((cp.Client == null) ? UserRoleDTO.None : UserRoleDTO.Client) |
                                                               ((cp.Director == null) ? UserRoleDTO.None : UserRoleDTO.Director) |
                                                               ((cp.InsuranceAgent == null) ? UserRoleDTO.None : UserRoleDTO.InsuranceAgent)))
                .ReverseMap();

            config.CreateMap<User, UserInfoDTO>()
                .ForMember(cd => cd.Role, c => c.MapFrom(cp => ((cp.Administrator == null) ? UserRoleDTO.None : UserRoleDTO.Administrator) |
                                                               ((cp.Client == null) ? UserRoleDTO.None : UserRoleDTO.Client) |
                                                               ((cp.Director == null) ? UserRoleDTO.None : UserRoleDTO.Director) |
                                                               ((cp.InsuranceAgent == null) ? UserRoleDTO.None : UserRoleDTO.InsuranceAgent)))
                .ReverseMap();

            
            config.CreateMap<UserUpdateDTO, User>()
                .ForMember(cd => cd.PasswordHash, c => c.MapFrom(cp => cp.Password));
                

            config.CreateMap<UserGetDTO, UserInfoDTO>().ReverseMap();
        }
    }
}