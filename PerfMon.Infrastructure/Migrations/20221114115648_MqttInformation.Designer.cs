﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfMon.Infrastructure;

#nullable disable

namespace PerfMon.Infrastructure.Migrations
{
    [DbContext(typeof(PerfMonDbContext))]
    [Migration("20221114115648_MqttInformation")]
    partial class MqttInformation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PerfMon.Business.Models.Agent.Agent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Inactive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("PerfMon.Business.Models.Agent.Measure", b =>
                {
                    b.Property<string>("UniqueName")
                        .HasColumnType("TEXT");

                    b.Property<string>("AgentName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FirstValueTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastValueTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("MeasureType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UniqueName", "AgentName");

                    b.HasIndex("AgentName");

                    b.ToTable("Measure");
                });

            modelBuilder.Entity("PerfMon.Business.Models.Sample.Sample", b =>
                {
                    b.Property<string>("AgentName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MeasureName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("AgentName", "MeasureName", "Timestamp");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("PerfMon.Business.Models.Agent.Agent", b =>
                {
                    b.OwnsOne("PerfMon.Business.Models.Agent.MqttChannel", "Mqtt", b1 =>
                        {
                            b1.Property<string>("AgentName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Channel")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("AgentName");

                            b1.ToTable("Agents");

                            b1.WithOwner()
                                .HasForeignKey("AgentName");
                        });

                    b.Navigation("Mqtt");
                });

            modelBuilder.Entity("PerfMon.Business.Models.Agent.Measure", b =>
                {
                    b.HasOne("PerfMon.Business.Models.Agent.Agent", null)
                        .WithMany("Measures")
                        .HasForeignKey("AgentName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerfMon.Business.Models.Sample.Sample", b =>
                {
                    b.HasOne("PerfMon.Business.Models.Agent.Measure", null)
                        .WithMany()
                        .HasForeignKey("AgentName", "MeasureName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerfMon.Business.Models.Agent.Agent", b =>
                {
                    b.Navigation("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}