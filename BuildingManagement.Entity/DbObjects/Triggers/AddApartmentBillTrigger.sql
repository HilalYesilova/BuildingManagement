EXEC('CREATE OR ALTER TRIGGER [dbo].[InsertApartmentBillTrigger]
   ON  [BUILDINGMANAGEMENT].[dbo].[Bills]
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

	DECLARE @Month INT;
    DECLARE @Year INT;

	SELECT 
        @Month = MONTH(@BillMonth),
        @Year = YEAR(@BillMonth);

    DECLARE @OccupiedApartmentCount INT;
    SELECT @OccupiedApartmentCount = COUNT(*)
    FROM Apartments
    WHERE OccupancyStatus = 1;

    IF @OccupiedApartmentCount > 0
    BEGIN
        DECLARE @ElectricityPerApartment DECIMAL(18, 2);
        DECLARE @WaterPerApartment DECIMAL(18, 2);
        DECLARE @GasPerApartment DECIMAL(18, 2);

        SET @ElectricityPerApartment = @ElectricityAmount / @OccupiedApartmentCount;
        SET @WaterPerApartment = @WaterAmount / @OccupiedApartmentCount;
        SET @GasPerApartment = @GasAmount / @OccupiedApartmentCount;

		INSERT INTO ApartmentBills ([Month], [Year], [ElectricityAmount], [WaterAmount], [GasAmount],[IsPaid])
		VALUES (@Month, @Year, @ElectricityPerApartment, @WaterPerApartment, @GasPerApartment,0)

        UPDATE ApartmentBills
        SET ApartmentId = (SELECT Id FROM Apartments WHERE OccupancyStatus = 1)

    END;
END;')