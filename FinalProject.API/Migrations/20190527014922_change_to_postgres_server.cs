using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProject.API.Migrations
{
    public partial class change_to_postgres_server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "DevPlans",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DevPlans",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "DevPlans",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DevPlans",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
