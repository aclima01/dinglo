using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dinglo.Infra.Migrations
{
    public partial class refactMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Release = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdentityDocumentNr = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    PrefixKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    IdentityDocumentNr = table.Column<string>(nullable: true),
                    RoleDefault = table.Column<string>(nullable: true),
                    AspNetUserIdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AspNetUsers_AspNetUserIdentityId",
                        column: x => x.AspNetUserIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Breeds_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_DeathCauses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_DeathCauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_DeathCauses_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Drugs_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Expenses_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_HealthRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_HealthRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_HealthRatings_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Origins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Origins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Origins_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Pastures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Pastures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Pastures_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Status_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManager_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManager_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManager_Types_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustAddresses_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    CustAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustContacts_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGRO_HerdManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedByAppUserId = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    RecCustId = table.Column<string>(nullable: true),
                    EarringNumber = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    WeaningDate = table.Column<DateTime>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: true),
                    EarringNumberFather = table.Column<string>(nullable: true),
                    EarringNumberMom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Observations = table.Column<string>(nullable: true),
                    CustAccountId = table.Column<Guid>(nullable: false),
                    AGRO_HerdManager_BreedId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_DeathCauseId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_DrugId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_ExpenseId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_HealthRatingId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_OriginId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_PastureId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_StatusId = table.Column<int>(nullable: false),
                    AGRO_HerdManager_TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGRO_HerdManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Breeds_AGRO_HerdManager_BreedId",
                        column: x => x.AGRO_HerdManager_BreedId,
                        principalTable: "AGRO_HerdManager_Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_DeathCauses_AGRO_HerdManager_DeathCauseId",
                        column: x => x.AGRO_HerdManager_DeathCauseId,
                        principalTable: "AGRO_HerdManager_DeathCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Drugs_AGRO_HerdManager_DrugId",
                        column: x => x.AGRO_HerdManager_DrugId,
                        principalTable: "AGRO_HerdManager_Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Expenses_AGRO_HerdManager_ExpenseId",
                        column: x => x.AGRO_HerdManager_ExpenseId,
                        principalTable: "AGRO_HerdManager_Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_HealthRatings_AGRO_HerdManager_HealthRatingId",
                        column: x => x.AGRO_HerdManager_HealthRatingId,
                        principalTable: "AGRO_HerdManager_HealthRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Origins_AGRO_HerdManager_OriginId",
                        column: x => x.AGRO_HerdManager_OriginId,
                        principalTable: "AGRO_HerdManager_Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Pastures_AGRO_HerdManager_PastureId",
                        column: x => x.AGRO_HerdManager_PastureId,
                        principalTable: "AGRO_HerdManager_Pastures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Status_AGRO_HerdManager_StatusId",
                        column: x => x.AGRO_HerdManager_StatusId,
                        principalTable: "AGRO_HerdManager_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AGRO_HerdManager_Types_AGRO_HerdManager_TypeId",
                        column: x => x.AGRO_HerdManager_TypeId,
                        principalTable: "AGRO_HerdManager_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_AppUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AGRO_HerdManagers_CustAccounts_CustAccountId",
                        column: x => x.CustAccountId,
                        principalTable: "CustAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Breeds_CustAccountId",
                table: "AGRO_HerdManager_Breeds",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_DeathCauses_CustAccountId",
                table: "AGRO_HerdManager_DeathCauses",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Drugs_CustAccountId",
                table: "AGRO_HerdManager_Drugs",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Expenses_CustAccountId",
                table: "AGRO_HerdManager_Expenses",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_HealthRatings_CustAccountId",
                table: "AGRO_HerdManager_HealthRatings",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Origins_CustAccountId",
                table: "AGRO_HerdManager_Origins",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Pastures_CustAccountId",
                table: "AGRO_HerdManager_Pastures",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Status_CustAccountId",
                table: "AGRO_HerdManager_Status",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManager_Types_CustAccountId",
                table: "AGRO_HerdManager_Types",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_BreedId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_DeathCauseId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_DeathCauseId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_DrugId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_ExpenseId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_HealthRatingId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_HealthRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_OriginId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_PastureId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_PastureId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_StatusId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_AGRO_HerdManager_TypeId",
                table: "AGRO_HerdManagers",
                column: "AGRO_HerdManager_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_CreatedById",
                table: "AGRO_HerdManagers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AGRO_HerdManagers_CustAccountId",
                table: "AGRO_HerdManagers",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AspNetUserIdentityId",
                table: "AppUsers",
                column: "AspNetUserIdentityId");

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
                name: "IX_CustAddresses_CustAccountId",
                table: "CustAddresses",
                column: "CustAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CustContacts_CustAccountId",
                table: "CustContacts",
                column: "CustAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGRO_HerdManagers");

            migrationBuilder.DropTable(
                name: "AppVersions");

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
                name: "CustAddresses");

            migrationBuilder.DropTable(
                name: "CustContacts");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Breeds");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_DeathCauses");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Drugs");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Expenses");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_HealthRatings");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Origins");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Pastures");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Status");

            migrationBuilder.DropTable(
                name: "AGRO_HerdManager_Types");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustAccounts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
