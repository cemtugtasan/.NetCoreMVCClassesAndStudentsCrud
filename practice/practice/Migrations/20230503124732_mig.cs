using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practice.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "ClassName", "StudentID" },
                values: new object[] { 1, "Math", 0 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "ClassName", "StudentID" },
                values: new object[] { 2, "Science", 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "ClassID", "StudentAddress", "StudentName", "StudentSurname" },
                values: new object[,]
                {
                    { 1, 1, "Eskişehir", "Cemtuğ Kaan", "Taşan" },
                    { 2, 1, "My Heart", "Burcu", "Taşan" },
                    { 3, 2, "Siirt", "Hakan", "Balamir" },
                    { 4, 2, "İstanbul", "Uğur", "Demir" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                column: "ClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
