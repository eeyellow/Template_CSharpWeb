using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Template_CSharpWeb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, comment: "流水號")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名稱"),
                    CountyID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "縣市代號"),
                    CountyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "縣市代碼"),
                    EngName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "英文名稱"),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: true, comment: "座標點位"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "CONVERT(bit, 0)", comment: "是否刪除"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "新增日期"),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "更新日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.ID);
                },
                comment: "縣市");

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, comment: "流水號")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名稱"),
                    CountyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "縣市名稱"),
                    CountyID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "縣市代號"),
                    CountyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "縣市代碼"),
                    TownID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "鄉鎮市區代號"),
                    TownCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "鄉鎮市區代碼"),
                    EngName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "英文名稱"),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: true, comment: "座標點位"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "CONVERT(bit, 0)", comment: "是否刪除"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "新增日期"),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "更新日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.ID);
                },
                comment: "鄉鎮市區");

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, comment: "流水號")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名稱"),
                    Account = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "帳號"),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false, comment: "密碼"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "CONVERT(bit, 0)", comment: "是否刪除"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "新增日期"),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "更新日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false, comment: "流水號")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名稱"),
                    VillageCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "村里代碼"),
                    CountyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "縣市名稱"),
                    CountyID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "縣市代號"),
                    CountyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "縣市代碼"),
                    TownName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "鄉鎮市區名稱"),
                    TownID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "鄉鎮市區代號"),
                    TownCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "鄉鎮市區代碼"),
                    EngName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "英文名稱"),
                    Note = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "備註"),
                    Geom = table.Column<Geometry>(type: "geometry", nullable: true, comment: "座標點位"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "CONVERT(bit, 0)", comment: "是否刪除"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "新增日期"),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "更新日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.ID);
                },
                comment: "村里");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_County_IsDelete",
                table: "County",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Town_IsDelete",
                table: "Town",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_IsDelete",
                table: "UserProfile",
                column: "IsDelete");

            migrationBuilder.CreateIndex(
                name: "IX_Village_IsDelete",
                table: "Village",
                column: "IsDelete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
