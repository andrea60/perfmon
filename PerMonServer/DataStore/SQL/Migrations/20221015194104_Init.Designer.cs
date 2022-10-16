﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerMonServer.DataStore.SQL;

#nullable disable

namespace PerMonServer.DataStore.SQL.Migrations
{
    [DbContext(typeof(PerfMonDbContext))]
    [Migration("20221015194104_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("PerMonServer.Models.Agent", b =>
                {
                    b.Property<string>("UUID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Device")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UUID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("PerMonServer.Models.Measure", b =>
                {
                    b.Property<string>("UUID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UUID");

                    b.ToTable("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}