﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241208160015_AddRunTimeToMetadata")]
    partial class AddRunTimeToMetadata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateWatched")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsWatched")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("API.Entities.MovieMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Actors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Awards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ratings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("API.Entities.MovieMetadata", b =>
                {
                    b.HasOne("API.Entities.Movie", "Movie")
                        .WithOne("Metadata")
                        .HasForeignKey("API.Entities.MovieMetadata", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("API.Entities.Movie", b =>
                {
                    b.Navigation("Metadata");
                });
#pragma warning restore 612, 618
        }
    }
}
