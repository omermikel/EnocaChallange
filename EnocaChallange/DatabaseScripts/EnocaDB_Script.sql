Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'CarrierPlusDesiCost' on entity type 'Carrier'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'CarrierCost' on entity type 'CarrierConfiguration'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'OrderCarrierCost' on entity type 'Order'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.36 initialized 'AppDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.36' with options: None
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Carriers] (
    [CarrierId] int NOT NULL IDENTITY,
    [CarrierName] nvarchar(max) NOT NULL,
    [CarrierIsActive] bit NOT NULL,
    [CarrierPlusDesiCost] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Carriers] PRIMARY KEY ([CarrierId])
);
GO

CREATE TABLE [CarrierConfigurations] (
    [CarrierConfigurationId] int NOT NULL IDENTITY,
    [CarrierId] int NOT NULL,
    [CarrierMaxDesi] int NOT NULL,
    [CarrierMinDesi] int NOT NULL,
    [CarrierCost] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY ([CarrierConfigurationId]),
    CONSTRAINT [FK_CarrierConfigurations_Carriers_CarrierId] FOREIGN KEY ([CarrierId]) REFERENCES [Carriers] ([CarrierId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [CarrierId] int NOT NULL,
    [OrderDesi] int NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [OrderCarrierCost] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_Carriers_CarrierId] FOREIGN KEY ([CarrierId]) REFERENCES [Carriers] ([CarrierId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CarrierConfigurations_CarrierId] ON [CarrierConfigurations] ([CarrierId]);
GO

CREATE INDEX [IX_Orders_CarrierId] ON [Orders] ([CarrierId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241207134322_InitialCreate', N'6.0.36');
GO

COMMIT;
GO


