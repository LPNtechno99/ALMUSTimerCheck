using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp36.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyValues",
                columns: table => new
                {
                    KeyValueID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    NhanLuc = table.Column<string>(nullable: true),
                    NameLeaDer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValues", x => x.KeyValueID);
                });

            migrationBuilder.CreateTable(
                name: "LineStatuses",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LineName = table.Column<string>(nullable: true),
                    SanLuongThucTe = table.Column<int>(nullable: false),
                    SanLuongChenh = table.Column<int>(nullable: false),
                    SanLuongTuTao = table.Column<int>(nullable: false),
                    Mausac = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineStatuses", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "MoDels",
                columns: table => new
                {
                    ModelID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelLabel = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    SumTime = table.Column<int>(nullable: false),
                    Production = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDels", x => x.ModelID);
                });

            migrationBuilder.CreateTable(
                name: "ModelTimers",
                columns: table => new
                {
                    ModelTimerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelTimerName = table.Column<string>(nullable: true),
                    TimeAFrom = table.Column<string>(nullable: true),
                    TimeATo = table.Column<string>(nullable: true),
                    TimeBFrom = table.Column<string>(nullable: true),
                    TimeBTo = table.Column<string>(nullable: true),
                    TimeCFrom = table.Column<string>(nullable: true),
                    TimeCTo = table.Column<string>(nullable: true),
                    TimeDFrom = table.Column<string>(nullable: true),
                    TimeDTo = table.Column<string>(nullable: true),
                    TimeEFrom = table.Column<string>(nullable: true),
                    TimeETo = table.Column<string>(nullable: true),
                    TimeAFromNight = table.Column<string>(nullable: true),
                    TimeAToNight = table.Column<string>(nullable: true),
                    TimeBFromNight = table.Column<string>(nullable: true),
                    TimeBToNight = table.Column<string>(nullable: true),
                    TimeCFromNight = table.Column<string>(nullable: true),
                    TimeCToNight = table.Column<string>(nullable: true),
                    TimeDFromNight = table.Column<string>(nullable: true),
                    TimeDToNight = table.Column<string>(nullable: true),
                    TimeEFromNight = table.Column<string>(nullable: true),
                    TimeEToNight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTimers", x => x.ModelTimerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyValues");

            migrationBuilder.DropTable(
                name: "LineStatuses");

            migrationBuilder.DropTable(
                name: "MoDels");

            migrationBuilder.DropTable(
                name: "ModelTimers");
        }
    }
}
