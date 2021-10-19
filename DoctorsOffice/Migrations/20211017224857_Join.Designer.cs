﻿// <auto-generated />
using DoctorsOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorsOffice.Migrations
{
    [DbContext(typeof(DoctorsOfficeContext))]
    [Migration("20211017224857_Join")]
    partial class Join
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Specialty")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorPatientId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorSpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("DoctorSpecialtyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Birthday")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("DoctorsOffice.Models.SpecialtyPatient", b =>
                {
                    b.Property<int>("SpecialtyPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("SpecialtyPatientId");

                    b.HasIndex("PatientId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("SpecialtyPatient");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorPatient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Patient", "Patient")
                        .WithMany("JoinEntities")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Specialty", "Specialty")
                        .WithMany("JoinEntities3")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("DoctorsOffice.Models.SpecialtyPatient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Specialty", "Specialty")
                        .WithMany("JoinEntities2")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Specialty", b =>
                {
                    b.Navigation("JoinEntities2");

                    b.Navigation("JoinEntities3");
                });
#pragma warning restore 612, 618
        }
    }
}
