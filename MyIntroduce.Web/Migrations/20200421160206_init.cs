using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIntroduce.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    Motto = table.Column<string>(maxLength: 100, nullable: true),
                    CnblogsUrl = table.Column<string>(maxLength: 100, nullable: true),
                    GithubUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    WebTitle = table.Column<string>(maxLength: 100, nullable: true),
                    QQ = table.Column<string>(maxLength: 100, nullable: true),
                    Wchar = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoUrl = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "introduces",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_introduces", x => new { x.UserID, x.Content });
                    table.ForeignKey(
                        name: "FK_introduces_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_projects_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => new { x.UserID, x.Content });
                    table.ForeignKey(
                        name: "FK_skills_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "summarys",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_summarys", x => new { x.UserID, x.Content });
                    table.ForeignKey(
                        name: "FK_summarys_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectdetails",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectdetails", x => new { x.ProjectID, x.Content });
                    table.ForeignKey(
                        name: "FK_projectdetails_projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_UserID",
                table: "projects",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "introduces");

            migrationBuilder.DropTable(
                name: "projectdetails");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "summarys");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
