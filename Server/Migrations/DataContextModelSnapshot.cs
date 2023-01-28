﻿// <auto-generated />
using System;
using EventsApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventsApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventsApp.Shared.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Kraków",
                            Street = "Plac wolnica 10"
                        },
                        new
                        {
                            Id = 2,
                            City = "Poznań",
                            Street = "Niepodległości 36"
                        },
                        new
                        {
                            Id = 3,
                            City = "Kraków",
                            Street = "Mostowa 2"
                        });
                });

            modelBuilder.Entity("EventsApp.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dubstep",
                            Url = "dubstep"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drum and bass",
                            Url = "drum-and-bass"
                        });
                });

            modelBuilder.Entity("EventsApp.Shared.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CategoryId = 1,
                            Date = new DateTime(2023, 2, 17, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "Duet didżejski FATHERTZ po raz drugi wjeżdza do naszej piwnicy! 😎 Misje mają jedną - zadbać o najniższe częstotliwości i wymassssowac Wam uszy porządnym basssem!",
                            ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/325594825_1452561625273197_3749631723571176120_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=RPCrtPASyDIAX9MB_xX&_nc_ht=scontent-waw1-1.xx&oh=00_AfAJiX5QePPXw7IBI7rUL9YOnu4h3EnLJ1ahB3DZ1cVBNA&oe=63D7FFC4",
                            Price = 7.99m,
                            Title = "BASSTARDS 2.0: MATT GREEN / FATHERTZ"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            CategoryId = 1,
                            Date = new DateTime(2023, 2, 24, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "Digital Organism to cykl imprez, na których nie będziemy się z Wami pieścić. Nie obiecujemy cukierkowego klimatu. Nie zobaczycie męczących stroboli w klubie. Tylko kawał dobrej roboty muzyków oraz dekoratorów",
                            ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/315829423_1529741864136995_8866568946256025211_n.jpg?stp=dst-jpg_p180x540&_nc_cat=105&ccb=1-7&_nc_sid=340051&_nc_ohc=WJBxHfhRbiAAX-zVYOa&_nc_ht=scontent-waw1-1.xx&oh=00_AfB2F_YjMScJ7J0hhZjb1AgUxQbYR5YMOwJ4FDFwCd5TJg&oe=63D7EE83",
                            Price = 8.99m,
                            Title = "Digital Organism VI: Unkey & MC Toast // Powered By Ashwagundub Soundsystem // 3 Urodziny"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            CategoryId = 2,
                            Date = new DateTime(2023, 2, 25, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            Description = "Siemanko dramendbejsowe świry! Tak jak obiecaliśmy - wracamy z drugą edycją bejsufki już 25 lutego w Klubie Baza! 🚀",
                            ImageUrl = "https://scontent-waw1-1.xx.fbcdn.net/v/t39.30808-6/326033232_2387371144758789_8496355661206030946_n.jpg?stp=dst-jpg_s960x960&_nc_cat=108&ccb=1-7&_nc_sid=340051&_nc_ohc=WEKz1t0EdTQAX8zFbCQ&_nc_ht=scontent-waw1-1.xx&oh=00_AfCWRLHboZu7k0P7sR3iMwzXokrrJfYoQJibNDnFpdRNtQ&oe=63D6DFAD",
                            Price = 9.99m,
                            Title = "Bejsufka #2 | DNB | Klub Baza"
                        });
                });

            modelBuilder.Entity("EventsApp.Shared.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EventsApp.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventsApp.Shared.Event", b =>
                {
                    b.HasOne("EventsApp.Shared.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsApp.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EventsApp.Shared.Image", b =>
                {
                    b.HasOne("EventsApp.Shared.Event", null)
                        .WithMany("Images")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("EventsApp.Shared.Event", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
