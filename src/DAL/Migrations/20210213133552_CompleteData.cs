using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CompleteData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_InsuranceAgents_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Gears");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gears");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conflicts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Conflicts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conflicts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ConflictRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "ClientInsurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Declined",
                table: "ClientInsurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClientConnections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "BackgroundInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birth", "Gender", "Name", "Password" },
                values: new object[,]
                {
                    { 999, new DateTime(1987, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "pmagent", "IsnoVnideq7x5rpkMk6bJ5PK52k=,Va3S+BEf6CqpTAYoSegPNw==" },
                    { 1, new DateTime(1987, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Terry Fisher", "CsvwiffhUv+9L/6deMUyfDlqjl8=,5nmFB+tEqLJ90pS//st7qw==" },
                    { 2, new DateTime(1986, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Richard Clarkson", "9ss+7ZAw1oFMochc8UZDQfuOwPE=,abvbKNuT94wS5CUQhY8R+A==" },
                    { 3, new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "George Hammond", "5Eu/AKUecrleXqs3ccxfypJ7isk=,Nt1mgP1g740BbEBGZT0yrg==" },
                    { 4, new DateTime(1992, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Grigoriy Korolev", "Et5xs4f7yoijB3HSzIC6+eGDjjM=,K1vgCbbzgM/YQK/nL61JHg==" },
                    { 5, new DateTime(1994, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Vladimir Korolev", "eFEFCGvj1pK3NrmhXgTS+cwe0E0=,aH+JjgSbpfplfJTIoVG7Mw==" },
                    { 6, new DateTime(1987, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Christopher Judge", "morOz8mToJI6j+7M/W/MIK/Hecs=,2UoL6f9n6OGDBPJTchgflw==" },
                    { 7, new DateTime(1983, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Cliff Simon", "uRlQTWWdRfhvahmpoWygF5EXn9k=,I5b1MsAguBbVw+vmytzDbw==" },
                    { 8, new DateTime(1988, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Charles Shaw", "DkmS6xF5bnV7nIcMUp5B3iNx1aQ=,gazCr7O/8iTD/LzAmnrLsA==" },
                    { 9, new DateTime(1989, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rebecca Pearson", "FoEHaRKnnDtPmApsT2p7ZuQ+Q1Y=,PBik5QZm2mkmGm1B99OZ3g==" },
                    { 10, new DateTime(1991, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maria Mitchell", "aseNUi/rtnkvUW/tuoUCCDJ+5OM=,iCH59QapF4HhPG5kqpJwOA==" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                value: 999);

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Section" },
                values: new object[] { 999, "AdminSection" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Section" },
                values: new object[] { 7, "section_1" });

            migrationBuilder.InsertData(
                table: "Conflicts",
                columns: new[] { "Id", "Beginning", "Description", "DirectorId", "End", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2016, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, "Location_1", "conflict_1" },
                    { 2, new DateTime(2018, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, "Location_2", "conflict_2" },
                    { 3, new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, "Location_3", "conflict_3" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceAgents",
                columns: new[] { "Id", "DirectorId" },
                values: new object[,]
                {
                    { 999, 7 },
                    { 6, 7 }
                });

            migrationBuilder.InsertData(
                table: "InsuranceOffers",
                columns: new[] { "Id", "CreationDate", "Description", "DirectorId", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best insurance", 7, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2016, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 year-insurance", 7, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "all-inclusive insurance", 7, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "long-term insurance", 7, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "InsuranceAgentId" },
                values: new object[,]
                {
                    { 999, 6 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 6 },
                    { 4, 6 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "BackgroundInfos",
                columns: new[] { "Id", "ClientId", "Date", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationality: American" },
                    { 2, 1, new DateTime(2020, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Status: Married" },
                    { 3, 4, new DateTime(2019, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nationality: Russian" }
                });

            migrationBuilder.InsertData(
                table: "ClientInsurances",
                columns: new[] { "Id", "Approved", "ClientId", "CreationDate", "Declined", "ExpirationDate", "InsuranceOfferId" },
                values: new object[,]
                {
                    { 5, true, 2, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, false, 1, new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, true, 2, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, false, 1, new DateTime(2017, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, true, 1, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, false, 1, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "ConflictInvolvements",
                columns: new[] { "Id", "ClientId", "ConflictId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "Id", "ClientId", "Type", "Value" },
                values: new object[,]
                {
                    { 5, 5, 1, 0 },
                    { 12, 4, 3, 0 },
                    { 4, 4, 1, 0 },
                    { 11, 3, 2, 0 },
                    { 8, 3, 0, 0 },
                    { 7, 2, 0, 0 },
                    { 10, 2, 2, 0 },
                    { 2, 2, 1, 0 },
                    { 13, 5, 3, 0 },
                    { 9, 1, 2, 0 },
                    { 6, 1, 0, 0 },
                    { 1, 1, 1, 0 },
                    { 3, 3, 1, 0 },
                    { 14, 5, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "ConflictRecords",
                columns: new[] { "Id", "BalanceChange", "ConflictInvolvementId", "Date", "Description" },
                values: new object[,]
                {
                    { 1, 250, 1, new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "record_1" },
                    { 2, -69, 1, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "record_2" },
                    { 3, 420, 2, new DateTime(2018, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "record_3" },
                    { 4, -1337, 3, new DateTime(1986, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "record_4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InsuranceAgentId",
                table: "Clients",
                column: "InsuranceAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_InsuranceAgents_InsuranceAgentId",
                table: "Clients",
                column: "InsuranceAgentId",
                principalTable: "InsuranceAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_InsuranceAgents_InsuranceAgentId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_InsuranceAgentId",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "BackgroundInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BackgroundInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BackgroundInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClientInsurances",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "ConflictRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConflictRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConflictRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ConflictRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "InsuranceAgents",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ConflictInvolvements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConflictInvolvements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConflictInvolvements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InsuranceOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InsuranceOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InsuranceOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InsuranceOffers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conflicts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conflicts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conflicts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InsuranceAgents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "ClientInsurances");

            migrationBuilder.DropColumn(
                name: "Declined",
                table: "ClientInsurances");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Gears",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gears",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "Directors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conflicts",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Conflicts",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conflicts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ConflictRecords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClientConnections",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "BackgroundInfos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_InsuranceAgents_Id",
                table: "Clients",
                column: "Id",
                principalTable: "InsuranceAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
