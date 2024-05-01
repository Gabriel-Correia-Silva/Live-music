﻿// <auto-generated />
using Back_end.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Back_end.Migrations
{
    [DbContext(typeof(LiveMusicDbContext))]
    [Migration("20240429170424_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Back_end.Models.GroupModel", b =>
                {
                    b.Property<int>("IdGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdGroup"));

                    b.Property<int>("AdminGroupIdUser")
                        .HasColumnType("integer");

                    b.Property<int>("IdUsersIdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NameGroup")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlaylistIdPlaylist")
                        .HasColumnType("integer");

                    b.HasKey("IdGroup");

                    b.HasIndex("AdminGroupIdUser");

                    b.HasIndex("IdUsersIdUser");

                    b.HasIndex("PlaylistIdPlaylist");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Back_end.Models.MusicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("MusicData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("Back_end.Models.PlaylistModel", b =>
                {
                    b.Property<int>("IdPlaylist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPlaylist"));

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<int>("MusicId")
                        .HasColumnType("integer");

                    b.Property<string>("NamePlaylist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPlaylist");

                    b.HasIndex("MusicId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Back_end.Models.UserModel", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Back_end.Models.GroupModel", b =>
                {
                    b.HasOne("Back_end.Models.UserModel", "AdminGroup")
                        .WithMany()
                        .HasForeignKey("AdminGroupIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_end.Models.UserModel", "IdUsers")
                        .WithMany()
                        .HasForeignKey("IdUsersIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_end.Models.PlaylistModel", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistIdPlaylist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminGroup");

                    b.Navigation("IdUsers");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("Back_end.Models.PlaylistModel", b =>
                {
                    b.HasOne("Back_end.Models.MusicModel", "Music")
                        .WithMany()
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");
                });
#pragma warning restore 612, 618
        }
    }
}
