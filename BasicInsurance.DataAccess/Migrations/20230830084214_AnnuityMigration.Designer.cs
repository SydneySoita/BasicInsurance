﻿// <auto-generated />
using System;
using BasicInsurance.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicInsurance.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230830084214_AnnuityMigration")]
    partial class AnnuityMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasicInsurance.Models.Models.Annuity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IntrestRate")
                        .HasColumnType("float");

                    b.Property<int>("NumberofPayments")
                        .HasColumnType("int");

                    b.Property<double?>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<string>("PaymentFrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrincipalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Annuity");
                });

            modelBuilder.Entity("BasicInsurance.Models.Models.Undewritingcase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Accidents")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CoverageAmount")
                        .HasColumnType("float");

                    b.Property<string>("HealthCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentFrequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Policytype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PremiumAmount")
                        .HasColumnType("float");

                    b.Property<string>("RiskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskResult")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Undewritingcases");
                });
#pragma warning restore 612, 618
        }
    }
}
