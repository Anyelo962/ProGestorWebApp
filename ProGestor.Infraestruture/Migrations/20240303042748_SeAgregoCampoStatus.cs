using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGestor.Infraestruture.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregoCampoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySchedule_Projects_ProjectId",
                table: "ActivitySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Projects_ProjectId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAdvance_Projects_ProjectId",
                table: "PaymentAdvance");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTracking_Projects_ProjectId",
                table: "ProjectTracking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTracking",
                table: "ProjectTracking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentAdvance",
                table: "PaymentAdvance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySchedule",
                table: "ActivitySchedule");

            migrationBuilder.RenameTable(
                name: "ProjectTracking",
                newName: "ProjectTrackings");

            migrationBuilder.RenameTable(
                name: "PaymentAdvance",
                newName: "PaymentAdvances");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "ActivitySchedule",
                newName: "ActivitySchedules");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTracking_ProjectId",
                table: "ProjectTrackings",
                newName: "IX_ProjectTrackings_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAdvance_ProjectId",
                table: "PaymentAdvances",
                newName: "IX_PaymentAdvances_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ProjectId",
                table: "Invoices",
                newName: "IX_Invoices_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivitySchedule_ProjectId",
                table: "ActivitySchedules",
                newName: "IX_ActivitySchedules_ProjectId");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "StatusProjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProjectTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "CivilEngineeringDesigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProjectTrackings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PaymentAdvances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ActivitySchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTrackings",
                table: "ProjectTrackings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentAdvances",
                table: "PaymentAdvances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySchedules",
                table: "ActivitySchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Projectquotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    MaterialEstimation = table.Column<double>(type: "float", nullable: false),
                    LaborEstimation = table.Column<double>(type: "float", nullable: false),
                    OtherExpenses = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectquotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projectquotes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projectquotes_ProjectId",
                table: "Projectquotes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySchedules_Projects_ProjectId",
                table: "ActivitySchedules",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAdvances_Projects_ProjectId",
                table: "PaymentAdvances",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTrackings_Projects_ProjectId",
                table: "ProjectTrackings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySchedules_Projects_ProjectId",
                table: "ActivitySchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAdvances_Projects_ProjectId",
                table: "PaymentAdvances");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTrackings_Projects_ProjectId",
                table: "ProjectTrackings");

            migrationBuilder.DropTable(
                name: "Projectquotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTrackings",
                table: "ProjectTrackings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentAdvances",
                table: "PaymentAdvances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitySchedules",
                table: "ActivitySchedules");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StatusProjects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CivilEngineeringDesigns");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectTrackings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentAdvances");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ActivitySchedules");

            migrationBuilder.RenameTable(
                name: "ProjectTrackings",
                newName: "ProjectTracking");

            migrationBuilder.RenameTable(
                name: "PaymentAdvances",
                newName: "PaymentAdvance");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "ActivitySchedules",
                newName: "ActivitySchedule");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTrackings_ProjectId",
                table: "ProjectTracking",
                newName: "IX_ProjectTracking_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAdvances_ProjectId",
                table: "PaymentAdvance",
                newName: "IX_PaymentAdvance_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoice",
                newName: "IX_Invoice_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivitySchedules_ProjectId",
                table: "ActivitySchedule",
                newName: "IX_ActivitySchedule_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTracking",
                table: "ProjectTracking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentAdvance",
                table: "PaymentAdvance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitySchedule",
                table: "ActivitySchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySchedule_Projects_ProjectId",
                table: "ActivitySchedule",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Projects_ProjectId",
                table: "Invoice",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAdvance_Projects_ProjectId",
                table: "PaymentAdvance",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTracking_Projects_ProjectId",
                table: "ProjectTracking",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
