BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220926151920_ProductTracking00002', N'6.0.9');
GO

COMMIT;
GO

