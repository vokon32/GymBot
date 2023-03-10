// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webhooktestagain.Data;

namespace webhooktestagain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webhooktestagain.Models.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("chatId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webhooktestagain.Models.Exercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfApproaches")
                        .HasColumnType("int");

                    b.Property<int>("numberOfIterations")
                        .HasColumnType("int");

                    b.Property<long>("trainingId")
                        .HasColumnType("bigint");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("trainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("webhooktestagain.Models.Training", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfTheTraining")
                        .HasColumnType("datetime2");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("webhooktestagain.Models.Exercise", b =>
                {
                    b.HasOne("webhooktestagain.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("webhooktestagain.Models.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("webhooktestagain.Models.Training", b =>
                {
                    b.HasOne("webhooktestagain.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("webhooktestagain.Models.Training", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
