using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityConnect.DataAccess.Migrations
{
    public partial class mig_8_addColumn_Isfav_toActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Activities",
                type: "bit",
                nullable: true,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Activities");
        }
    }
}
