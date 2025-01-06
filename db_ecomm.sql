-- Drop existing tables if they exist
IF OBJECT_ID('dbo.transactions', 'U') IS NOT NULL DROP TABLE dbo.transactions;
IF OBJECT_ID('dbo.products', 'U') IS NOT NULL DROP TABLE dbo.products;
IF OBJECT_ID('dbo.categories', 'U') IS NOT NULL DROP TABLE dbo.categories;
IF OBJECT_ID('dbo.users', 'U') IS NOT NULL DROP TABLE dbo.users;
GO

--
-- Table structure for table [categories]
--
CREATE TABLE [categories] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [created_by] BIGINT NOT NULL,
    [category_name] NVARCHAR(255) NOT NULL,
    CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

--
-- Dumping data for table [categories]
--
INSERT INTO [categories] ([created_by], [category_name]) VALUES
(1, N'Tiểu thuyết'),
(1, N'Phi tiểu thuyết'),
(1, N'Khoa học'),
(1, N'Lịch sử'),
(1, N'Tiểu sử');
GO

--
-- Table structure for table [products]
--
CREATE TABLE [products] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [id_category] BIGINT NOT NULL,
    [created_by] BIGINT NOT NULL,
    [product_name] NVARCHAR(255) NOT NULL,
    [description] NVARCHAR(MAX) NOT NULL,
    [stock] INT NOT NULL,
    [price] FLOAT NOT NULL,
    [image] NVARCHAR(255) NOT NULL,
    CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_products_categories] FOREIGN KEY ([id_category]) REFERENCES [categories]([id]) ON DELETE CASCADE
);
GO

--
-- Dumping data for table [products]
--
INSERT INTO [products] ([id_category], [created_by], [product_name], [description], [stock], [price], [image]) VALUES
(1, 1, N'Nhập môn Vật lý thiên văn', N'Giới thiệu về khoa học vật lý thiên văn.', 15, 450.75, 'https://example.com/image1.jpg'),
(2, 1, N'Bí quyết nấu ăn', N'Học các nguyên tắc cơ bản của nấu ăn với hướng dẫn từng bước.', 25, 199.99, 'https://example.com/image2.jpg'),
(2, 1, N'Kỹ năng nhiếp ảnh', N'Hướng dẫn toàn diện để cải thiện kỹ năng chụp ảnh của bạn.', 18, 299.50, 'https://example.com/image3.jpg'),
(1, 1, N'Cuộc phiêu lưu vĩ đại', N'Một tiểu thuyết hấp dẫn đầy hồi hộp và bí ẩn.', 10, 150.00, 'https://example.com/image4.jpg'),
(1, 1, N'Truyện tình cảm', N'Tuyển tập những câu chuyện tình cảm hay nhất.', 12, 175.25, 'https://example.com/image5.jpg'),
(1, 1, N'Lịch sử thế giới', N'Cuốn sách toàn diện về lịch sử thế giới.', 8, 699.99, 'https://example.com/image6.jpg'),
(3, 1, N'Vật lý cho người đam mê', N'Một sự giới thiệu hấp dẫn về thế giới vật lý.', 9, 550.75, 'https://example.com/image7.jpg'),
(3, 1, N'Khoa học hiện đại giải thích', N'Giải thích các khái niệm khoa học phức tạp.', 4, 899.00, 'https://example.com/image8.jpg'),
(1, 1, N'Sự kiện lịch sử', N'Các sự kiện lịch sử quan trọng và ý nghĩa của chúng.', 7, 625.50, 'https://example.com/image9.jpg'),
(2, 1, N'Ẩm thực đặc sắc', N'Khám phá nghệ thuật tạo ra những món ăn ngon.', 20, 250.00, 'https://example.com/image10.jpg');
GO

--
-- Table structure for table [users]
--
CREATE TABLE [users] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [name] NVARCHAR(255) NOT NULL,
    [phone] NVARCHAR(255) NOT NULL,
    [address] NVARCHAR(MAX) NOT NULL,
    [role] NVARCHAR(10) NOT NULL DEFAULT 'Buyer',
    [password] NVARCHAR(255) NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

--
-- Dumping data for table [users]
--
INSERT INTO [users] ([name], [phone], [address], [role], [password]) VALUES
(N'Nguyễn Văn A', '1234', N'123 Đường Thư Viện', 'Admin', 'E10ADC3949BA59ABBE56E057F20F883E'),
(N'Trần Thị B', '1212', N'456 Ngõ Sách', 'Admin', '96E79218965EB72C92A549DD5A330112');
GO

--
-- Table structure for table [transactions]
--
CREATE TABLE [transactions] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [id_user] BIGINT NOT NULL,
    [id_product] BIGINT NOT NULL,
    [status] NVARCHAR(10) NOT NULL,
    [invoice_number] NVARCHAR(20) NOT NULL,
    [date] DATETIME NOT NULL DEFAULT GETDATE(),
    [payed] FLOAT NULL,
    CONSTRAINT [PK_transactions] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_transactions_users] FOREIGN KEY ([id_user]) REFERENCES [users]([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_transactions_products] FOREIGN KEY ([id_product]) REFERENCES [products]([id]) ON DELETE CASCADE
);
GO

--
-- Add Foreign Keys after creating all tables
--
ALTER TABLE [products] ADD CONSTRAINT [FK_products_users] FOREIGN KEY ([created_by]) REFERENCES [users]([id]) ON DELETE NO ACTION;
GO
