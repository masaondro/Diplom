using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.Migrations.Migrations
{
    public partial class Initial_Create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Mission_MissionId",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MissionId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Mission_MissionId",
                table: "Comment",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Mission_MissionId",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MissionId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Mission_MissionId",
                table: "Comment",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
