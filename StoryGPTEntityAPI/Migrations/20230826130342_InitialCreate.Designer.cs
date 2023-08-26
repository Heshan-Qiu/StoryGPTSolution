﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoriesGPTEntities.Data;

#nullable disable

namespace StoryGPTEntityAPI.Migrations
{
    [DbContext(typeof(StoriesGPTContext))]
    [Migration("20230826130342_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("StoriesGPTEntities.Models.MetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneratedId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StoryId")
                        .IsUnique();

                    b.ToTable("MetaData");
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratedId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoryText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StoryTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratedId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MetaDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MetaDataId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.MetaData", b =>
                {
                    b.HasOne("StoriesGPTEntities.Models.Story", null)
                        .WithOne("MetaData")
                        .HasForeignKey("StoriesGPTEntities.Models.MetaData", "StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.Tag", b =>
                {
                    b.HasOne("StoriesGPTEntities.Models.MetaData", "MetaData")
                        .WithMany("Tags")
                        .HasForeignKey("MetaDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MetaData");
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.MetaData", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("StoriesGPTEntities.Models.Story", b =>
                {
                    b.Navigation("MetaData")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
