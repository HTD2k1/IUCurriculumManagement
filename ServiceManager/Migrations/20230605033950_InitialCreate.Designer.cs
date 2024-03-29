﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceManager;

#nullable disable

namespace ServiceManager.Migrations
{
    [DbContext(typeof(ServiceContext))]
    [Migration("20230605033950_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ServiceManager.MicroService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MicroServices");
                });

            modelBuilder.Entity("ServiceManager.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MicroServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MicroServiceId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ServiceManager.Status", b =>
                {
                    b.HasOne("ServiceManager.MicroService", null)
                        .WithMany("StatusLog")
                        .HasForeignKey("MicroServiceId");
                });

            modelBuilder.Entity("ServiceManager.MicroService", b =>
                {
                    b.Navigation("StatusLog");
                });
#pragma warning restore 612, 618
        }
    }
}
