﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoryGPTEntityAPI.Db;

#nullable disable

namespace StoryGPTEntityAPI.Migrations
{
    [DbContext(typeof(StoryGPTDbContext))]
    [Migration("20230827073537_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("StoryGPTEntityAPI.Models.MetaData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("StoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StoryId")
                        .IsUnique();

                    b.ToTable("MetaData");
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.Story", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("GeneratedId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoryText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MetaDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MetaDataId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.MetaData", b =>
                {
                    b.HasOne("StoryGPTEntityAPI.Models.Story", null)
                        .WithOne("MetaData")
                        .HasForeignKey("StoryGPTEntityAPI.Models.MetaData", "StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.Tag", b =>
                {
                    b.HasOne("StoryGPTEntityAPI.Models.MetaData", null)
                        .WithMany("Tags")
                        .HasForeignKey("MetaDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.MetaData", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("StoryGPTEntityAPI.Models.Story", b =>
                {
                    b.Navigation("MetaData")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
