using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.Facades.Common;
using BLL.QueryObjects;
using BLL.Services.Insurance;
using BLL.Services.InsuranceOffer;
using DAL.Infrastructure.UnitOfWork;

namespace BLL.Facades.Insurance
{
    public class InsuranceFacade : FacadeBase, IInsuranceFacade
    {
        private readonly IInsuranceService insuranceService;
        private readonly IInsuranceOfferService insuranceOfferService;
        public InsuranceFacade(IUnitOfWorkProvider unitOfWorkProvider,
            IInsuranceService insuranceService,
            IInsuranceOfferService insuranceOfferService) : base(unitOfWorkProvider)
        {
            this.insuranceService = insuranceService;
            this.insuranceOfferService = insuranceOfferService;
        }

        public async Task<bool> DeleteInsuranceAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await insuranceService.GetAsync(id, false)) == null)
                {
                    return false;
                }
                
                await insuranceService.DeleteAsync(id);
                await uow.CommitAsync();
                return true;
            }
        }

        public async Task<int> CreateInsuranceOfferAsync(InsuranceOfferCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var id = await insuranceOfferService.CreateAsync(entityDto);
                await uow.CommitAsync();
                return id;
            }
        }
        
        public async Task<int> CreateInsuranceAsync(InsuranceCreateDTO entityDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var id = await insuranceService.CreateAsync(entityDto);
                await uow.CommitAsync();
                return id;
            }
        }


        public async Task<InsuranceOfferGetDTO> GetInsuranceOfferAsync(int id, bool include=true)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await insuranceOfferService.GetAsync(id, include);
            }
        }

        public async Task<InsuranceGetDTO> GetInsuranceAsync(int id, bool include = true)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await insuranceService.GetAsync(id, include);
            }
        }
        
        private async Task<bool> UpdateAsync<TUpdateDto, TGetDto>(TUpdateDto entityDto, Func<TUpdateDto,
            Task> updateAsync, Func<int, bool, Task<TGetDto>> getAsync)
            where TUpdateDto : DTOBase, new()
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                if ((await getAsync(entityDto.Id, false)) == null)
                {
                    return false; // not in database
                }
                await updateAsync(entityDto);
                await uow.CommitAsync();
            }

            return true;
        }

        public Task<bool> UpdateInsuranceAsync(InsuranceUpdateDTO entityDto)
        {
            return UpdateAsync(entityDto, insuranceService.UpdateAsync, insuranceService.GetAsync);
        }

        public Task<bool> UpdateInsuranceOfferAsync(InsuranceOfferUpdateDTO entityDto)
        {
            return UpdateAsync(entityDto, insuranceOfferService.UpdateAsync, insuranceOfferService.GetAsync);
        }

        public async Task<IEnumerable<InsuranceOfferGetDTO>> GetAllInsuranceOffersAsync(
           int? directorId = null,  bool active = true, bool sorted=true, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            { 
                return (await insuranceOfferService.GetAllOffersAsync(
                    directorId, active, sorted, queryPagingDto)).Dtos;
            }
        }

        public async Task<IEnumerable<InsuranceOfferGetDTO>> GetAllInsuranceOffersWithIncludesAsync(
           int? directorId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await insuranceOfferService.GetAllOffersWithIncludesAsync(
                    directorId, active, sorted, queryPagingDto)).Dtos;
            }
        }


        public async Task<IEnumerable<InsuranceGetDTO>> GetAllInsurancesAsync(
            int? clientId = null, bool active=true, bool sorted=true, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await insuranceService.GetAllInsurancesAsync(
                    clientId, active, sorted, queryPagingDto)).Dtos;
            }
        }

        public async Task<IEnumerable<InsuranceGetDTO>> GetAllInsurancesWithIncludesAsync(
            int? clientId = null, bool active = true, bool sorted = true, QueryPagingDTO? queryPagingDto = null)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return (await insuranceService.GetAllInsurancesWithIncludesAsync(
                    clientId, active, sorted, queryPagingDto)).Dtos;
            }
        }
    }
}