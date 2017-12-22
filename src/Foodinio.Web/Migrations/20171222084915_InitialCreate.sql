IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [Email] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Role] nvarchar(max) NULL,
    [Salt] nvarchar(max) NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BlanketOrders] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_BlanketOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlanketOrders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Dishes] (
    [Id] uniqueidentifier NOT NULL,
    [BlanketOrderId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [MealType] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [PicturePath] nvarchar(max) NULL,
    [Price] decimal(18, 2) NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Dishes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dishes_BlanketOrders_BlanketOrderId] FOREIGN KEY ([BlanketOrderId]) REFERENCES [BlanketOrders] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Orders] (
    [Id] uniqueidentifier NOT NULL,
    [BlanketOrderId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [TotalPrice] decimal(18, 2) NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [UserId] uniqueidentifier NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_BlanketOrders_BlanketOrderId] FOREIGN KEY ([BlanketOrderId]) REFERENCES [BlanketOrders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [DeliveryAddresses] (
    [Id] uniqueidentifier NOT NULL,
    [City] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [HouseNumber] nvarchar(max) NULL,
    [OrderId] uniqueidentifier NULL,
    [PostalCode] nvarchar(max) NULL,
    [Street] nvarchar(max) NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_DeliveryAddresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DeliveryAddresses_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DeliveryAddresses_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_BlanketOrders_UserId] ON [BlanketOrders] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_DeliveryAddresses_OrderId] ON [DeliveryAddresses] ([OrderId]) WHERE [OrderId] IS NOT NULL;

GO

CREATE INDEX [IX_DeliveryAddresses_UserId] ON [DeliveryAddresses] ([UserId]);

GO

CREATE INDEX [IX_Dishes_BlanketOrderId] ON [Dishes] ([BlanketOrderId]);

GO

CREATE INDEX [IX_Orders_BlanketOrderId] ON [Orders] ([BlanketOrderId]);

GO

CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171222084915_InitialCreate', N'2.0.1-rtm-125');

GO