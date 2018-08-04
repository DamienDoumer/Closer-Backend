﻿// <auto-generated />
using System;
using Closer.DataService.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Closer.Migrations
{
    [DbContext(typeof(CloserContext))]
    [Migration("20180804113350_CloserFinalMigration")]
    partial class CloserFinalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Closer.Entities.Discussion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Moniker");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("Closer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Moniker");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Closer.Entities.UserDiscussions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("DiscussionId");

                    b.Property<string>("Moniker");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiscussions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserDiscussions");
                });

            modelBuilder.Entity("Closer.Entities.Message", b =>
                {
                    b.HasBaseType("Closer.Entities.UserDiscussions");

                    b.Property<string>("InRespondToMessageID");

                    b.Property<string>("Text");
                    b.Property<int>("UserId");
                    b.Property<int>("DiscussionId");

                    b.ToTable("Message");
                    b.HasIndex("DiscussionId");
                    b.HasIndex("UserId");
                    b.HasDiscriminator().HasValue("Message");
                });

            modelBuilder.Entity("Closer.Entities.UserDiscussions", b =>
                {
                    b.HasOne("Closer.Entities.Discussion", "Discussion")
                        .WithMany()
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Closer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}