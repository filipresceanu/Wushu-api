﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wushu_api.Data;

#nullable disable

namespace Wushu_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230813103252_RemoveReferee")]
    partial class RemoveReferee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wushu_api.Models.AgeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GraterThanAge")
                        .HasColumnType("int");

                    b.Property<int>("LessThanAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeCategories");
                });

            modelBuilder.Entity("Wushu_api.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgeCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GraterThanWeight")
                        .HasColumnType("int");

                    b.Property<int>("LessThanWeight")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgeCategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Wushu_api.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Wushu_api.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompetitorFirstId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompetitorSecondId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParticipantWinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompetitorFirstId");

                    b.HasIndex("CompetitorSecondId");

                    b.HasIndex("ParticipantWinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Wushu_api.Models.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryWeight")
                        .HasColumnType("int");

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Wushu_api.Models.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PointParticipantFirst")
                        .HasColumnType("int");

                    b.Property<int>("PointParticipantSecond")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Wushu_api.Models.Category", b =>
                {
                    b.HasOne("Wushu_api.Models.AgeCategory", "AgeCategory")
                        .WithMany("Categories")
                        .HasForeignKey("AgeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wushu_api.Models.Event", "Event")
                        .WithMany("Categories")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeCategory");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Wushu_api.Models.Match", b =>
                {
                    b.HasOne("Wushu_api.Models.Participant", "CompetitorFirst")
                        .WithMany("MatchesAsFirstCompetitor")
                        .HasForeignKey("CompetitorFirstId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wushu_api.Models.Participant", "CompetitorSecond")
                        .WithMany("MatchesAsSecondCompetitor")
                        .HasForeignKey("CompetitorSecondId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Wushu_api.Models.Participant", "ParticipantWinner")
                        .WithMany("MatchesAsWinner")
                        .HasForeignKey("ParticipantWinnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CompetitorFirst");

                    b.Navigation("CompetitorSecond");

                    b.Navigation("ParticipantWinner");
                });

            modelBuilder.Entity("Wushu_api.Models.Participant", b =>
                {
                    b.HasOne("Wushu_api.Models.Category", "Category")
                        .WithMany("Participants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Wushu_api.Models.Round", b =>
                {
                    b.HasOne("Wushu_api.Models.Match", "Match")
                        .WithMany("Rounds")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Wushu_api.Models.AgeCategory", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Wushu_api.Models.Category", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Wushu_api.Models.Event", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Wushu_api.Models.Match", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("Wushu_api.Models.Participant", b =>
                {
                    b.Navigation("MatchesAsFirstCompetitor");

                    b.Navigation("MatchesAsSecondCompetitor");

                    b.Navigation("MatchesAsWinner");
                });
#pragma warning restore 612, 618
        }
    }
}
