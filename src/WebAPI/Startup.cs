using System;
using AutoMapper;
using AutoMapper.Configuration;
using BLL.Config;
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
using BLL.Facades.Client;
using BLL.Facades.Conflict;
using BLL.Facades.Director;
using BLL.Facades.Insurance;
using BLL.Facades.InsuranceAgent;
using BLL.Facades.User;
using BLL.QueryObjects;
using BLL.Services.Administrator;
using BLL.Services.BackgroundInfo;
using BLL.Services.Client;
using BLL.Services.Conflict;
using BLL.Services.ConflictInvolvement;
using BLL.Services.ConflictRecord;
using BLL.Services.Connection;
using BLL.Services.Director;
using BLL.Services.Gear;
using BLL.Services.Insurance;
using BLL.Services.InsuranceAgent;
using BLL.Services.InsuranceOffer;
using BLL.Services.User;
using DAL;
using DAL.DbContextFactory;
using DAL.Infrastructure.Repositories;
using DAL.Infrastructure.UnitOfWork;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace WebAPI
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // userService, IBackgroundInfoService backgroundInfoService, IGearService gearService, IClientConnectionService connectionService
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDbFactory(services);
            services.AddSingleton<IUnitOfWorkProvider, UnitOfWorkProvider>();
            
            ConfigureMapper(services);

            ConfigureFacades(services);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDbFactory(IServiceCollection services)
        {
            services.AddDbContextFactory<ParamilitaryGroupsInsuranceAgencyDbContext>(options =>
            {
                //options.UseSqlServer("Server=(localdb)\\mssqllocaldb; Initial Catalog = ParamilitaryDb7")
                options.UseSqlServer("Server=tcp:localhost;UID=SA;PWD=Offlinik232;Initial Catalog=ParamilitaryDb")
                    .UseLoggerFactory(LoggerFactory.Create(
                        builder =>
                        {
                            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
                                                                   && level == LogLevel.Information).AddConsole();
                        })).EnableSensitiveDataLogging();
            });
            services.AddSingleton<IDbContextFactory<DbContext>, 
                GenericDbContextFactoryWrapper<ParamilitaryGroupsInsuranceAgencyDbContext>>();
        }
        

        private void ConfigureMapper(IServiceCollection services)
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;
            MappingConfig.ConfigureMapping(cfg);
            MapperConfiguration config = new MapperConfiguration(cfg);
            IMapper mapper = new Mapper(config);
            services.AddSingleton(mapper);
        }

        private void ConfigureServiceWithQueryObjectAndRepository<TIService, TService, TEntity, TEntityGetDto>(
            IServiceCollection services)
            where TIService : class
            where TService : class, TIService
            where TEntity : class, IEntity, new()
            where TEntityGetDto: class, new()
        {
            services.AddScoped<IRepository<TEntity>, GenericRepository<TEntity>>();
            services
                .AddScoped<IQueryObject<TEntityGetDto, TEntity>,
                    QueryObject<TEntityGetDto, TEntity>>();
            services.AddScoped<TIService, TService>();
        }

        private void ConfigureFacades(IServiceCollection services)
        {
            ConfigurePeopleFacades(services);
            ConfigureConflictFacade(services);
            ConfigureInsuranceFacade(services);
        }

        private void ConfigurePeopleFacades(IServiceCollection services)
        {
            ConfigureServiceWithQueryObjectAndRepository<IClientConnectionService, ClientConnectionService,
                ClientConnection, ClientConnectionGetDTO>(services);
            
            ConfigureServiceWithQueryObjectAndRepository<IGearService, GearService,
                Gear, GearGetDTO>(services);

            ConfigureServiceWithQueryObjectAndRepository<IBackgroundInfoService, BackgroundInfoService,
                BackgroundInfo, BackgroundInfoGetDTO>(services);

            ConfigureServiceWithQueryObjectAndRepository<IUserService, UserService,
                User, UserGetDTO>(services);
            
            ConfigureServiceWithQueryObjectAndRepository<IAdministratorService, AdministratorService,
                Administrator, AdministratorGetDTO>(services);
            
            ConfigureServiceWithQueryObjectAndRepository<IDirectorService, DirectorService,
                Director, DirectorGetDTO>(services);
            
            ConfigureServiceWithQueryObjectAndRepository<IInsuranceAgentService, InsuranceAgentService,
                InsuranceAgent, InsuranceAgentGetDTO>(services);

            ConfigureServiceWithQueryObjectAndRepository<IClientService, ClientService,
                Client, ClientGetDTO>(services);

            services.AddScoped<IClientFacade, ClientFacade>();
            services.AddScoped<IDirectorFacade, DirectorFacade>();
            services.AddScoped<IUserManagementFacade, UserManagementFacade>();
            services.AddScoped<IInsuranceAgentFacade, InsuranceAgentFacade>();
        }
        
        private void ConfigureConflictFacade(IServiceCollection services)
        {
            ConfigureServiceWithQueryObjectAndRepository<IConflictRecordService, ConflictRecordService,
                ConflictRecord, ConflictRecordGetDTO>(services);
            ConfigureServiceWithQueryObjectAndRepository<IConflictInvolvementService, ConflictInvolvementService,
                ConflictInvolvement, ConflictInvolvementGetDTO>(services);
            ConfigureServiceWithQueryObjectAndRepository<IConflictService, ConflictService,
                Conflict, ConflictGetDTO>(services);

            services.AddScoped<IConflictFacade, ConflictFacade>();
        }

        private void ConfigureInsuranceFacade(IServiceCollection services)
        {
            ConfigureServiceWithQueryObjectAndRepository<IInsuranceOfferService, InsuranceOfferService,
                InsuranceOffer, InsuranceOfferGetDTO>(services);

            ConfigureServiceWithQueryObjectAndRepository<IInsuranceService, InsuranceService,
                ClientInsurance, InsuranceGetDTO>(services);

            services.AddScoped<IInsuranceFacade, InsuranceFacade>();
        }
    }
}
