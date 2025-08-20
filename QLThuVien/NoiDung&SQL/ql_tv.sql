--LƯỢC ĐỒ CSDL QUẢN LÝ THƯ VIỆN
	--SACH (MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN, TONTAI)
	--DOCGIA (MADG, TENDG, DIACHI, DIENTHOAI, TONTAI)
	--NHANVIEN (MANV, TENNV, CHUCVU, DIENTHOAI, NGAYVAOLAM, TONTAI)
	--MUONTRA (MAMUONTRA, MASACH, MADG, MANV, NGAYMUON, NGAYTRA)
go
----------------------------------------------------------------------------------
go

-- Tạo cơ sở dữ liệu ql_tv
USE master
GO

CREATE DATABASE ql_tv
--ON PRIMARY
--( 
--	NAME = qltv_data,
--	--FILENAME = 'E:\LuuDuLieuSinhVien\LM\qltv_data.mdf',
--	FILENAME = 'D:\He quan tri CSDL\do an\qltv_data.mdf',
--	SIZE = 4 MB,
--	MAXSIZE = 10 MB,
--	FILEGROWTH = 1MB
--),
--(
--	NAME = qltv_data1,
--	--FILENAME = 'E:\LuuDuLieuSinhVien\LM\qltv_data1.ndf',
--	FILENAME = 'D:\He quan tri CSDL\do an\qltv_data1.ndf',
--	SIZE = 4 MB,
--	MAXSIZE = 10 MB,
--	FILEGROWTH = 10%
--),
--(
--	NAME = qltv_data2,
--	--FILENAME = 'E:\LuuDuLieuSinhVien\LM\qltv_data2.ndf',
--	FILENAME = 'D:\He quan tri CSDL\do an\qltv_data2.ndf',
--	SIZE = 4 MB,
--	MAXSIZE = 10 MB,
--	FILEGROWTH = 10%
--)
--LOG ON 
--(
--	NAME = qltv_log,
--	--FILENAME = 'E:\LuuDuLieuSinhVien\LM\qltv_log.ldf',
--	FILENAME = 'D:\He quan tri CSDL\do an\qltv_log.ldf',
--	SIZE = 4 MB,
--	MAXSIZE = 10 MB,
--	FILEGROWTH = 10%
--)
GO

-- Sử dụng cơ sở dữ liệu ql_tv
USE ql_tv;
go
----------------------------------------------------------------------------------
GO
--Tạo bảng
CREATE TABLE TRANGTHAI_DANGNHAP (
    USER_NAME NVARCHAR(255) PRIMARY KEY,                      
    TRANGTHAI BIT NOT NULL DEFAULT 0, -- Tình trạng tồn tại (0: đã xóa, 1: tồn tại)             
);
go
CREATE TABLE QuyenNguoiDung (
    UserName NVARCHAR(255) PRIMARY KEY,                      
    QuyenSelect bit not null,
	QuyenInsert bit not null,
	QuyenAll bit not null
);
GO

CREATE TABLE SACH (
    MASACH INT PRIMARY KEY IDENTITY(1,1),  
    TENSACH NVARCHAR(255) NOT NULL,        
    TACGIA NVARCHAR(255) not null,                  
    THELOAI NVARCHAR(100),                 
    NAMXUATBAN INT,                        
    NHAXUATBAN NVARCHAR(255),              
    TONTAI BIT NOT NULL DEFAULT 1, -- Tình trạng tồn tại (0: đã xóa, 1: tồn tại)
	UNIQUE(TENSACH,TACGIA)
);
go

CREATE TABLE DOCGIA (
    MADG INT PRIMARY KEY IDENTITY(1,1),     
    TENDG NVARCHAR(255) NOT NULL,           
    DIACHI NVARCHAR(255),                   
    DIENTHOAI VARCHAR(15) not null,
    TONTAI BIT NOT NULL DEFAULT 1, -- Tình trạng tồn tại (0: đã xóa, 1: tồn tại)

	UNIQUE(DIENTHOAI),
	CONSTRAINT chk_DienThoai_DocGia CHECK (DIENTHOAI LIKE '[0-9]%' AND LEN(DIENTHOAI) BETWEEN 10 AND 15)
);
go

CREATE TABLE NHANVIEN (
    MANV INT PRIMARY KEY IDENTITY(1,1),    
    TENNV NVARCHAR(255) NOT NULL,          
    CHUCVU NVARCHAR(100) DEFAULT N'Nhân viên',                  
    DIENTHOAI NVARCHAR(15),              
    NGAYVAOLAM DATE DEFAULT GETDATE() ,         
    TONTAI BIT NOT NULL DEFAULT 1, -- Tình trạng tồn tại (0: đã xóa, 1: tồn tại)

	UNIQUE(DIENTHOAI),
	CONSTRAINT chk_DienThoai_NhanVien CHECK (DIENTHOAI LIKE '[0-9]%' AND LEN(DIENTHOAI) BETWEEN 10 AND 15)
);
go

CREATE TABLE MUONTRA (
    MAMUONTRA INT PRIMARY KEY IDENTITY(1,1),  
    MASACH INT NOT NULL,                      
    MADG INT NOT NULL,                        
    MANV INT NOT NULL,                        
    NGAYMUON datetime2(0) DEFAULT GETDATE() NOT NULL,
    NGAYTRA datetime2(0) NULL,                        

    -- Khóa ngoại
    CONSTRAINT FK_MUONTRA_SACH FOREIGN KEY (MASACH) REFERENCES SACH(MASACH),
    CONSTRAINT FK_MUONTRA_DOCGIA FOREIGN KEY (MADG) REFERENCES DOCGIA(MADG),
    CONSTRAINT FK_MUONTRA_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
    
	UNIQUE(MASACH,MADG,MANV,NGAYMUON,NGAYTRA),
    CHECK (NGAYTRA IS NULL OR NGAYTRA >= NGAYMUON)
);
go
----------------------------------------------------------------------------------
go
--Tạo TRIGGER
GO
--CREATE OR ALTER TRIGGER TR_LimitLoginSessions
--ON ALL SERVER
--FOR LOGON
--AS
--BEGIN
--    DECLARE @LoginName NVARCHAR(128);
--    SET @LoginName = ORIGINAL_LOGIN(); -- Lấy tên tài khoản đăng nhập

