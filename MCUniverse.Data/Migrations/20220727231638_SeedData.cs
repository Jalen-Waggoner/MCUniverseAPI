using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCUniverse.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "NickFury@MCUniversity.com", "Nicholas", 0, "Fury", "EyePatch", "(555)-650-6639", "NicholasFury" },
                    { 2, "Thanos@MCUniversity.com", "Thanos", 0, "Purpleman", "50/50", "(555)-242-3649", "TheTitan" },
                    { 3, "JaneFoster@MCUniversity.com", "Jane", 1, "Foster", "ThorsAHunk", "(555)-242-1277", "JaneFoster" },
                    { 4, "AbrahamErskine@MCUniversity.com", "Abraham", 0, "Erskine", "AmericaForever", "(555)-242-4847", "AbrahamErskine" },
                    { 5, "ProfSelvig@MCUniversity.com", "Professor", 0, "Selvig", "UnderwearMan", "(555)-532-5100", "ProfSelvig" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateCreated", "DateOfBirth", "Email", "FullName", "Gender", "LastModified", "OriginCountry", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "1600 Pennsylvania Ave NW", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4294), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1876), "SteveRogers@MCUniversity.com", "Steven Rogers", "Male", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4324), "United States of America", "FREEDOM", "(555)-650-1234", "SteveRogers" },
                    { 2, "846 Wakanda Ln", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1866), "BuckyBoy@MCUniversity.com", "Bucky Barnes", "Male", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4328), "United States of America", "Soldier76", "(555)-514-6542", "BuckyBarnes" },
                    { 3, "355 Taldore Dr", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1950), "WingMan@MCUniversity.com", "Samuel Wilson", "Male", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4331), "United States of America", "CapForever", "(555)-675-2548", "SamWilly" },
                    { 4, "658 Dog Breath Blvd", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "SpidyGuy@MCUniversity.com", "Peter Parker", "Male", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4335), "United States of America", "SpiderGuy", "(555)-654-9873", "PeterPiper" },
                    { 5, "486 CrackBaby Ave", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1969), "ScarletBitch@MCUniversity.com", "Wanda Maximoff", "Female", new DateTime(2022, 7, 27, 19, 16, 38, 638, DateTimeKind.Local).AddTicks(4338), "Sokovia", "MissYouVision", "(555)-127-1237", "WandaWitchin" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Building", "ClassDays", "Credits", "EndTime", "FacultyId", "Name", "RoomNumber", "Semester", "StartTime" },
                values: new object[,]
                {
                    { 1, "Philip Colson Memorial Hall", "Monday, Wednesday, Friday", 3, "10:00", 1, "Saving the World 101", 201, 1, "9:00" },
                    { 2, "Philip Colson Memorial Hall", "Wednesday", 5, "11:00", 2, "Metal Hearts 101", 201, 1, "10:00" },
                    { 3, "Falcon's Nest", "Monday, Friday", 3, "12:00", 3, "I Am Groot", 125, 2, "11:00" },
                    { 4, "Philip Colson Memorial Hall", "Tuesday, Thursday", 3, "4:00", 4, "Infinity Stones 201", 211, 0, "2:15" },
                    { 5, "Philip Colson Memorial Hall", "Monday, Wednesday, Friday", 3, "10:00", 5, "Catch Phrases 301", 154, 1, "9:00" },
                    { 6, "Bifrost Keep", "Thursday", 7, "4:00", 3, "Catch Phrases 101", 510, 1, "3:00" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
