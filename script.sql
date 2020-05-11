USE [QuanLyNhanVien]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[PhongBanId] [int] NOT NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DaXoa] [bit] NOT NULL,
	[NgayTao] [date] NULL,
	[NgaySua] [date] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[ID] [int] NOT NULL,
	[MaPhongBan] [nvarchar](50) NOT NULL,
	[TenPhongBan] [nvarchar](50) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([PhongBanId])
REFERENCES [dbo].[PhongBan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
/****** Object:  StoredProcedure [dbo].[DanhSachPhongBan]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 11/5/2020	
-- Description:	get list phòng ban
-- =============================================
CREATE PROCEDURE [dbo].[DanhSachPhongBan]
    
AS
BEGIN
SELECT [ID]
      ,[MaPhongBan]
      ,[TenPhongBan]
 
  FROM [dbo].[PhongBan]
  where DaXoa =0 

END
GO
/****** Object:  StoredProcedure [dbo].[LayPhongBanID]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 11/5/2020	
-- Description:	lấy phòng ban theo id
-- =============================================
CREATE PROCEDURE [dbo].[LayPhongBanID]
    @Id int
AS
BEGIN
IF (not exists(select * from [dbo].[PhongBan] where DaXoa = 0 and Id = @Id))
begin
	raiserror('hien thi thong bao loi',1,100)
	return
 end

SELECT [ID]
      ,[MaPhongBan]
      ,[TenPhongBan]
 
  FROM [dbo].[PhongBan]
  where Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[SuaPhongBan]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 11/5/2020	
-- Description:	sửa phòng ban
-- =============================================
CREATE PROCEDURE [dbo].[SuaPhongBan]
    @Id int,	
	@MaPhongBan nvarchar(50),
	@TenPhongBan nvarchar(50)
AS
BEGIN
UPDATE [dbo].[PhongBan]
   SET 
      [MaPhongBan] = @MaPhongBan
      ,[TenPhongBan] = @TenPhongBan
      
 WHERE Id = @Id




select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[TaoPhongBan]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 11/5/2020	
-- Description:	tạo bản phòng ban / creat a new phòng ban	
-- =============================================
CREATE PROCEDURE [dbo].[TaoPhongBan]	
	@MaPhongBan nvarchar(50),
	@TenPhongBan nvarchar(50)
AS
BEGIN


INSERT INTO [dbo].[PhongBan]
          
           ([MaPhongBan]
           ,[TenPhongBan]
           ,[DaXoa])
     VALUES
          
             (@MaPhongBan 
           ,@TenPhongBan
           ,0)
declare @Id int
set @Id = SCOPE_IDENTITY()
select @Id as Id
END
GO
/****** Object:  StoredProcedure [dbo].[XoaPhongBan]    Script Date: 5/11/2020 4:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 11/5/2020	
-- Description:	xóa phòng ban
-- =============================================
CREATE PROCEDURE [dbo].[XoaPhongBan]
    @Id int
AS
begin
declare @Result BIT=0
BEGIN try

UPDATE [dbo].[PhongBan]
   SET [DaXoa] =1
      
 WHERE Id = @Id
 set @Result =1
 end try
 begin catch
 end catch



select @Result as Result
END
GO
