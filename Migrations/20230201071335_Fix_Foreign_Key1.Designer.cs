// <auto-generated />
using Asp.net_core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asp.netcore.Migrations
{
    [DbContext(typeof(TestDbcontext))]
    [Migration("20230201071335_Fix_Foreign_Key1")]
    partial class FixForeignKey1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Asp.net_core.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("Asp.net_core.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Owner", (string)null);
                });

            modelBuilder.Entity("Asp.net_core.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCar")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("VendorId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("Asp.net_core.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bithdate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Vendor", (string)null);
                });

            modelBuilder.Entity("Asp.net_core.Models.Receipt", b =>
                {
                    b.HasOne("Asp.net_core.Models.Car", "Car")
                        .WithOne("Receipt")
                        .HasForeignKey("Asp.net_core.Models.Receipt", "IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.net_core.Models.Owner", "Owner")
                        .WithMany("Receipts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.net_core.Models.Vendor", "Vendor")
                        .WithMany("Receipts")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Owner");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Asp.net_core.Models.Car", b =>
                {
                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("Asp.net_core.Models.Owner", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("Asp.net_core.Models.Vendor", b =>
                {
                    b.Navigation("Receipts");
                });
#pragma warning restore 612, 618
        }
    }
}
