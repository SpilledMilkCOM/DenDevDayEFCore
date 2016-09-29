using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SM.DataModels.Stuff;

namespace SM.DataModels.Stuff.Web.Migrations
{
    [DbContext(typeof(StuffDbContext))]
    [Migration("20160929211902_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SM.DataModels.Stuff.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonId");

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SM.DataModels.Stuff.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StatusId");

                    b.Property<DateTime?>("DateApproved");

                    b.Property<DateTime?>("DateCheckedIn");

                    b.Property<DateTime?>("DateCheckedOut");

                    b.Property<DateTime?>("DateRequested");

                    b.Property<int?>("RequestorId");

                    b.Property<int?>("StuffId");

                    b.HasKey("Id");

                    b.HasIndex("RequestorId");

                    b.HasIndex("StuffId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("SM.DataModels.Stuff.Entities.Stuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StuffId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int?>("OwnerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Stuff");
                });

            modelBuilder.Entity("SM.DataModels.Stuff.Entities.Status", b =>
                {
                    b.HasOne("SM.DataModels.Stuff.Entities.Person", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.HasOne("SM.DataModels.Stuff.Entities.Stuff", "Stuff")
                        .WithMany()
                        .HasForeignKey("StuffId");
                });

            modelBuilder.Entity("SM.DataModels.Stuff.Entities.Stuff", b =>
                {
                    b.HasOne("SM.DataModels.Stuff.Entities.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
