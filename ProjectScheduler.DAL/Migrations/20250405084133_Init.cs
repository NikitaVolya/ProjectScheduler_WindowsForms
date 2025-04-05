using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectScheduler.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchedulerProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchedulerCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorRed = table.Column<int>(type: "int", nullable: false),
                    ColorGreen = table.Column<int>(type: "int", nullable: false),
                    ColorBlue = table.Column<int>(type: "int", nullable: false),
                    SchedulerProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulerCategories_SchedulerProjects_SchedulerProjectId",
                        column: x => x.SchedulerProjectId,
                        principalTable: "SchedulerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulerMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulerProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulerMembers_SchedulerProjects_SchedulerProjectId",
                        column: x => x.SchedulerProjectId,
                        principalTable: "SchedulerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulerTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_SchedulerCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SchedulerCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_SchedulerMembers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SchedulerMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchedulerTasks_SchedulerProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "SchedulerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerCategories_SchedulerProjectId",
                table: "SchedulerCategories",
                column: "SchedulerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerMembers_SchedulerProjectId",
                table: "SchedulerMembers",
                column: "SchedulerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_CategoryId",
                table: "SchedulerTasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_OwnerId",
                table: "SchedulerTasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerTasks_ProjectId",
                table: "SchedulerTasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulerTasks");

            migrationBuilder.DropTable(
                name: "SchedulerCategories");

            migrationBuilder.DropTable(
                name: "SchedulerMembers");

            migrationBuilder.DropTable(
                name: "SchedulerProjects");
        }
    }
}
