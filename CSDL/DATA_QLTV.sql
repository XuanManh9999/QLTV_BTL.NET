﻿CREATE DATABASE QUANLYTHUVIEN
USE QUANLYTHUVIEN
CREATE TABLE QUANLY(
	MAQL VARCHAR(20) PRIMARY KEY, TENQL NVARCHAR(50), NGAYSINH CHAR(20), DIACHI NVARCHAR(50), SDT CHAR(20)  
)
select * from QUANLY
INSERT INTO QUANLY VALUES('QL001', N'TRẦN QUANG MINH', '29/09/2003', N'HÀ NỘI', '0352593469')
CREATE TABLE SINHVIEN(
	MASV VARCHAR(20) PRIMARY KEY, TENSV NVARCHAR(50), NGAYSINH CHAR(20), DIACHI NVARCHAR(50), SDT CHAR (10), LOP CHAR(20), TIEN float)
INSERT INTO SINHVIEN VALUES('SV001', N'NGUYỄN XUÂN MANH', '29/03/2003', N'BA VÌ HÀ NỘI', '0352593455', 'DCCNTT12.10.3', 10.5);
select * from SINHVIEN
CREATE TABLE QLSV(
	MAQL VARCHAR(20) FOREIGN KEY REFERENCES QUANLY(MAQL) ,
	MASV VARCHAR (20) FOREIGN KEY REFERENCES SINHVIEN(MASV),
	PRIMARY KEY (MAQL, MASV)
)
-- BẢN MƯỢN
CREATE TABLE SACH (
	MASACH VARCHAR(20) PRIMARY KEY, TENSACH NVARCHAR(50), SOTIEN FLOAT, LOAISACH NVARCHAR(50)
)
INSERT INTO SACH VALUES('', N'', 1,N'')
-- LIÊN KẾT VỚI SINH VIÊN
CREATE TABLE MUON (
	MASV VARCHAR(20) FOREIGN KEY REFERENCES SINHVIEN(MASV),
	MASACH VARCHAR (20)FOREIGN KEY REFERENCES SACH(MASACH),
	NGAYMUON VARCHAR(30)
	PRIMARY KEY (MASV, MASACH)
)
--LIÊN KẾT QUẢN LÝ VỚI SÁCH
CREATE TABLE QLSACH (
	MASACH VARCHAR(20) FOREIGN KEY REFERENCES SACH(MASACH),
	MAQL VARCHAR(20) FOREIGN KEY REFERENCES QUANLY (MAQL)
	PRIMARY KEY (MASACH, MAQL)
)
-- TÀI KHOẢN
CREATE TABLE TAIKHOAN(
	MATK VARCHAR(20) PRIMARY KEY, TENTK NVARCHAR(50), MATKHAU CHAR(20), MASV VARCHAR(20) FOREIGN KEY REFERENCES SINHVIEN(MASV) 
)
insert into TAIKHOAN values ('TK001', 'XUANMANH9999', '123', 'SV001')
-- QLTK 
CREATE TABLE QLTK (
	MATK VARCHAR(20) FOREIGN KEY REFERENCES TAIKHOAN(MATK),
	MAQL VARCHAR (20) FOREIGN KEY REFERENCES QUANLY(MAQL)
)
select * from SINHVIEN
-----------------------------------------------------------ĐOẠN TRUY VẤN--------------------------------------------------
select MATK from TAIKHOAN
insert into TAIKHOAN values ('TK002', 'Nguyễn Xuân Mạnh', '', '')
select * from SINHVIEN
INSERT INTO SINHVIEN VALUES('SV001', N'NGUYỄN XUÂN MANH', '29/03/2003', N'BA VÌ HÀ NỘI', '0352593455', 'DCCNTT12.10.3', 10.5);
select * from TAIKHOAN