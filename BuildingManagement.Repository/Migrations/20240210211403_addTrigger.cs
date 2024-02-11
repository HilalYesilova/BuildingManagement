using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE TRIGGER trg_InsertApartmentBill
        ON [BUILDINGMANAGEMENT].[dbo].[Bills]
        AFTER INSERT
        AS
        BEGIN
            SET NOCOUNT ON;

            DECLARE @InsertedId INT;
            DECLARE @BuildingId INT;
            DECLARE @BillMonth DATE;
            DECLARE @ElectricityAmount DECIMAL(18, 2);
            DECLARE @WaterAmount DECIMAL(18, 2);
            DECLARE @GasAmount DECIMAL(18, 2);

            SELECT 
                @InsertedId = Id,
                @BuildingId = BuildingId,
                @BillMonth = [Month],
                @ElectricityAmount = ElectricityAmount,
                @WaterAmount = WaterAmount,
                @GasAmount = GasAmount
            FROM inserted;

            DECLARE @OccupiedApartmentCount INT;
            SELECT @OccupiedApartmentCount = COUNT(*)
            FROM Apartment
            WHERE OccupancyStatus = 1;

            IF @OccupiedApartmentCount > 0
            BEGIN
                DECLARE @ElectricityPerApartment DECIMAL(18, 2);
                DECLARE @WaterPerApartment DECIMAL(18, 2);
                DECLARE @GasPerApartment DECIMAL(18, 2);

                SET @ElectricityPerApartment = @ElectricityAmount / @OccupiedApartmentCount;
                SET @WaterPerApartment = @WaterAmount / @OccupiedApartmentCount;
                SET @GasPerApartment = @GasAmount / @OccupiedApartmentCount;

                UPDATE ApartmentBills
                SET ElectricityAmount = @ElectricityPerApartment,
                    WaterAmount = @WaterPerApartment,
                    GasAmount = @GasPerApartment
                WHERE ApartmentId IN (
                    SELECT Id
                    FROM Apartment
                    WHERE OccupancyStatus = 1
                );
            END;
        END;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
