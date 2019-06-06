using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.API.Migrations
{
    public partial class SeedInitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Archived", "FirstName", "FullName", "HireDate", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, false, "Sandra", "Sandra Surita Dialogo", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dialogo", "Surita" },
                    { 2, false, "Patrixia", "Patrixia Bearis Tingson", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tingson", "Bearis" },
                    { 3, false, "Isaiah", "Isaiah Valentin Leonardo", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo", "Valentin" },
                    { 4, false, "Danica", "Danica Surita Dialogo", new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dialogo", "Surita" }
                });

            migrationBuilder.InsertData(
                table: "DevPlans",
                columns: new[] { "Id", "Description", "DueDate", "EmployeeId", "StatusCode", "Title" },
                values: new object[,]
                {
                    { 1, "react-auth0-authentication-security", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Completed", "Securing React Apps with Auth0" },
                    { 2, "react-big-picture", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "In Progress", "React: The Big Picture" },
                    { 3, "react-creating-reusable-components", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Not Started", "Creating Reusable React Components" },
                    { 5, "react-redux-react-router-es6", new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Not Started", "Building Applications with React and Redux" },
                    { 4, "javascript-development-environment", new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Not Started", "Building a JavaScript Development Environment" },
                    { 6, "react-flux-building-applications", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Not Started", "Building Applications in React and Flux" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DevPlans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
