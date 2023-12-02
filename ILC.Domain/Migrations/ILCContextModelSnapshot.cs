﻿// <auto-generated />
using System;
using ILC.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ILC.Domain.Migrations
{
    [DbContext(typeof(ILCContext))]
    partial class ILCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ILC.Domain.DBEntities.AboutUsHomeSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TextAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("AboutUsHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.AgentHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SubTitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("AgentHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.BlogHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("BlogHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.ProductHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("ProductHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.ServiceHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("ServiceHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.SilderHomeSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstHeadTextAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstHeadTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ParagraphAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParagraphEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondHeadTextAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondtHeadTextEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("SilderHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.StaffHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("StaffHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.SupportHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LastModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LocationAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("SupportHome");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.AboutUsHomeSection", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.AgentHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.BlogHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.Category", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.HasOne("ILC.Domain.DBEntities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.ProductHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.ServiceHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.SilderHomeSection", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.StaffHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("ILC.Domain.DBEntities.SupportHome", b =>
                {
                    b.HasOne("ILC.Domain.DBEntities.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ILC.Domain.DBEntities.AppUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
