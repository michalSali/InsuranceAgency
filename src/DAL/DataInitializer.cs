using DAL.Models;
using DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace DAL
{
    /// <summary>
    /// Static class that is used to seed the data
    /// </summary>
    public static class DataInitializer
    {
        public static string CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 128 / 8, 100000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] subkey = deriveBytes.GetBytes(160 / 8);

                return string.Join(",", Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }

        //Specifying IDs is mandatory if seeding db through OnModelCreating method
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Users
            var admin_user = new User() {Id = 999, Name = "pmagent", Birth = new DateTime(1987, 5, 14), Gender = Gender.Male, PasswordHash = CreateHash("pv179Project") };
            var user_1 = new User() { Id = 1, Name = "Terry Fisher", Birth = new DateTime(1987, 5, 14), Gender = Gender.Male, PasswordHash = CreateHash("1Terry")};
            var user_2 = new User() { Id = 2, Name = "Richard Clarkson", Birth = new DateTime(1986, 3, 8), Gender = Gender.Male, PasswordHash = CreateHash("1Richard") };
            var user_3 = new User() { Id = 3, Name = "George Hammond", Birth = new DateTime(1984, 9, 12), Gender = Gender.Male, PasswordHash = CreateHash("1George") };
            var user_4 = new User() { Id = 4, Name = "Grigoriy Korolev", Birth = new DateTime(1992, 12, 10), Gender = Gender.Male, PasswordHash = CreateHash("1Grigoriy") };
            var user_5 = new User() { Id = 5, Name = "Vladimir Korolev", Birth = new DateTime(1994, 1, 25), Gender = Gender.Male, PasswordHash = CreateHash("1Vladimir") };
            var user_6 = new User() { Id = 6, Name = "Christopher Judge", Birth = new DateTime(1987, 8, 14), Gender = Gender.Male, PasswordHash = CreateHash("1Christopher") };
            var user_7 = new User() { Id = 7, Name = "Cliff Simon", Birth = new DateTime(1983, 6, 6), Gender = Gender.Male, PasswordHash = CreateHash("1Cliff") };
            var user_8 = new User() { Id = 8, Name = "Charles Shaw", Birth = new DateTime(1988, 6, 11), Gender = Gender.Male, PasswordHash = CreateHash("1Charles") };
            var user_9 = new User() { Id = 9, Name = "Rebecca Pearson", Birth = new DateTime(1989, 4, 5), Gender = Gender.Female, PasswordHash = CreateHash("1Rebecca") };
            var user_10 = new User() { Id = 10, Name = "Maria Mitchell", Birth = new DateTime(1991, 5, 4), Gender = Gender.Female, PasswordHash = CreateHash("1Maria") };

            var users = new List<User> {admin_user, user_1, user_2, user_3, user_4, user_5, user_6, user_7, user_8, user_9, user_10 };

            // Administrators
            var admin_admin = new Administrator() { Id = admin_user.Id };
            var admins = new List<Administrator> { admin_admin };


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

            var gears = client_1_gear.Concat(client_2_gear).Concat(client_3_gear).Concat(client_4_gear).Concat(client_5_gear).ToList();

            // Client's background info

            var bg_info_1 = new BackgroundInfo() { Id = 1, ClientId = user_1.Id, Text = "Nationality: American", Date = new DateTime(2020, 9, 12) };
            var bg_info_2 = new BackgroundInfo() { Id = 2, ClientId = 1, Text = "Family Status: Married", Date = new DateTime(2020, 10, 8) };
            var bg_info_3 = new BackgroundInfo() { Id = 3, ClientId = 4, Text = "Nationality: Russian", Date = new DateTime(2019, 8, 3) };

            List<BackgroundInfo> bg_infos = new List<BackgroundInfo>() { bg_info_1, bg_info_2, bg_info_3 };

            var client_1_info = new List<BackgroundInfo>
            {
                bg_info_1, bg_info_2
            };

            var client_4_info = new List<BackgroundInfo>
            {
                bg_info_3
            };

            // Clients
            var admin_client = new Client() {Id = admin_user.Id, InsuranceAgentId = 6};
            var user_1_client = new Client() { Id = user_1.Id, InsuranceAgentId = 6 };
            var user_2_client = new Client() { Id = user_2.Id, InsuranceAgentId = 6 };
            var user_3_client = new Client() { Id = user_3.Id, InsuranceAgentId = 6 };
            var user_4_client = new Client() { Id = user_4.Id, InsuranceAgentId = 6 };
            var user_5_client = new Client() { Id = user_5.Id, InsuranceAgentId = 6 };
            
            var clients = new List<Client> { admin_client, user_1_client, user_2_client, user_3_client, user_4_client, user_5_client };
                  

            var client_connection_4_5 = new ClientConnection()
            {
                Id = 1,
                SubjectId = user_4_client.Id,
                ObjectId = user_5_client.Id,
                Description = "Subject and object are brothers"
            };

            List<ClientConnection> client_connections = new List<ClientConnection>() { client_connection_4_5 };

            
            // added collection InsuranceAgent.Clients to the InsuranceAgent model -> need to update Fluent API in DBContext ?
            var admin_agent = new InsuranceAgent() {Id = admin_user.Id, DirectorId = 7};
            var user_6_agent = new InsuranceAgent() { Id = user_6.Id, DirectorId = 7 };
            var agents = new List<InsuranceAgent> { admin_agent, user_6_agent };

            var conflict_1 = new Conflict() { Id = 1, DirectorId = 7, Name = "conflict_1", Location = "Location_1", Beginning = new DateTime(2016, 4, 14) };
            var conflict_2 = new Conflict() { Id = 2, DirectorId = 7, Name = "conflict_2", Location = "Location_2", Beginning = new DateTime(2018, 6, 22) };
            var conflict_3 = new Conflict() { Id = 3, DirectorId = 7, Name = "conflict_3", Location = "Location_3", Beginning = new DateTime(1999, 9, 9) };
            var conflicts = new List<Conflict> { conflict_1, conflict_2, conflict_3 };

            // missing: InsuranceOffers
            var admin_director = new Director() {Id = admin_user.Id, Section = "AdminSection"};
            var user_7_director = new Director() { Id = user_7.Id, Section = "section_1" };
            var directors = new List<Director>() { admin_director, user_7_director };
           

            // conflict records and conflict involvements
            ConflictRecord record_1 = new ConflictRecord()
            {
                Id = 1,
                ConflictInvolvementId = 1,
                Description = "record_1",
                Date = new DateTime(1999, 9, 9),
                BalanceChange = 250
            };

            ConflictRecord record_2 = new ConflictRecord()
            {
                Id = 2,
                ConflictInvolvementId = 1,
                Description = "record_2",
                Date = new DateTime(2020, 4, 4),
                BalanceChange = -69
            };

            ConflictRecord record_3 = new ConflictRecord()
            {
                Id = 3,
                ConflictInvolvementId = 2,
                Description = "record_3",
                Date = new DateTime(2018, 3, 2),
                BalanceChange = 420
            };

            ConflictRecord record_4 = new ConflictRecord()
            {
                Id = 4,
                ConflictInvolvementId = 3,
                Description = "record_4",
                Date = new DateTime(1986, 1, 8),
                BalanceChange = -1337
            };

            var conflict_records = new List<ConflictRecord>() { record_1, record_2, record_3, record_4 };

            List<ConflictRecord> involvement_1_records = new List<ConflictRecord>() { record_1, record_2 };
            List<ConflictRecord> involvement_2_records = new List<ConflictRecord>() { record_3 };
            List<ConflictRecord> involvement_3_records = new List<ConflictRecord>() { record_4 };

            ConflictInvolvement involvement_1 = new ConflictInvolvement()
            {
                Id = 1,
                ClientId = 1,
                ConflictId = 1,
                //ConflictRecords = involvement_1_records
            };            

            ConflictInvolvement involvement_2 = new ConflictInvolvement()
            {
                Id = 2,
                ClientId = 1,
                ConflictId = 2,
                //ConflictRecords = involvement_2_records
            };

            ConflictInvolvement involvement_3 = new ConflictInvolvement()
            {
                Id = 3,
                ClientId = 2,
                ConflictId = 3,
                //ConflictRecords = involvement_3_records
            };

            List<ConflictInvolvement> conflict_involvements = new List<ConflictInvolvement>() { involvement_1, involvement_2, involvement_3 };


            // insurance offers
            InsuranceOffer offer_1 = new InsuranceOffer()
            {
                Id = 1,
                DirectorId = 7,
                CreationDate = new DateTime(2020, 5, 8),
                ExpirationDate = new DateTime(2022, 9, 9),
                Description = "The best insurance"                
            };

            InsuranceOffer offer_2 = new InsuranceOffer()
            {
                Id = 2,
                DirectorId = 7,
                CreationDate = new DateTime(2016, 3, 12),
                ExpirationDate = new DateTime(2020, 9, 12),
                Description = "2 year-insurance"
            };

            InsuranceOffer offer_3 = new InsuranceOffer()
            {
                Id = 3,
                DirectorId = 7,
                CreationDate = new DateTime(2019, 11, 6),
                ExpirationDate = new DateTime(2022, 10, 8),
                Description = "all-inclusive insurance"
            };

            InsuranceOffer offer_4= new InsuranceOffer()
            {
                Id = 4,
                DirectorId = 7,
                CreationDate = new DateTime(2015, 1, 1),
                ExpirationDate = new DateTime(2020, 12, 31),
                Description = "long-term insurance"
            };

            List<InsuranceOffer> insurance_offers = new List<InsuranceOffer>() { offer_1, offer_2, offer_3, offer_4 };
            

            // insurances

            // approved
            ClientInsurance insurance_1 = new ClientInsurance()
            {
                Id = 1,
                ClientId = 1,
                InsuranceOfferId = 1,
                CreationDate = new DateTime(2020, 8, 6),
                ExpirationDate = offer_1.ExpirationDate,
                Approved = true,
                Declined = false
            };

            // declined
            ClientInsurance insurance_2 = new ClientInsurance()
            {
                Id = 2,
                ClientId = 1,
                InsuranceOfferId = 2,
                CreationDate = new DateTime(2017, 4, 8),
                ExpirationDate = new DateTime(2019, 4, 8),
                Approved = false,
                Declined = true
            };

            // waiting for approval
            ClientInsurance insurance_3 = new ClientInsurance()
            {
                Id = 3,
                ClientId = 1,
                InsuranceOfferId = 3,
                CreationDate = new DateTime(2021, 2, 10),
                ExpirationDate = new DateTime(2022, 2, 10),
                Approved = false,
                Declined = false
            };

            // expired
            ClientInsurance insurance_4 = new ClientInsurance()
            {
                Id = 4,
                ClientId = 1,
                InsuranceOfferId = 4,
                CreationDate = new DateTime(2015, 2, 2),
                ExpirationDate = new DateTime(2018, 2, 10),
                Approved = false,
                Declined = false
            };

            // approved
            ClientInsurance insurance_5 = new ClientInsurance()
            {
                Id = 5,
                ClientId = 2,
                InsuranceOfferId = 1,
                CreationDate = new DateTime(2020, 9, 10),
                ExpirationDate = new DateTime(2021, 9, 10),
                Approved = true,
                Declined = false
            };

            // expired
            ClientInsurance insurance_6 = new ClientInsurance()
            {
                Id = 6,
                ClientId = 2,
                InsuranceOfferId = 2,
                CreationDate = new DateTime(2017, 1, 1),
                ExpirationDate = new DateTime(2019, 1, 1),
                Approved = true,
                Declined = false
            };

            List<ClientInsurance> insurances = new List<ClientInsurance>() { insurance_1, insurance_2, insurance_3, insurance_4, insurance_5, insurance_6 };


            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Administrator>().HasData(admins);
            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<Director>().HasData(directors);
            modelBuilder.Entity<BackgroundInfo>().HasData(bg_infos);
            modelBuilder.Entity<InsuranceAgent>().HasData(agents);
            modelBuilder.Entity<Gear>().HasData(gears);
            modelBuilder.Entity<Conflict>().HasData(conflicts);
            modelBuilder.Entity<ConflictRecord>().HasData(conflict_records);
            modelBuilder.Entity<ConflictInvolvement>().HasData(conflict_involvements);
            modelBuilder.Entity<InsuranceOffer>().HasData(insurance_offers);
            modelBuilder.Entity<ClientInsurance>().HasData(insurances);
            modelBuilder.Entity<ClientConnection>().HasData(client_connections);
        }
    }
}