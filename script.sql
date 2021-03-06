USE [QuanLyNhanVien]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/12/2020 12:01:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[PhongBanId] [int] NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[DienThoai] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DaXoa] [bit] NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[NgaySua] [datetime] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  StoredProcedure [dbo].[DanhSachNhanVienTheoPhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 12/5/2020	
-- Description:	danh sách nhân viên theo phong ban
-- =============================================
create PROCEDURE [dbo].[DanhSachNhanVienTheoPhongBan]
    @PhongBanId int
AS
BEGIN
SELECT [MaNV]
      ,[PhongBanId]
      ,[Ho]
      ,[Ten]
      ,[DiaChi]
      ,[DienThoai]
      ,[Email]
    
      ,[NgayTao]
      ,[NgaySua]
  FROM [dbo].[NhanVien]

  where PhongBanId = @PhongBanId and DaXoa = 0

END
GO
/****** Object:  StoredProcedure [dbo].[DanhSachPhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[LayNhanVienTheoMaNV]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Tâm	
-- Create date: 12/5/2020	
-- Description:	lấy nhân viên theo ma nhan vien
-- =============================================
create PROCEDURE [dbo].[LayNhanVienTheoMaNV]
    @MaNV int
AS
BEGIN
SELECT [MaNV]
      ,[PhongBanId]
      ,[Ho]
      ,[Ten]
      ,[DiaChi]
      ,[DienThoai]
      ,[Email]
    
      ,[NgayTao]
      ,[NgaySua]
  FROM [dbo].[NhanVien]

  where MaNV = @MaNV and DaXoa = 0

END
GO
/****** Object:  StoredProcedure [dbo].[LayPhongBanID]    Script Date: 5/12/2020 12:02:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SuaNhanVien]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Tâm	
-- Create date: 12/5/2020	
-- Description:	Edit a emloyee
-- =============================================
CREATE PROCEDURE [dbo].[SuaNhanVien]
   @MaNV int,
   @PhongBanId int,
   @Ho nvarchar(50),
   @Ten nvarchar(50),
   @DiaChi nvarchar(50),
   @DienThoai nvarchar(50),
   @Email nvarchar(50)
   
AS
BEGIN

UPDATE [dbo].[NhanVien]
   SET [PhongBanId] = @PhongBanId
      ,[Ho] = @Ho
      ,[Ten] = @Ten
      ,[DiaChi] = @DiaChi
      ,[DienThoai] = @DienThoai
      ,[Email] = @Email
      ,[NgaySua] = GETDATE()

 WHERE MaNV = @MaNV


select @MaNv as MaNV
END
GO
/****** Object:  StoredProcedure [dbo].[SuaPhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[TaoNhanVien]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Tâm	
-- Create date: 12/5/2020	
-- Description:	create new emloyee
-- =============================================
CREATE PROCEDURE [dbo].[TaoNhanVien]
   @PhongBanId int,
   @Ho nvarchar(50),
   @Ten nvarchar(50),
   @DiaChi nvarchar(50),
   @DienThoai nvarchar(50),
   @Email nvarchar(50)
   
AS
BEGIN

INSERT INTO [dbo].[NhanVien]
           ([PhongBanId]
           ,[Ho]
           ,[Ten]
           ,[DiaChi]
           ,[DienThoai]
           ,[Email]
           ,[DaXoa]
           ,[NgayTao]
           ,[NgaySua])
     VALUES
           (@PhongBanId
           ,@Ho
           ,@Ten
           ,@DiaChi
           ,@DienThoai
           ,@Email
           ,0
           ,GETDATE()
           ,GETDATE())
DECLARE @MaNV int
set @MaNv = SCOPE_IDENTITY()
select @MaNv as MaNV
END
GO
/****** Object:  StoredProcedure [dbo].[TaoPhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[XoaNhanVien]    Script Date: 5/12/2020 12:02:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Tâm	
-- Create date: 12/5/2020	
-- Description:	Delete a emloyee
-- =============================================


CREATE PROCEDURE [dbo].[XoaNhanVien]
   @MaNV int
AS
begin
declare @Result BIT=0
BEGIN try

UPDATE [dbo].[NhanVien]
   SET [DaXoa] = 1,
       [NgaySua] = Getdate()
      
 WHERE MaNV = @MaNv
 set @Result =1
 end try
 begin catch
 end catch



select @Result as Result
END
GO
/****** Object:  StoredProcedure [dbo].[XoaPhongBan]    Script Date: 5/12/2020 12:02:00 PM ******/
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
