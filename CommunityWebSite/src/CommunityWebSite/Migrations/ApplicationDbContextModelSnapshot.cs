﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CommunityWebSite.Models;

namespace CommunityWebSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunityWebSite.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SenderMemberID");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("MessageID");

                    b.HasIndex("SenderMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Reply", b =>
                {
                    b.Property<int>("ReplyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("MessageID");

                    b.Property<int?>("ReplyCreatorUserID");

                    b.HasKey("ReplyID");

                    b.HasIndex("MessageID");

                    b.HasIndex("ReplyCreatorUserID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("CommunityWebSite.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Id");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Message", b =>
                {
                    b.HasOne("CommunityWebSite.Models.Member", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderMemberID");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Reply", b =>
                {
                    b.HasOne("CommunityWebSite.Models.Message")
                        .WithMany("MessageReplies")
                        .HasForeignKey("MessageID");

                    b.HasOne("CommunityWebSite.Models.User", "ReplyCreator")
                        .WithMany()
                        .HasForeignKey("ReplyCreatorUserID");
                });
        }
    }
}
