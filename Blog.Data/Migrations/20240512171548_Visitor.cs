using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class Visitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("778d4f1b-6322-4c1d-bd87-5eef75028b87"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8e9a4152-4eaa-4084-b9d8-4d8e2dfccd16"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "ModifiendBy", "Title", "UserId", "VievCount" },
                values: new object[,]
                {
                    { new Guid("4e666237-4973-4853-ae86-2f586747b477"), new Guid("43b000d9-cc6a-47d7-bc38-4c226e4c4332"), " Asp.net Core Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", "Admin Test", new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(4660), null, null, new Guid("c14e7c98-c5ce-4682-b69b-31d386fffdea"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("57d7add5-f617-43b9-95d6-d48abd90af06"), 15 },
                    { new Guid("d2159300-87e0-4462-b4c3-d21b2e0ed94c"), new Guid("eb22aa4b-ce51-424b-bc1f-e02c7838d2e3"), " Visual Studio Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", "Admin Test", new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(4667), null, null, new Guid("a96a68d1-288a-4c5d-b66c-c58db5ef8f90"), false, null, null, "Visual Studio  Deneme Makalesi 1", new Guid("50bc0a8f-2f1e-4e21-b191-39e083bdfcd8"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fd4922e-c8e2-4397-b7f8-add5d2879121"),
                column: "ConcurrencyStamp",
                value: "86067540-cabf-4359-a6f9-4994d99a4e75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0fc8f48-3508-4843-bdc4-fb60b72be20e"),
                column: "ConcurrencyStamp",
                value: "99f07fd8-e9f4-4f88-ad3d-1e930a20a6e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed992d7d-d22c-498d-9407-e8d9f5094c34"),
                column: "ConcurrencyStamp",
                value: "80047bef-dd32-4602-aa32-f0579cee543a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50bc0a8f-2f1e-4e21-b191-39e083bdfcd8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9bc6755-0645-473b-8c7b-3bdb3703baea", "AQAAAAEAACcQAAAAEKuFK3DsZuH/uP+97cQT76tPNRZNiJzQtI2/zSUAl/HdWDwW1ypeKzyJBvSQiuxTWA==", "826ed79c-4a51-4391-82ad-6c836389f78a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57d7add5-f617-43b9-95d6-d48abd90af06"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "315bf0cf-c2c7-43dc-9fd1-c1dc2d7429d2", "AQAAAAEAACcQAAAAEDq95kj/ocdvGxIKB72JFdlJ4JeiXZcKe45HZ8RGpK+mFMQ0+5E+m5NsNkOkcMa64A==", "335c920a-69a8-4219-a041-ca8e2f94ba9e" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43b000d9-cc6a-47d7-bc38-4c226e4c4332"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb22aa4b-ce51-424b-bc1f-e02c7838d2e3"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a96a68d1-288a-4c5d-b66c-c58db5ef8f90"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c14e7c98-c5ce-4682-b69b-31d386fffdea"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 20, 15, 47, 917, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4e666237-4973-4853-ae86-2f586747b477"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d2159300-87e0-4462-b4c3-d21b2e0ed94c"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "ModifiendBy", "Title", "UserId", "VievCount" },
                values: new object[,]
                {
                    { new Guid("778d4f1b-6322-4c1d-bd87-5eef75028b87"), new Guid("eb22aa4b-ce51-424b-bc1f-e02c7838d2e3"), " Visual Studio Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", "Admin Test", new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3143), null, null, new Guid("a96a68d1-288a-4c5d-b66c-c58db5ef8f90"), false, null, null, "Visual Studio  Deneme Makalesi 1", new Guid("50bc0a8f-2f1e-4e21-b191-39e083bdfcd8"), 15 },
                    { new Guid("8e9a4152-4eaa-4084-b9d8-4d8e2dfccd16"), new Guid("43b000d9-cc6a-47d7-bc38-4c226e4c4332"), " Asp.net Core Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", "Admin Test", new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3135), null, null, new Guid("c14e7c98-c5ce-4682-b69b-31d386fffdea"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("57d7add5-f617-43b9-95d6-d48abd90af06"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fd4922e-c8e2-4397-b7f8-add5d2879121"),
                column: "ConcurrencyStamp",
                value: "61528079-0410-4a08-9a28-1a52fa260d55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0fc8f48-3508-4843-bdc4-fb60b72be20e"),
                column: "ConcurrencyStamp",
                value: "7a01cc3f-021f-4352-90b6-ae5014632bae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed992d7d-d22c-498d-9407-e8d9f5094c34"),
                column: "ConcurrencyStamp",
                value: "9a4e298a-79b2-43e2-a117-ce31590a5929");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("50bc0a8f-2f1e-4e21-b191-39e083bdfcd8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cba6386-1601-4611-b318-2438494f8b22", "AQAAAAEAACcQAAAAENXTqj7h2HqE6DFMDqDN/QiSDJ6SwBQhznkruPzb2Y4n4YAg79KYKIQCZTT6ji+Rig==", "d0801642-99cc-4666-911c-d52c3c0f0ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57d7add5-f617-43b9-95d6-d48abd90af06"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14b0c18a-c7bc-43eb-8504-84d28efc00d6", "AQAAAAEAACcQAAAAEFfjoQ0H/WMNU0GvlUBeESl9Hm4vKk99/he7s2uJbZsFBbHaQVB1Y5OTfSQiEH9bnA==", "7dc9eb13-db2b-42fd-88af-a52f7caa025d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43b000d9-cc6a-47d7-bc38-4c226e4c4332"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb22aa4b-ce51-424b-bc1f-e02c7838d2e3"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a96a68d1-288a-4c5d-b66c-c58db5ef8f90"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c14e7c98-c5ce-4682-b69b-31d386fffdea"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 16, 14, 28, 332, DateTimeKind.Local).AddTicks(3459));
        }
    }
}
