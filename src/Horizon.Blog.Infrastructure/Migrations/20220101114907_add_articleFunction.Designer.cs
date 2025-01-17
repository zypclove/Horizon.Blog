﻿// <auto-generated />
using System;
using Horizon.Blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Horizon.Blog.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20220101114907_add_articleFunction")]
    partial class add_articleFunction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleAggreate.Article", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<int>("SortNum")
                        .HasColumnType("integer")
                        .HasColumnName("sort_num");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<bool>("Toped")
                        .HasColumnType("boolean")
                        .HasColumnName("toped");

                    b.HasKey("Id");

                    b.ToTable("article");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.ArticleFunction", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("ArticleId")
                        .HasColumnType("text")
                        .HasColumnName("article_id");

                    b.HasKey("Id");

                    b.ToTable("article_function");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("article_function_id")
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("article_function_id");

                    b.ToTable("review");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.Star", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("ArticleFunctionId")
                        .HasColumnType("character varying(36)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleFunctionId");

                    b.ToTable("star");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleAggreate.Article", b =>
                {
                    b.OwnsOne("Horizon.Blog.Domain.Common.AdminCreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("ArticleId")
                                .HasColumnType("character varying(36)");

                            b1.Property<DateTime>("CreationTime")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("creation_time");

                            b1.Property<string>("CreatorId")
                                .HasColumnType("text")
                                .HasColumnName("creator_id");

                            b1.HasKey("ArticleId");

                            b1.ToTable("article");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("Horizon.Blog.Domain.Common.AdminModificationInfo", "ModificationInfo", b1 =>
                        {
                            b1.Property<string>("ArticleId")
                                .HasColumnType("character varying(36)");

                            b1.Property<DateTime>("ModificationTime")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("modification_time");

                            b1.Property<string>("ModifierId")
                                .HasColumnType("text")
                                .HasColumnName("modifier_id");

                            b1.HasKey("ArticleId");

                            b1.ToTable("article");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.Navigation("CreationInfo");

                    b.Navigation("ModificationInfo");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.Review", b =>
                {
                    b.HasOne("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.ArticleFunction", null)
                        .WithMany("Reviews")
                        .HasForeignKey("article_function_id");

                    b.OwnsOne("Horizon.Blog.Domain.Common.UserCreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("ReviewId")
                                .HasColumnType("character varying(36)");

                            b1.Property<DateTime>("CreationTime")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("creation_time");

                            b1.Property<string>("CreatorId")
                                .HasColumnType("text")
                                .HasColumnName("creator_id");

                            b1.HasKey("ReviewId");

                            b1.ToTable("review");

                            b1.WithOwner()
                                .HasForeignKey("ReviewId");
                        });

                    b.Navigation("CreationInfo");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.Star", b =>
                {
                    b.HasOne("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.ArticleFunction", null)
                        .WithMany("Stars")
                        .HasForeignKey("ArticleFunctionId");

                    b.OwnsOne("Horizon.Blog.Domain.Common.UserCreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("StarId")
                                .HasColumnType("character varying(36)");

                            b1.Property<DateTime>("CreationTime")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("creation_time");

                            b1.Property<string>("CreatorId")
                                .HasColumnType("text")
                                .HasColumnName("creator_id");

                            b1.HasKey("StarId");

                            b1.ToTable("star");

                            b1.WithOwner()
                                .HasForeignKey("StarId");
                        });

                    b.Navigation("CreationInfo");
                });

            modelBuilder.Entity("Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate.ArticleFunction", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Stars");
                });
#pragma warning restore 612, 618
        }
    }
}
