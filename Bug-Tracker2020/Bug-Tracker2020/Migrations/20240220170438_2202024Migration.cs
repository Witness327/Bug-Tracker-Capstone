using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bug_Tracker2020.Migrations
{
    /// <inheritdoc />
    public partial class _2202024Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Bugs_BugID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "BugID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminFirstName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminFirstName",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EditCommentViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    AdminFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BugID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditCommentViewModel", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Bugs_BugID",
                table: "Comments",
                column: "BugID",
                principalTable: "Bugs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Bugs_BugID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "EditCommentViewModel");

            migrationBuilder.DropColumn(
                name: "AdminFirstName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AdminFirstName",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Bugs");

            migrationBuilder.AlterColumn<int>(
                name: "BugID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Bugs_BugID",
                table: "Comments",
                column: "BugID",
                principalTable: "Bugs",
                principalColumn: "ID");
        }
    }
}