--    -- Bỏ qua kiểm tra cho tài khoản 'sa'
--    IF @LoginName <> 'sa'
--    BEGIN
--        -- Kiểm tra nếu có phiên làm việc khác đã tồn tại cho tài khoản này
--        IF EXISTS (
--            SELECT 1
--            FROM sys.dm_exec_sessions
--            WHERE login_name = @LoginName
--              AND session_id <> @@SPID -- Loại trừ session hiện tại
--        )
--        BEGIN
--            -- Nếu tồn tại session khác, ngăn đăng nhập
--            PRINT 'Tài khoản này đã có phiên làm việc khác';
--            ROLLBACK; -- Ngăn chặn phiên đăng nhập mới
--        END
--    END
--END;
--go
--ENABLE TRIGGER TR_LimitLoginSessions ON ALL SERVER;
--DISABLE TRIGGER TR_LimitLoginSessions ON ALL SERVER;
go

CREATE TRIGGER trg_CheckExistenceBeforeInsert
ON MUONTRA
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra sự tồn tại của sách
    IF EXISTS (
        SELECT 1 
        FROM INSERTED i
        LEFT JOIN SACH s ON i.MASACH = s.MASACH AND s.TONTAI = 1
        WHERE s.MASACH IS NULL
    )
    BEGIN
        RAISERROR('Sách không tồn tại hoặc đã bị xóa.', 16, 1);
        RETURN;
    END

    -- Kiểm tra sự tồn tại của độc giả
    IF EXISTS (
        SELECT 1 
        FROM INSERTED i
        LEFT JOIN DOCGIA d ON i.MADG = d.MADG AND d.TONTAI = 1
        WHERE d.MADG IS NULL
    )
    BEGIN
        RAISERROR('Độc giả không tồn tại hoặc đã bị xóa.', 16, 1);
        RETURN;
    END

    -- Kiểm tra sự tồn tại của nhân viên
    IF EXISTS (
        SELECT 1 
        FROM INSERTED i
        LEFT JOIN NHANVIEN n ON i.MANV = n.MANV AND n.TONTAI = 1
        WHERE n.MANV IS NULL
    )
    BEGIN
        RAISERROR('Nhân viên không tồn tại hoặc đã bị xóa.', 16, 1);
        RETURN;
    END

    -- Kiểm tra sách đã được mượn hay chưa
    IF EXISTS (
        SELECT 1 
        FROM INSERTED i
        JOIN MUONTRA m ON i.MASACH = m.MASACH
        WHERE m.NGAYTRA IS NULL
    )
    BEGIN
        RAISERROR('Sách đã được mượn trước đó và chưa được trả.', 16, 1);
        RETURN;
    END

    -- Chèn các bản ghi hợp lệ vào bảng MUONTRA
    INSERT INTO MUONTRA (MASACH, MADG, MANV, NGAYMUON, NGAYTRA)
    SELECT MASACH, MADG, MANV, NGAYMUON, NGAYTRA
    FROM INSERTED;
END;
GO

----------------------------------------------------------------------------------
go
--Tạo VIEW

CREATE VIEW vw_SachConTonTai AS
SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN
FROM SACH
WHERE TONTAI = 1;
GO

CREATE VIEW vw_DocGiaConTonTai AS
SELECT MADG, TENDG, DIACHI, DIENTHOAI
FROM DOCGIA
WHERE TONTAI = 1;
GO

CREATE VIEW vw_NhanVienConTonTai AS
SELECT MANV, TENNV, CHUCVU, DIENTHOAI, NGAYVAOLAM
FROM NHANVIEN
WHERE TONTAI = 1;
GO
---------------------------------------------
create view vw_SachConTonTaiVaCot as
SELECT 'MASACH' AS MASACH, 'TENSACH' AS TENSACH, 'TACGIA' AS TACGIA, 'THELOAI' AS THELOAI, 
       'NAMXUATBAN' AS NAMXUATBAN, 'NHAXUATBAN' AS NHAXUATBAN
UNION ALL
SELECT CAST(MASACH AS NVARCHAR), TENSACH, TACGIA, THELOAI, 
       CAST(NAMXUATBAN AS NVARCHAR), NHAXUATBAN
FROM vw_SachConTonTai;
go

CREATE VIEW vw_DocGiaConTonTaiVaCot AS
SELECT 'MADG' AS MADG, 'TENDG' AS TENDG, 'DIACHI' AS DIACHI, 'DIENTHOAI' AS DIENTHOAI
UNION ALL
SELECT CAST(MADG AS NVARCHAR), TENDG, DIACHI, DIENTHOAI
FROM vw_DocGiaConTonTai
GO

CREATE VIEW vw_NhanVienConTonTaiVaCot AS
SELECT 'MANV' AS MANV, 'TENNV' AS TENNV, 'CHUCVU' AS CHUCVU, 'DIENTHOAI' AS DIENTHOAI, 'NGAYVAOLAM' AS NGAYVAOLAM
UNION ALL
SELECT CAST(MANV AS NVARCHAR), TENNV, CHUCVU, DIENTHOAI, CAST(NGAYVAOLAM AS NVARCHAR)
FROM vw_NhanVienConTonTai
GO

CREATE VIEW vw_MuonTraVaCot AS
SELECT 'MAMUONTRA' AS MAMUONTRA, 'MASACH' AS MASACH, 'MADG' AS MADG, 'MANV' AS MANV, 'NGAYMUON' AS NGAYMUON, 'NGAYTRA' AS NGAYTRA
UNION ALL
SELECT CAST(MAMUONTRA AS NVARCHAR), CAST(MASACH AS NVARCHAR), CAST(MADG AS NVARCHAR), CAST(MANV AS NVARCHAR), 
       CAST(NGAYMUON AS NVARCHAR), ISNULL(CAST(NGAYTRA AS NVARCHAR), 'NULL')
FROM MUONTRA;
GO
---------------------------------------------------
CREATE VIEW vw_import_SACH AS
SELECT 
    TENSACH, 
    TACGIA, 
    THELOAI, 
    NAMXUATBAN, 
    NHAXUATBAN 
