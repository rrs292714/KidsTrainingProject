using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsGaming.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    GamePrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FullName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PasswordSalt = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Membership = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInfo__1788CC4C7EC86069", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__UserInfo__RoleId__3D5E1FD2",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "BuyGame",
                columns: table => new
                {
                    BuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BuyGame__6DF70D4F242C675C", x => x.BuyId);
                    table.ForeignKey(
                        name: "FK__BuyGame__GameId__440B1D61",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK__BuyGame__UserId__44FF419A",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "BuyMemberships",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TicketCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyMemberships", x => x.id);
                    table.ForeignKey(
                        name: "FK_BuyMemberships_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((2))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MemberSh__4D9BB84A0A4893A2", x => x.SubId);
                    table.ForeignKey(
                        name: "FK__MemberShi__UserI__403A8C7D",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyGame_GameId",
                table: "BuyGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyGame_UserId",
                table: "BuyGame",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyMemberships_UserId",
                table: "BuyMemberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShip_UserId",
                table: "MemberShip",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_RoleId",
                table: "UserInfo",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyGame");

            migrationBuilder.DropTable(
                name: "BuyMemberships");

            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
