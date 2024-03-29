﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using media.hub.data;

#nullable disable

namespace media.hub.Migrations
{
    [DbContext(typeof(MediaContext))]
    partial class MediaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("media.hub.entities.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("media.hub.entities.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasMaxLength(5242880)
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("media.hub.entities.Media", b =>
                {
                    b.HasOne("media.hub.entities.Ad", null)
                        .WithMany("Medias")
                        .HasForeignKey("AdId");
                });

            modelBuilder.Entity("media.hub.entities.Ad", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
