# Paramilitary Groups Insurance Agency: Data Access Layer

Data access layer that is used to communicate with EFCore database.

## File Structure

* `DbContextFactory` - contains factory for db contexts
* `Infrastructure` - contains DAL infrastructure
    * `Repositories` - contains repositories
    * `UnitOfWork` - contains unit of work and unit of work provider
* `Migrations` - contains migrations for the database
* `Models` - contains entities (models) used in the database
* `DataInitializer.cs` - class used to seed the data
* `ParamilitaryGroupsInsuranceAgencyDbContext.cs` - class that represents EFCore DbContext that is used

