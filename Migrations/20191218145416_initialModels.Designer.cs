﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TengaiAssignment.Database;

namespace TengaiAssignment.Migrations
{
    [DbContext(typeof(TengaiDbContext))]
    [Migration("20191218145416_initialModels")]
    partial class initialModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TengaiAssignment.Database.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company");

                    b.Property<string>("Location");

                    b.Property<string>("RoleDescription");

                    b.Property<string>("RoleTitle");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("TengaiAssignment.Database.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("TengaiAssignment.Database.CandidateAssignment", b =>
                {
                    b.Property<int>("CandidateId");

                    b.Property<int>("AssignmentId");

                    b.Property<double?>("Score");

                    b.HasKey("CandidateId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("CandidateAssignments");
                });

            modelBuilder.Entity("TengaiAssignment.Database.CandidateAssignment", b =>
                {
                    b.HasOne("TengaiAssignment.Database.Assignment")
                        .WithMany("Candidates")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TengaiAssignment.Database.Candidate")
                        .WithMany("Assignments")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
