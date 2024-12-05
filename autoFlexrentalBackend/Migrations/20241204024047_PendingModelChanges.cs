using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace autoFlexrentalBackend.Migrations
{
    /// <inheritdoc />
    public partial class PendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ActivityL__UserI__3B75D760",
                table: "ActivityLog");

            migrationBuilder.DropForeignKey(
                name: "FK__Reservati__UserI__2D27B809",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK__Reservati__Vehic__2E1BDC42",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Vehicles__476B54B25842152D",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IDX_Vehicles_Availability",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__1788CCAC8F7E4E00",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__A9D10534C03932E1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reservat__B7EE5F04D280AA02",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IDX_Reservations_Status",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__20CF2E32F91D98AA",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ContactM__C87C037CDEA3A700",
                table: "ContactMessages");

            migrationBuilder.DropIndex(
                name: "IDX_ContactMessages_Status",
                table: "ContactMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Activity__5E5499A84A78BF48",
                table: "ActivityLog");

            migrationBuilder.RenameTable(
                name: "ActivityLog",
                newName: "ActivityLogs");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Vehicles",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Reservations",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_VehicleID",
                table: "Reservations",
                newName: "IX_Reservations_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.RenameColumn(
                name: "NotificationID",
                table: "Notifications",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "ContactMessages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "LogID",
                table: "ActivityLogs",
                newName: "LogId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLog_UserID",
                table: "ActivityLogs",
                newName: "IX_ActivityLogs_UserID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WhyChooseUsItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WhyChooseUsItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DailyPrice",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Vehicles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Pending");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Unread");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactMessages",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "NotificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMessages",
                table: "ContactMessages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityLogs",
                table: "ActivityLogs",
                column: "LogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_User",
                table: "ActivityLogs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Vehicles_VehicleId",
                table: "Reservations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_User",
                table: "ActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Vehicles_VehicleId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMessages",
                table: "ContactMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityLogs",
                table: "ActivityLogs");

            migrationBuilder.RenameTable(
                name: "ActivityLogs",
                newName: "ActivityLog");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Vehicles",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Reservations",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservations",
                newName: "IX_Reservations_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserID");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "NotificationID");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "ContactMessages",
                newName: "MessageID");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "ActivityLog",
                newName: "LogID");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLogs_UserID",
                table: "ActivityLog",
                newName: "IX_ActivityLog_UserID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WhyChooseUsItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WhyChooseUsItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DailyPrice",
                table: "Vehicles",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vehicles",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Vehicles",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ContactMessages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Unread",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactMessages",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ContactMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactMessages",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Vehicles__476B54B25842152D",
                table: "Vehicles",
                column: "VehicleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__1788CCAC8F7E4E00",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reservat__B7EE5F04D280AA02",
                table: "Reservations",
                column: "ReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__20CF2E32F91D98AA",
                table: "Notifications",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ContactM__C87C037CDEA3A700",
                table: "ContactMessages",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Activity__5E5499A84A78BF48",
                table: "ActivityLog",
                column: "LogID");

            migrationBuilder.CreateIndex(
                name: "IDX_Vehicles_Availability",
                table: "Vehicles",
                column: "Availability");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534C03932E1",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_Reservations_Status",
                table: "Reservations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IDX_ContactMessages_Status",
                table: "ContactMessages",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK__ActivityL__UserI__3B75D760",
                table: "ActivityLog",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Reservati__UserI__2D27B809",
                table: "Reservations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Reservati__Vehic__2E1BDC42",
                table: "Reservations",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