FROM SACH;
GO

CREATE VIEW vw_import_DOCGIA AS
SELECT 
    TENDG, 
    DIACHI, 
    DIENTHOAI 
FROM DOCGIA;
GO

CREATE VIEW vw_import_NHANVIEN AS
SELECT 
    TENNV, 
    CHUCVU, 
    DIENTHOAI, 
    NGAYVAOLAM 
FROM NHANVIEN;
GO

CREATE VIEW vw_import_MUONTRA AS
SELECT 
    MASACH, 
    MADG, 
    MANV, 
    NGAYMUON, 
    NGAYTRA 
FROM MUONTRA;
GO
------------------------------------------------------
create VIEW vw_DocGiaMuonNhieuNhat AS
SELECT 
    DOCGIA.*, 
    COUNT(MUONTRA.MADG) AS SoLanMuon 
FROM 
    docgia
JOIN 
    MUONTRA ON DOCGIA.MADG = MUONTRA.MADG
WHERE 
    DOCGIA.MADG IN (
        SELECT TOP 1 WITH TIES MUONTRA.MADG
        FROM MUONTRA
        GROUP BY MUONTRA.MADG
        ORDER BY COUNT(*) DESC
    )
GROUP BY 
    DOCGIA.MADG, DOCGIA.TENDG, DOCGIA.DIACHI, DOCGIA.DIENTHOAI, DOCGIA.TONTAI;
GO

create VIEW vw_NhanVienChoMuonNhieuNhat AS
SELECT 
    NHANVIEN.*, 
    COUNT(MUONTRA.MANV) AS SoLanChoMuon 
FROM 
    NHANVIEN
JOIN 
    MUONTRA ON NHANVIEN.MANV = MUONTRA.MANV
WHERE 
    NHANVIEN.MANV IN (
        SELECT TOP 1 WITH TIES MUONTRA.MANV 
        FROM MUONTRA
        GROUP BY MUONTRA.MANV
        ORDER BY COUNT(*) DESC
    )
GROUP BY 
    NHANVIEN.MANV, NHANVIEN.TENNV, NHANVIEN.CHUCVU, NHANVIEN.DIENTHOAI, NHANVIEN.NGAYVAOLAM, NHANVIEN.TONTAI;
GO

CREATE VIEW vw_SachDuocMuonNhieuNhat AS
SELECT 
    SACH.*, 
    COUNT(MUONTRA.MASACH) AS SoLanMuon 
FROM 
    SACH
JOIN 
    MUONTRA ON SACH.MASACH = MUONTRA.MASACH
WHERE 
    SACH.MASACH IN (
        SELECT TOP 1 WITH TIES MUONTRA.MASACH 
        FROM MUONTRA
        GROUP BY MUONTRA.MASACH
        ORDER BY COUNT(*) DESC
    )
GROUP BY 
    SACH.MASACH, SACH.TENSACH, SACH.TACGIA, SACH.THELOAI, SACH.NAMXUATBAN, SACH.NHAXUATBAN, SACH.TONTAI;
GO
-----------------------------------------------------
CREATE VIEW vw_ThongTinDocGiaMuonSach AS
SELECT dg.MADG, dg.TENDG, dg.DIACHI, dg.DIENTHOAI, mt.NGAYMUON, s.TENSACH, s.TACGIA
FROM DOCGIA dg
JOIN MUONTRA mt ON dg.MADG = mt.MADG
JOIN SACH s ON mt.MASACH = s.MASACH;
GO

--CREATE VIEW vw_ThongTinDocGiaMuonSachSapXepTheoThuTu AS
--SELECT dg.MADG, dg.TENDG, dg.DIACHI, dg.DIENTHOAI, COUNT(mt.MASACH) AS SoLuongSachMuon
--FROM DOCGIA dg
--JOIN MUONTRA mt ON dg.MADG = mt.MADG
--GROUP BY dg.MADG, dg.TENDG, dg.DIACHI, dg.DIENTHOAI
--ORDER BY SoLuongSachMuon DESC;
--GO

CREATE VIEW vw_TongHopSachTheoTheLoai AS
SELECT THELOAI, COUNT(*) AS SoLuongSach
FROM vw_SachConTonTai
GROUP BY THELOAI;
go

----------------------------------------------------------------------------------
go
-- Tạo role User trong cơ sở dữ liệu hiện tại

CREATE ROLE Users;
-- Cấp quyền SELECT trên bảng SACH cho role User
GRANT SELECT ON SACH TO Users;
GRANT SELECT ON vw_SachConTonTai TO Users;
go

-- Tạo role NhanVien
CREATE ROLE NhanVien;

-- Cấp quyền SELECT, INSERT, DELETE, và UPDATE cho bảng SACH
GRANT SELECT, INSERT, DELETE, UPDATE ON SACH TO NhanVien;
GRANT SELECT ON vw_SachConTonTai TO NhanVien;

-- Cấp quyền SELECT, INSERT, DELETE, và UPDATE cho bảng DOCGIA
GRANT SELECT, INSERT, DELETE, UPDATE ON DOCGIA TO NhanVien;
GRANT SELECT ON vw_docgiaConTonTai TO NhanVien;
-- Cấp quyền SELECT, INSERT, DELETE, và UPDATE cho bảng MUONTRA
GRANT SELECT, INSERT, DELETE, UPDATE ON MUONTRA TO NhanVien;
go

----------------------------------------------------------------------------------
go
--Tạo PROCEDURE
--------------------------------------- dang xuat cac tk cung login
CREATE PROCEDURE SP_DangNhap
    @Username NVARCHAR(50)
AS
BEGIN
    -- Check if the username already exists
    IF NOT EXISTS (
        SELECT 1 
        FROM TRANGTHAI_DANGNHAP 
        WHERE USER_NAME = @Username
    )
    BEGIN
        -- If the username does not exist, insert it
        INSERT INTO TRANGTHAI_DANGNHAP (USER_NAME, TRANGTHAI)
        VALUES (@Username, 1);
    END
    ELSE
    BEGIN
        -- If the username does not exist, insert it
        UPDATE TRANGTHAI_DANGNHAP SET TRANGTHAI = 1 WHERE USER_NAME = @Username;
    END
END;
GO

