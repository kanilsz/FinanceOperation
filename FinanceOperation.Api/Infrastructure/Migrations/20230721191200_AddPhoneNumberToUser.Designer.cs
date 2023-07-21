﻿// <auto-generated />
using System;
using FinanceOperation.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230721191200_AddPhoneNumberToUser")]
    partial class AddPhoneNumberToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanceOperation.Api.Domain.Propositions.DepositProposition", b =>
                {
                    b.Property<int>("DepositPropositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepositPropositionId"));

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("PropositionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Summary")
                        .HasColumnType("float");

                    b.Property<int>("UserIdentityId")
                        .HasColumnType("int");

                    b.HasKey("DepositPropositionId");

                    b.HasIndex("UserIdentityId");

                    b.ToTable("DepositProposition");
                });

            modelBuilder.Entity("FinanceOperation.Domain.Propositions.CreditProposition", b =>
                {
                    b.Property<int>("CreditPropositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditPropositionId"));

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("PropositionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Summary")
                        .HasColumnType("float");

                    b.Property<int>("UserIdentityId")
                        .HasColumnType("int");

                    b.HasKey("CreditPropositionId");

                    b.HasIndex("UserIdentityId");

                    b.ToTable("CreditProposition");
                });

            modelBuilder.Entity("FinanceOperation.Domain.Users.UserIdentity", b =>
                {
                    b.Property<int>("UserIdentityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserIdentityId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserIdentityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinanceOperation.Api.Domain.Propositions.DepositProposition", b =>
                {
                    b.HasOne("FinanceOperation.Domain.Users.UserIdentity", null)
                        .WithMany("Deposits")
                        .HasForeignKey("UserIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceOperation.Domain.Propositions.CreditProposition", b =>
                {
                    b.HasOne("FinanceOperation.Domain.Users.UserIdentity", null)
                        .WithMany("Credits")
                        .HasForeignKey("UserIdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceOperation.Domain.Users.UserIdentity", b =>
                {
                    b.Navigation("Credits");

                    b.Navigation("Deposits");
                });
#pragma warning restore 612, 618
        }
    }
}
