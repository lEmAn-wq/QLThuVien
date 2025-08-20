use ql_tv
go

INSERT INTO SACH (TENSACH, TACGIA, THELOAI, NAMXUATBAN, NHAXUATBAN)
VALUES
	(N'Khoa học vũ trụ', N'Stephen Hawking', N'Khoa học', 2016, N'Nhà xuất bản Thế giới'),
	(N'Người dơi', N'Philip Pullman', N'Tâm lý', 2015, N'Nhà xuất bản Văn học'),
	(N'Giáo dục toàn diện', N'Trần Đình Hưng', N'Giáo dục', 2020, N'Nhà xuất bản Giáo dục'),
	(N'Lịch sử Việt Nam', N'Nguyễn Quang Thạch', N'Lịch sử', 2018, N'Nhà xuất bản Chính trị Quốc gia'),
	(N'Những cuộc phiêu lưu của Tom Sawyer', N'Mark Twain', N'Thiếu nhi', 1876, N'Nhà xuất bản Kim Đồng'),
	(N'Tôi thấy hoa vàng trên cỏ xanh', N'Nguyễn Nhật Ánh', N'Tiểu thuyết', 2015, N'Nhã Nam'),
	(N'Đắc nhân tâm', N'Dale Carnegie', N'Tự truyện', 1936, N'Đông A'),
	(N'Triệu phú ổ chuột', N'Vikas Swarup', N'Tiểu thuyết', 2005, N'NXB Trẻ'),
	(N'Sống để yêu thương', N'Nguyễn Ngọc Tư', N'Tiểu thuyết', 2008, N'Nhã Nam'),
	(N'Khi hơi thở hóa thinh không', N'Nguyễn Bính', N'Tiểu thuyết', 2004, N'NXB Hội Nhà Văn');
GO

INSERT INTO DOCGIA (TENDG, DIACHI, DIENTHOAI)
VALUES 
	(N'Nguyễn Văn A', N'123 Đường A, Quận 1, TP.HCM', '0123456789'),
	(N'Trần Thị B', N'456 Đường B, Quận 2, TP.HCM', '0987654321'),
	(N'Lê Văn C', N'789 Đường C, Quận 3, TP.HCM', '0912345678'),
	(N'Phạm Thị D', N'321 Đường D, Quận 4, TP.HCM', '0981234567'),
	(N'Tôn Thất E', N'654 Đường E, Quận 5, TP.HCM', '0909876543');
GO

INSERT INTO NHANVIEN (TENNV, CHUCVU, DIENTHOAI, NGAYVAOLAM)
VALUES 
    (N'Nguyễn Văn D', N'Quản lý', '0122334455', '2023-01-15'),
    (N'Trần Thị E', default, '0223344556', DEFAULT),
    (N'Phạm Văn F', default, '0334455667', '2023-02-20'),
    (N'Phạm Văn N', default, '0123456780', '2023-03-10'),
    (N'Tôn Thất O', default, '0987654300', '2023-04-05'),
    (N'Hồ Thị P', default, '0912345600', '2023-05-15');
GO

INSERT INTO MUONTRA (MASACH, MADG, MANV, NGAYMUON, NGAYTRA)
VALUES
	(1, 1, 1, '2024-09-01', '2024-09-15'),
	(2, 2, 2, '2024-09-05', NULL),
	(3, 3, 3, '2024-09-10', '2024-09-20'),
	(4, 4, 1, '2024-09-12', NULL),
	(5, 5, 2, '2024-09-15', NULL),
	(6, 1, 3, '2024-09-18', '2024-09-25');
GO

------------------------------------------------------------------------------------------------------------
go

exec SP_AddUserToRole '11','Users'
go

select * from F_GetUserAndRoleByLogin('99')
go
 --Thêm user vào role 
ALTER ROLE NhanVien ADD MEMBER [1];
ALTER ROLE users ADD MEMBER [3];
go

select * from vw_sachcontontai
select * from vw_nhanviencontontai
select * from vw_docgiacontontai
select * from MUONTRA
select * from sach

select * from vw_DocGiaMuonNhieuNhat
select * from vw_SachDuocMuonNhieuNhat

go

--test bcp
exec sp_ImportDataWithBCP 'vw_import_NHANVIEN','C:\Users\Admin\Desktop\nhanvien.csv'
exec sp_ExportDataWithBCP 'vw_NhanVienConTonTaiVaCot','C:\Users\Admin\Desktop\nhanvien.csv'
yyyy-mm-dd hh:mm:ss