CREATE PROCEDURE SP_DangXuat
    @Username NVARCHAR(50)
AS
BEGIN
    -- If the username does not exist, insert it
    DELETE FROM TRANGTHAI_DANGNHAP WHERE USER_NAME = @Username;
END;
GO

create FUNCTION F_KiemTraTrangThai(@Username NVARCHAR(50))
RETURNS BIT
AS
BEGIN
     IF EXISTS (
        SELECT 1 
        FROM TRANGTHAI_DANGNHAP 
        WHERE USER_NAME = @Username
    )
    BEGIN
       RETURN 1;
    END

    RETURN 0;
END;
go
GRANT EXECUTE ON dbo.F_KiemTraTrangThai TO PUBLIC;
GRANT EXECUTE ON dbo.SP_DangNhap TO PUBLIC;
GRANT EXECUTE ON dbo.SP_DangXuat TO PUBLIC;
go
------------------------------------------------
create PROCEDURE sp_ExportDataWithBCP
    @tableName NVARCHAR(255),  -- Tên bảng cần export
    @filePath NVARCHAR(255)    -- Đường dẫn file output
AS
BEGIN
    -- Kích hoạt advanced options
    EXEC sp_configure 'show advanced options', 1;
    RECONFIGURE;
    -- Kích hoạt xp_cmdshell
    EXEC sp_configure 'xp_cmdshell', 1;
    RECONFIGURE;

	declare @bcpCommand NVARCHAR(255)
    -- Lệnh BCP
    SET @bcpCommand = 'bcp "ql_tv.dbo.' + @tableName + '" out "' + @filePath + '" -c -t "," -T -S "DESKTOP-SMMDH16\SQLEXPRESS" -C 65001';

    -- Gọi lệnh BCP thông qua xp_cmdshell để xuất dữ liệu
    EXEC xp_cmdshell @bcpCommand;

    -- Tắt advanced options
    EXEC sp_configure 'xp_cmdshell', 0;
    RECONFIGURE;
    EXEC sp_configure 'show advanced options', 0;
    RECONFIGURE;
END;
GO

create PROCEDURE sp_ImportDataWithBCP
	@tableName NVARCHAR(255),  -- Tên bảng cần import
    @filePath NVARCHAR(255)    -- Đường dẫn file input
AS
BEGIN
	-- Kích hoạt advanced options
	EXEC sp_configure 'show advanced options', 1;
	RECONFIGURE;
	-- Kích hoạt xp_cmdshell
	EXEC sp_configure 'xp_cmdshell', 1;
	RECONFIGURE;

    DECLARE @bcpCommand NVARCHAR(4000);
    -- Tạo lệnh BCP với tham số truyền vào
    SET @bcpCommand = 'bcp ql_tv.dbo.' + @tableName + ' in "' + @filePath + '" -c -F2 -C 65001 -t, -T -S "DESKTOP-SMMDH16\SQLEXPRESS"';
    -- Gọi lệnh BCP thông qua xp_cmdshell
    EXEC xp_cmdshell @bcpCommand;

	-- Tắt advanced options
	EXEC sp_configure 'show advanced options', 0;
	RECONFIGURE;
END;
GO
-------------------------------------------------
CREATE PROCEDURE SP_AddUserToRole
    @Username NVARCHAR(255),  -- Tên người dùng
    @RoleName NVARCHAR(255)    -- Tên vai trò mới
