// <auto-generated />
using System;
using Dinglo.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dinglo.Infra.Migrations
{
    [DbContext(typeof(DingloContext))]
    partial class DingloContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Release")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppVersions");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Account.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AspNetUserIdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityDocumentNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleDefault")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AspNetUserIdentityId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.CustAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityDocumentNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefixKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustAccounts");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.CustAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrincipal")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("CustAddresses");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.CustContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrincipal")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("CustContacts");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AGRO_HerdManager_BreedId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_DeathCauseId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_DrugId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_ExpenseId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_HealthRatingId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_OriginId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_PastureId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_StatusId")
                        .HasColumnType("int");

                    b.Property<int>("AGRO_HerdManager_TypeId")
                        .HasColumnType("int");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByAppUserId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EarringNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EarringNumberFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EarringNumberMom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecCustId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WeaningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AGRO_HerdManager_BreedId");

                    b.HasIndex("AGRO_HerdManager_DeathCauseId");

                    b.HasIndex("AGRO_HerdManager_DrugId");

                    b.HasIndex("AGRO_HerdManager_ExpenseId");

                    b.HasIndex("AGRO_HerdManager_HealthRatingId");

                    b.HasIndex("AGRO_HerdManager_OriginId");

                    b.HasIndex("AGRO_HerdManager_PastureId");

                    b.HasIndex("AGRO_HerdManager_StatusId");

                    b.HasIndex("AGRO_HerdManager_TypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManagers");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Breeds");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_DeathCause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_DeathCauses");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Drugs");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Expenses");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_HealthRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_HealthRatings");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Origins");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Pasture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Pastures");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Status");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CustAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustAccountId");

                    b.ToTable("AGRO_HerdManager_Types");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.AppUser", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.Account.UserIdentity", "AspNetUserIdentity")
                        .WithMany()
                        .HasForeignKey("AspNetUserIdentityId");
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.CustAddress", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustAccount")
                        .WithMany("CustAddress")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.CustContact", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustAccount")
                        .WithMany("CustContacts")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Breed", "AGRO_HerdManager_Breed")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_BreedId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_DeathCause", "AGRO_HerdManager_DeathCause")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_DeathCauseId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Drug", "AGRO_HerdManager_Drug")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_DrugId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Expense", "AGRO_HerdManager_Expense")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_ExpenseId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_HealthRating", "AGRO_HerdManager_HealthRating")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_HealthRatingId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Origin", "AGRO_HerdManager_Origin")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_OriginId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Pasture", "AGRO_HerdManager_Pasture")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_PastureId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Status", "AGRO_HerdManager_Status")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_StatusId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Type", "AGRO_HerdManager_Type")
                        .WithMany()
                        .HasForeignKey("AGRO_HerdManager_TypeId")
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.AppUser", "CreatedByAppUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManagers")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Breed", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Breeds")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_DeathCause", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_DeathCauses")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Drug", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Drugs")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Expense", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany()
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_HealthRating", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_HealthRatings")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Origin", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Origins")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Pasture", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Pastures")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Status", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Status")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Dinglo.Domain.Entities.Modules.AGRO_HerdManager.AGRO_HerdManager_Type", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.CustAccount", "CustoAccount")
                        .WithMany("AGRO_HerdManager_Types")
                        .HasForeignKey("CustAccountId")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.Account.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.Account.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dinglo.Domain.Entities.Account.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dinglo.Domain.Entities.Account.UserIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