AS
BEGIN
    DECLARE @CurrentRole NVARCHAR(255);

    -- Lấy vai trò hiện tại của người dùng
    SELECT @CurrentRole = dp.name
    FROM sys.database_role_members drm
    JOIN sys.database_principals dp ON drm.role_principal_id = dp.principal_id
    JOIN sys.database_principals u ON drm.member_principal_id = u.principal_id
    WHERE u.name = @Username;

    -- Nếu người dùng đã thuộc vai trò khác, xóa họ khỏi vai trò đó
    IF @CurrentRole IS NOT NULL AND @CurrentRole <> @RoleName
    BEGIN
        DECLARE @Sql NVARCHAR(500);
        SET @Sql = 'EXEC sp_droprolemember ''' + @CurrentRole + ''', ''' + @Username + ''';';
        EXEC sp_executesql @Sql;
    END

    -- Thêm người dùng vào vai trò mới
    DECLARE @AddSql NVARCHAR(500);
    SET @AddSql = 'EXEC sp_addrolemember ''' + @RoleName + ''', ''' + @Username + ''';';
    EXEC sp_executesql @AddSql;
END;
GO

create PROCEDURE SP_CreateUser
    @LoginName NVARCHAR(50),
    @Password NVARCHAR(50),
    @UserName NVARCHAR(50)
AS
BEGIN
    -- Kiểm tra nếu login và user đều không tồn tại
    IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = @LoginName)
       AND NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = @UserName)
    BEGIN
        -- Tạo login
        DECLARE @CreateLogin NVARCHAR(255);
        SET @CreateLogin = N'CREATE LOGIN [' + @LoginName + '] WITH PASSWORD = ''' + @Password + ''', CHECK_POLICY = ON, CHECK_EXPIRATION = OFF';
        EXEC sp_executesql @CreateLogin;

        -- Tạo user cho login
        DECLARE @CreateUser NVARCHAR(255);
        SET @CreateUser = N'CREATE USER [' + @UserName + '] FOR LOGIN [' + @LoginName + ']';
        EXEC sp_executesql @CreateUser;

        -- Thêm user vào role 
        EXEC sp_addrolemember 'Users', @UserName;

        RETURN 1; -- Thành công (1)
    END
    ELSE
    BEGIN
        RETURN 0; -- Không thành công (0)
    END
END;
GO
---------------------------------------------------
CREATE PROCEDURE SP_ThemSach
    @TENSACH NVARCHAR(255),
    @TACGIA NVARCHAR(255),
    @THELOAI NVARCHAR(100),
    @NAMXUATBAN INT,
    @NHAXUATBAN NVARCHAR(255)
AS
BEGIN
    INSERT INTO SACH (TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN)
    VALUES (@TENSACH, @TACGIA, @THELOAI, @NAMXUATBAN, @NHAXUATBAN);
END;
GO

CREATE PROCEDURE SP_ThemDocGia
    @TENDG NVARCHAR(255),
    @DIACHI NVARCHAR(255),
    @DIENTHOAI NVARCHAR(15)
AS
BEGIN
    INSERT INTO DOCGIA (TENDG, DIACHI, DIENTHOAI)
    VALUES (@TENDG, @DIACHI, @DIENTHOAI);
END;
GO

CREATE PROCEDURE SP_ThemNhanVien
    @TENNV NVARCHAR(255),
    @CHUCVU NVARCHAR(100) = N'Nhân viên',
    @DIENTHOAI NVARCHAR(15),
    @NGAYVAOLAM DATE = NULL
AS
BEGIN
    INSERT INTO NHANVIEN (TENNV, CHUCVU, DIENTHOAI, NGAYVAOLAM)
    VALUES (@TENNV, @CHUCVU, @DIENTHOAI, ISNULL(@NGAYVAOLAM, GETDATE()));
END;
GO

CREATE PROCEDURE SP_ThemMuonTra
    @MASACH INT,
    @MADG INT,
    @MANV INT,
    @NGAYMUON DATE = NULL
AS
BEGIN
    INSERT INTO MUONTRA (MASACH, MADG, MANV, NGAYMUON)
    VALUES (@MASACH, @MADG, @MANV, ISNULL(@NGAYMUON, GETDATE()));
END;
GO
----------------------------------------------------
CREATE PROCEDURE SP_CapNhatTonTaiSach
    @MASACH INT
AS
BEGIN
    -- Kiểm tra sách có tồn tại không
    IF EXISTS (SELECT 1 FROM SACH WHERE MASACH = @MASACH AND TONTAI = 1)
    BEGIN
        UPDATE SACH 
        SET TONTAI = 0  -- Cập nhật trạng thái sách thành đã xóa
        WHERE MASACH = @MASACH;
    END
END
GO

CREATE PROCEDURE SP_CapNhatTonTaiNhanVien
    @MANV INT
AS
BEGIN
    -- Kiểm tra nhân viên có tồn tại không
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MANV = @MANV AND TONTAI = 1)
    BEGIN
        UPDATE NHANVIEN 
        SET TONTAI = 0  -- Cập nhật trạng thái nhân viên thành đã xóa
        WHERE MANV = @MANV;
    END
END
GO

CREATE PROCEDURE SP_CapNhatTonTaiDocGia
    @MADG INT
AS
BEGIN
    -- Kiểm tra độc giả có tồn tại không
    IF EXISTS (SELECT 1 FROM DOCGIA WHERE MADG = @MADG AND TONTAI = 1)
    BEGIN
        UPDATE DOCGIA 
        SET TONTAI = 0  -- Cập nhật trạng thái độc giả thành đã xóa
        WHERE MADG = @MADG;
    END
END
GO

CREATE PROCEDURE SP_XoaMuonTra
    @MAMUONTRA INT
AS
BEGIN
    -- Kiểm tra mượn trả có tồn tại không
    IF EXISTS (SELECT 1 FROM MUONTRA WHERE MAMUONTRA = @MAMUONTRA)
    BEGIN
        DELETE FROM MUONTRA 
        WHERE MAMUONTRA = @MAMUONTRA;  -- Xóa bản ghi mượn trả
    END
END
GO
-----------------------------------------------
CREATE PROCEDURE SP_CapNhatSach
    @MASACH INT,
    @TENSACH NVARCHAR(255),
    @TACGIA NVARCHAR(255),
    @THELOAI NVARCHAR(100),
    @NAMXUATBAN INT,
    @NHAXUATBAN NVARCHAR(255)
AS
BEGIN
    --SET NOCOUNT ON;

    UPDATE SACH
    SET 
        TENSACH = @TENSACH,
        TACGIA = @TACGIA,
        THELOAI = @THELOAI,
        NAMXUATBAN = @NAMXUATBAN,
        NHAXUATBAN = @NHAXUATBAN
    WHERE MASACH = @MASACH;

    PRINT N'Cập nhật bảng SACH thành công!'
END;
GO

CREATE PROCEDURE SP_CapNhatDocGia
    @MADG INT,
    @TENDG NVARCHAR(255),
    @DIACHI NVARCHAR(255),
    @DIENTHOAI NVARCHAR(15)
AS
BEGIN
    --SET NOCOUNT ON;

    UPDATE DOCGIA
    SET 
        TENDG = @TENDG,
        DIACHI = @DIACHI,
        DIENTHOAI = @DIENTHOAI
    WHERE MADG = @MADG;

    PRINT 'Cập nhật bảng DOCGIA thành công!'
END;
GO

CREATE PROCEDURE SP_CapNhatNhanVien
    @MANV INT,
    @TENNV NVARCHAR(255),
    @CHUCVU NVARCHAR(100),
    @DIENTHOAI NVARCHAR(15),
    @NGAYVAOLAM DATE
AS
BEGIN
    --SET NOCOUNT ON;

    UPDATE NHANVIEN
    SET 
        TENNV = @TENNV,
        CHUCVU = @CHUCVU,
        DIENTHOAI = @DIENTHOAI,
        NGAYVAOLAM = @NGAYVAOLAM
    WHERE MANV = @MANV;

    PRINT 'Cập nhật bảng NHANVIEN thành công!'
END;
GO

CREATE PROCEDURE SP_CapNhatMuonTra
    @MAMUONTRA INT,
    @MASACH INT,
    @MADG INT,
    @MANV INT,
    @NGAYMUON DATE,
    @NGAYTRA DATE
AS
BEGIN
    --SET NOCOUNT ON;

    UPDATE MUONTRA
    SET 
        MASACH = @MASACH,
        MADG = @MADG,
        MANV = @MANV,
        NGAYMUON = @NGAYMUON,
        NGAYTRA = @NGAYTRA
    WHERE MAMUONTRA = @MAMUONTRA;

    PRINT 'Cập nhật bảng MUONTRA thành công!'
END;
GO

----------------------------------------------------------------------------------
go
--Tạo FUNCTION

CREATE FUNCTION F_CheckUserInRole
(
    @login NVARCHAR(128),  -- Tham số đầu vào: tên login
    @role NVARCHAR(128)    -- Tham số đầu vào: tên vai trò
)
RETURNS NVARCHAR(128)  -- Hàm trả về tên người dùng
AS
BEGIN
    DECLARE @username NVARCHAR(128);

    SELECT @username = u.name  -- Lấy tên người dùng
    FROM sys.database_role_members rm
    JOIN sys.database_principals u ON rm.member_principal_id = u.principal_id
    JOIN sys.server_principals l ON u.sid = l.sid
    WHERE rm.role_principal_id = DATABASE_PRINCIPAL_ID(@role)
      AND l.name = @login;

    RETURN @username;  -- Trả về tên người dùng hoặc NULL
END;
go

CREATE FUNCTION F_GetUserAndRoleByLogin
(
    @LoginName NVARCHAR(255)  -- Tham số đầu vào là tên login
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        dp.name AS UserName,
        drp.name AS RoleName
    FROM 
        sys.database_principals dp
    JOIN 
        sys.database_role_members drm ON dp.principal_id = drm.member_principal_id
    JOIN 
        sys.database_principals drp ON drm.role_principal_id = drp.principal_id
    WHERE 
        dp.SID = (SELECT SID FROM sys.server_principals WHERE name = @LoginName)
        AND dp.type IN ('S', 'U')  -- Chỉ lấy các user có thể đăng nhập
);
GO

--------------------------------------------------------------
CREATE FUNCTION F_GetReadersByBorrowDate(@BorrowDate DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM vw_ThongTinDocGiaMuonSach
    WHERE NGAYMUON = @BorrowDate
);
go

CREATE FUNCTION F_LaySachDuocMuonTrongSoNgay(@SoNgay INT)
RETURNS TABLE
AS
RETURN
(
    SELECT top 10 s.MASACH, s.TENSACH, s.TACGIA, COUNT(mt.MAMUONTRA) AS SoLanMuon
    FROM SACH s
    JOIN MUONTRA mt ON s.MASACH = mt.MASACH
    WHERE @SoNgay > 0 
		  AND mt.NGAYMUON >= DATEADD(DAY, -@SoNgay, GETDATE())  -- Tính ngày bắt đầu
    GROUP BY s.MASACH, s.TENSACH, s.TACGIA
    ORDER BY SoLanMuon DESC  -- Sắp xếp theo số lần mượn giảm dần
);
GO

CREATE FUNCTION F_LayThongTinDocGiaMuonSach(@MASACH INT, @NGAYMUON DATE)
RETURNS TABLE
AS
RETURN (
    SELECT dg.MADG, dg.TENDG, dg.DIACHI, dg.DIENTHOAI, 
			s.MASACH, s.TENSACH, mt.NGAYMUON
    FROM DOCGIA dg
    JOIN MUONTRA mt ON mt.MADG = dg.MADG
    JOIN SACH s ON mt.MASACH = s.MASACH
    WHERE s.MASACH = @MASACH AND mt.NGAYMUON = @NGAYMUON
);
GO

CREATE FUNCTION F_GetReadersByBookType(@THELOAI NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM DOCGIA WHERE MADG IN (
        SELECT MADG FROM MUONTRA WHERE MASACH IN (
            SELECT MASACH FROM SACH WHERE THELOAI = @THELOAI
        )
    )
);
GO

--------------------------------------------------------------
go
--tim kiem sach
CREATE FUNCTION F_LaySachTheoTenSach(@TENSACH NVARCHAR(100))
RETURNS TABLE
AS
RETURN (
    SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN 
    FROM SACH 
    WHERE TENSACH = @TENSACH
);
go

CREATE FUNCTION F_LaySachTheoTheLoai(@THELOAI NVARCHAR(100))
RETURNS TABLE
AS
RETURN (
    SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN 
    FROM SACH 
    WHERE THELOAI = @THELOAI
);
GO

CREATE FUNCTION F_LaySachTheoTacGia(@TACGIA NVARCHAR(100))
RETURNS TABLE
AS
RETURN (
    SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN 
    FROM SACH 
    WHERE TACGIA = @TACGIA
);

go

CREATE FUNCTION F_LaySachTheoNamXuatBan(@NAMXUATBAN INT)
RETURNS TABLE
AS
RETURN (
    SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN 
    FROM SACH 
    WHERE NAMXUATBAN = @NAMXUATBAN
);
go

CREATE FUNCTION F_LaySachTheoNhaXuatBan(@NHAXUATBAN NVARCHAR(100))
RETURNS TABLE
AS
RETURN (
    SELECT MASACH, TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN 
    FROM SACH 
    WHERE NHAXUATBAN = @NHAXUATBAN
);
go

--------------------------------------------------------------
go
--Quá trình làm
go
--DECLARE @sqlport NVARCHAR(5)
--EXEC xp_instance_regread 
--    N'HKEY_LOCAL_MACHINE', 
--    N'Software\Microsoft\Microsoft SQL Server\MSSQLServer\SuperSocketNetLib\Tcp\IPAll', 
--    N'TcpPort', 
--    @sqlport OUTPUT
--SELECT ISNULL(@sqlport, 'Cổng mặc định 1433') AS SQLServerPort
go

--SELECT * FROM syslogins 
--WHERE name = 'ql_tv'
go

create FUNCTION dbo.fn_GetActiveUsers()
RETURNS TABLE
AS
RETURN
(
    SELECT p.name 
    FROM sys.database_principals p
    WHERE p.type IN ('S', 'U')  -- Loại người dùng: SQL login và Windows login
      AND p.name NOT IN ('dbo', 'guest', 'sys', 'INFORMATION_SCHEMA')  -- Loại bỏ các người dùng hệ thống
);
go
SELECT * FROM dbo.fn_GetActiveUsers();

go

drop PROCEDURE sp_GrantPermissionsAndUpdate
    @UserName NVARCHAR(255),  -- Tên người dùng
    @QuyenSelect BIT = null,         -- Quyền SELECT
    @QuyenInsert BIT = null,         -- Quyền INSERT
    @QuyenAll BIT = null          
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra người dùng có tồn tại trong cơ sở dữ liệu không
        IF NOT EXISTS (
            SELECT 1
            FROM sys.database_principals
            WHERE name = @UserName AND type IN ('S', 'U', 'G')
        )
        BEGIN
            print 'Người dùng không tồn tại trong cơ sở dữ liệu.';
        END

        -- Gán quyền SELECT
        IF @QuyenSelect = 1
        BEGIN
			GRANT SELECT ON SCHEMA::dbo to [@UserName];
        END

        -- Gán quyền INSERT
        IF @QuyenInsert = 1
        BEGIN
			GRANT INSERT ON SCHEMA::dbo to [@UserName];
        END

        IF @QuyenAll = 1
		begin
			DECLARE @sql NVARCHAR(MAX);
			SET @sql = N'ALTER ROLE FullAccessRole ADD MEMBER [' + @UserName + N'];';
			EXEC sp_executesql @sql;
		end

        -- Cập nhật bảng QuyenNguoiDung
        IF EXISTS (SELECT 1 FROM QuyenNguoiDung WHERE UserName = @UserName)
        BEGIN
            UPDATE QuyenNguoiDung
            SET 
                QuyenSelect = @QuyenSelect,
                QuyenInsert = @QuyenInsert,
                QuyenAll = @QuyenAll
            WHERE UserName = @UserName;
        END
        ELSE
        BEGIN
            INSERT INTO QuyenNguoiDung (UserName, QuyenSelect, QuyenInsert, QuyenAll)
            VALUES (@UserName, @QuyenSelect, @QuyenInsert, @QuyenAll);
        END

        PRINT 'Quyền đã được gán và cập nhật thành công.';
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi
        PRINT 'Đã xảy ra lỗi: ' + ERROR_MESSAGE();
        RETURN;
    END CATCH
END
GO

create ROLE FullAccessRole;
GO

GRANT CONTROL ON DATABASE::[ql_tv] TO FullAccessRole;
GO

create PROCEDURE sp_RemoveUserFromDatabase
    @UserName NVARCHAR(255)  -- Tên người dùng cần xóa
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra người dùng có tồn tại trong cơ sở dữ liệu không
        IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @UserName)
        BEGIN
            PRINT 'Người dùng không tồn tại trong cơ sở dữ liệu.';
            RETURN;
        END

        -- Kiểm tra người dùng có tồn tại trong bảng QuyenNguoiDung không
        IF EXISTS (SELECT 1 FROM QuyenNguoiDung WHERE UserName = @UserName)
        BEGIN
            -- Xóa quyền người dùng trong bảng QuyenNguoiDung
            DELETE FROM QuyenNguoiDung WHERE UserName = @UserName;
            PRINT 'Quyền người dùng đã được xóa khỏi bảng QuyenNguoiDung.';
        END

        -- Xóa người dùng khỏi cơ sở dữ liệu
		DECLARE @sql NVARCHAR(MAX);
		SET @sql = N'DROP USER ' + QUOTENAME(@UserName);
		EXEC sp_executesql @sql;

        PRINT 'Người dùng đã bị xóa thành công khỏi cơ sở dữ liệu và quyền đăng nhập đã bị thu hồi.';
    END TRY
    BEGIN CATCH
        PRINT 'Đã xảy ra lỗi: ' + ERROR_MESSAGE();
        RETURN;
    END CATCH
END
go

create PROCEDURE sp_TaoUser
    @UserName NVARCHAR(255)  -- Tên người dùng cần tạo
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra người dùng có tồn tại hay không
        IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @UserName)
        BEGIN
            PRINT 'Người dùng đã tồn tại.';
            RETURN;
        END

        -- Tạo người dùng mà không cần login
        DECLARE @sql NVARCHAR(MAX);
		SET @sql = N'CREATE USER ' + QUOTENAME(@UserName) + ' WITHOUT LOGIN;';
		EXEC sp_executesql @sql;

        PRINT 'Người dùng đã được tạo thành công.';
    END TRY
    BEGIN CATCH
        PRINT 'Đã xảy ra lỗi: ' + ERROR_MESSAGE();
        RETURN;
    END CATCH
END
go

CREATE TRIGGER trg_AfterInsertGrantPermissions
ON QuyenNguoiDung
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến lưu trữ thông tin người dùng và quyền
    DECLARE @UserName NVARCHAR(255);
    DECLARE @QuyenSelect BIT;
    DECLARE @QuyenInsert BIT;
    DECLARE @QuyenAll BIT;

    -- Lấy thông tin từ bảng inserted (cập nhật sau khi thay đổi)
    SELECT 
        @UserName = UserName,
        @QuyenSelect = QuyenSelect,
        @QuyenInsert = QuyenInsert,
        @QuyenAll = QuyenAll
    FROM inserted;

    -- Gọi stored procedure để cấp quyền
    EXEC sp_GrantOrRevokePermissions 
        @UserName,
        @QuyenSelect, NULL,
        @QuyenInsert, NULL,
        @QuyenAll, NULL;
END;
go

CREATE TRIGGER trg_AfterUpdateGrantPermissions
ON QuyenNguoiDung
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến lưu trữ thông tin người dùng và quyền
    DECLARE @UserName NVARCHAR(255);
    DECLARE @QuyenSelect BIT;
    DECLARE @QuyenInsert BIT;
    DECLARE @QuyenAll BIT;

    -- Biến lưu trữ quyền cũ
    DECLARE @OldQuyenSelect BIT;
    DECLARE @OldQuyenInsert BIT;
    DECLARE @OldQuyenAll BIT;

    -- Lấy thông tin từ bảng deleted (quyền cũ)
    SELECT 
        @OldQuyenSelect = QuyenSelect,
        @OldQuyenInsert = QuyenInsert,
        @OldQuyenAll = QuyenAll
    FROM deleted;

    -- Lấy thông tin từ bảng inserted (quyền mới)
    SELECT 
        @UserName = UserName,
        @QuyenSelect = QuyenSelect,
        @QuyenInsert = QuyenInsert,
        @QuyenAll = QuyenAll
    FROM inserted;

    -- Gọi stored procedure để xử lý cấp hoặc thu hồi quyền
    EXEC sp_GrantOrRevokePermissions 
        @UserName,
        @QuyenSelect, @OldQuyenSelect,
        @QuyenInsert, @OldQuyenInsert,
        @QuyenAll, @OldQuyenAll;
END;
go

alter PROCEDURE sp_GrantOrRevokePermissions
    @UserName NVARCHAR(255),
    @QuyenSelect BIT,
    @OldQuyenSelect BIT,
    @QuyenInsert BIT,
    @OldQuyenInsert BIT,
    @QuyenAll BIT,
    @OldQuyenAll BIT
AS
BEGIN
    -- Kiểm tra và thay đổi quyền SELECT nếu có thay đổi và không phải NULL
    IF @QuyenSelect IS NOT NULL AND @QuyenSelect != @OldQuyenSelect
    BEGIN
        IF @QuyenSelect = 1
        BEGIN
            EXEC('GRANT SELECT ON SCHEMA::dbo TO [' + @UserName + ']');
        END
        ELSE
        BEGIN
            EXEC('REVOKE SELECT ON SCHEMA::dbo FROM [' + @UserName + ']');
        END
    END

    -- Kiểm tra và thay đổi quyền INSERT nếu có thay đổi và không phải NULL
    IF @QuyenInsert IS NOT NULL AND @QuyenInsert != @OldQuyenInsert
    BEGIN
        IF @QuyenInsert = 1
        BEGIN
            EXEC('GRANT INSERT ON SCHEMA::dbo TO [' + @UserName + ']');
        END
        ELSE
        BEGIN
            EXEC('REVOKE INSERT ON SCHEMA::dbo FROM [' + @UserName + ']');
        END
    END

    -- Kiểm tra và thay đổi quyền ALL nếu có thay đổi và không phải NULL
    IF @QuyenAll IS NOT NULL AND @QuyenAll != @OldQuyenAll
    BEGIN
        IF @QuyenAll = 1
        BEGIN
            EXEC('ALTER ROLE FullAccessRole ADD MEMBER [' + @UserName + ']');
            EXEC('ALTER ROLE Users DROP MEMBER [' + @UserName + ']');
        END
        ELSE
        BEGIN
            EXEC('ALTER ROLE FullAccessRole DROP MEMBER [' + @UserName + ']');
            EXEC('ALTER ROLE Users ADD MEMBER [' + @UserName + ']');
        END
    END
END;
go

CREATE PROCEDURE sp_AddOrUpdateUserPermissions
    @UserName NVARCHAR(255),  -- Tên người dùng
    @QuyenSelect BIT = null,   -- Quyền SELECT
    @QuyenInsert BIT = null,   -- Quyền INSERT
    @QuyenAll BIT = null       -- Quyền ALL
AS
BEGIN
    BEGIN TRY
		-- Kiểm tra người dùng có tồn tại trong cơ sở dữ liệu không
        IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @UserName AND type IN ('S', 'U', 'G'))
        BEGIN
            PRINT 'Người dùng không tồn tại trong cơ sở dữ liệu.';
            RETURN;
        END

        -- Kiểm tra người dùng có tồn tại trong bảng QuyenNguoiDung không
        IF EXISTS (SELECT 1 FROM QuyenNguoiDung WHERE UserName = @UserName)
        BEGIN
            -- Nếu người dùng đã tồn tại thì thực hiện cập nhật quyền
            UPDATE QuyenNguoiDung
            SET 
                QuyenSelect = ISNULL(@QuyenSelect, QuyenSelect),  -- Cập nhật quyền SELECT nếu có
                QuyenInsert = ISNULL(@QuyenInsert, QuyenInsert),  -- Cập nhật quyền INSERT nếu có
                QuyenAll = ISNULL(@QuyenAll, QuyenAll)           -- Cập nhật quyền ALL nếu có
            WHERE UserName = @UserName;

            PRINT 'Quyền của người dùng đã được cập nhật.';
        END
        ELSE
        BEGIN
            -- Nếu người dùng chưa tồn tại thì thực hiện thêm mới quyền
            INSERT INTO QuyenNguoiDung (UserName, QuyenSelect, QuyenInsert, QuyenAll)
            VALUES (@UserName, @QuyenSelect, @QuyenInsert, @QuyenAll);

            PRINT 'Quyền của người dùng đã được thêm mới.';
        END
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi nếu có
        PRINT 'Đã xảy ra lỗi: ' + ERROR_MESSAGE();
        RETURN;
    END CATCH
END
go

create PROCEDURE SP_DeleteOrUpdateBooks
    @MASACH_LIST NVARCHAR(MAX) -- Danh sách mã sách cần xóa, cách nhau bằng dấu phẩy
AS
BEGIN
    -- Bắt đầu transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Tạo bảng tạm để chứa danh sách mã sách
        DECLARE @MASACH_TABLE TABLE (MASACH INT);

        -- Tách danh sách mã sách và chèn vào bảng tạm
        INSERT INTO @MASACH_TABLE (MASACH)
        SELECT value FROM STRING_SPLIT(@MASACH_LIST, ',');

        -- Duyệt từng mã sách trong bảng tạm
        DECLARE @MASACH INT;

        DECLARE product_cursor CURSOR FOR
        SELECT MASACH FROM @MASACH_TABLE;

        OPEN product_cursor;
        FETCH NEXT FROM product_cursor INTO @MASACH;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Kiểm tra xem sản phẩm có tham chiếu trong MUONTRA không (ngày trả là NULL)
            IF EXISTS (SELECT 1 FROM MUONTRA WHERE MASACH = @MASACH)
            BEGIN
                -- Nếu có tham chiếu trong MUONTRA (sách chưa trả), cập nhật trạng thái sản phẩm thành 0
                UPDATE SACH
                SET TONTAI = 0
                WHERE MASACH = @MASACH;
            END
            ELSE
            BEGIN
                -- Nếu không có tham chiếu trong MUONTRA, xóa sản phẩm khỏi bảng SACH
                DELETE FROM SACH WHERE MASACH = @MASACH;
            END

            FETCH NEXT FROM product_cursor INTO @MASACH;
        END

        CLOSE product_cursor;
        DEALLOCATE product_cursor;

        -- Commit transaction nếu tất cả các thao tác thành công
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback transaction nếu có lỗi
        ROLLBACK TRANSACTION;
        -- In thông báo lỗi ra màn hình
        THROW;
    END CATCH;
END;
