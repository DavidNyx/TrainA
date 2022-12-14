CREATE DATABASE TRAINA
GO

USE TRAINA
GO

CREATE TABLE NHANVIEN
(
	MA_NV INT,
	TEN_NV NVARCHAR(30) NOT NULL,
	NGAYSINH DATE NOT NULL,
	GIOITINH BIT NOT NULL, --0 LÀ NAM, 1 LÀ NỮ
	MATKHAU VARCHAR(30) NOT NULL,
	VAITRO NVARCHAR(20),
	MA_VITRI INT NOT NULL, --FK
	MA_PHONGBAN INT NOT NULL, --FK
	MA_TRINHDO INT NOT NULL, --FK
	CONSTRAINT PK_NV PRIMARY KEY(MA_NV),
	CONSTRAINT CONS_VAITRO CHECK(VAITRO IN(N'Admin', N'Quản lý', N'Trainer', N'Trainee', NULL))
)
GO

CREATE TABLE VITRI
(
	MA_VT INT,
	TEN_VT NVARCHAR(30) NOT NULL,
	MOTA NVARCHAR(1000),
	CONSTRAINT PK_VT PRIMARY KEY(MA_VT)
)
GO

CREATE TABLE TRINHDO
(
	MA_TD INT,
	TEN_TD NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_TD PRIMARY KEY(MA_TD)
)
GO

CREATE TABLE PHONGBAN
(
	MA_PB INT,
	TEN_PB NVARCHAR(30) NOT NULL,
	MOTA NVARCHAR(100),
	CONSTRAINT PK_PB PRIMARY KEY(MA_PB)
)
GO

CREATE TABLE DUAN
(
	MA_DA INT,
	TEN_DA NVARCHAR(30) NOT NULL,
	NGAYBATDAU DATE,
	NGAYKETTHUC DATE,
	NOIDUNG NVARCHAR(1000),
	CONSTRAINT PK_DA PRIMARY KEY(MA_DA)
)
GO

CREATE TABLE KINANG
(
	MA_KN INT,
	TEN_KN NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_KN PRIMARY KEY(MA_KN)
)
GO

CREATE TABLE KIENTHUC
(
	MA_KT INT,
	TEN_KT NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_KT PRIMARY KEY(MA_KT)
)
GO

CREATE TABLE LOPHOC
(
	MA_LH INT,
	TEN_LH NVARCHAR(30) NOT NULL,
	MA_VITRI INT, --FK
	TG_BATDAU DATE NOT NULL,
	TG_KETHUC DATE,
	CONSTRAINT PK_LH PRIMARY KEY(MA_LH)
)
GO

CREATE TABLE KHOAHOC
(
	MA_KH INT,
	TEN_KH NVARCHAR(30) NOT NULL,
	MUCTIEU NVARCHAR(100),
	HINH_THUC BIT NOT NULL, --0 LÀ OFFLINE, 1 LÀ ONLINE
	GHI_CHU NVARCHAR(100),
	CONSTRAINT PK_KH PRIMARY KEY(MA_KH)
)
GO

CREATE TABLE NOIDUNG
(
	MA_ND INT,
	TEN_ND NVARCHAR(30) NOT NULL,
	THOILUONG INT NOT NULL,
	MUCTIEU NVARCHAR(100),
	MA_KHOAHOC INT, --FK
	CONSTRAINT PK_ND PRIMARY KEY(MA_ND)
)
GO

CREATE TABLE TAILIEU
(
	MA_TL INT,
	TEN_TL NVARCHAR(20) NOT NULL,
	NOIDUNG_TL NVARCHAR(100) NOT NULL,
	MA_NOIDUNG INT NOT NULL, --FK
	CONSTRAINT PK_TL PRIMARY KEY(MA_TL)
)
GO

CREATE TABLE DEBAI
(
	MA_DB INT,
	TEN_DB NVARCHAR(30) NOT NULL,
	LOAI_DB BIT NOT NULL, --0 LÀ BT, 1 LÀ ĐỀ THI
	CONSTRAINT PK_DB PRIMARY KEY(MA_DB)
)
GO

CREATE TABLE DETULUAN
(
	MA_DTL INT,
	CAUHOI_TL NVARCHAR(200) NOT NULL,
	DAPAN NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_DTL PRIMARY KEY(MA_DTL)
)
GO

CREATE TABLE DETRACNGHIEM
(
	MA_DTN INT,
	CAUHOI_TN NVARCHAR(200) NOT NULL,
	DAPAN1 NVARCHAR(50) NOT NULL,
	DAPAN2 NVARCHAR(50) NOT NULL,
	DAPAN3 NVARCHAR(50) NOT NULL,
	DAPAN4 NVARCHAR(50) NOT NULL,
	DAPANDUNG INT NOT NULL,
	CONSTRAINT PK_DTN PRIMARY KEY(MA_DTN)
)
GO

CREATE TABLE PHANHOI
(
	MA_PH INT,
	MA_NOIDUNG INT, --FK
	MA_NGUOIPHANHOI INT, --FK
	NOIDUNG_PHANHOI NVARCHAR(200),
	CONSTRAINT PK_PH PRIMARY KEY(MA_PH, MA_NOIDUNG)
)
GO

CREATE TABLE CHITIET_NV_KN
(
	MA_NV INT,
	MA_KN INT,
	CONSTRAINT PK_CT_NV_KN PRIMARY KEY(MA_NV, MA_KN)
)
GO

CREATE TABLE CHITIET_NV_KT
(
	MA_NV INT,
	MA_KT INT,
	CONSTRAINT PK_CT_NV_KT PRIMARY KEY(MA_NV, MA_KT)
)
GO

CREATE TABLE CHITIET_NV_KH
(
	MA_NV INT,
	MA_KH INT,
	DANHGIA CHAR(4),
	CONSTRAINT PK_CT_NV_KH PRIMARY KEY(MA_NV, MA_KH),
	CONSTRAINT CONS_DANHGIA CHECK(DANHGIA IN('PASS', 'FAIL'))
)
GO

CREATE TABLE CHITIET_LH_KH
(
	MA_LH INT,
	MA_KH INT,
	MA_GIANGVIEN INT NOT NULL, --FK
	CONSTRAINT PK_CT_LH_KH PRIMARY KEY(MA_LH, MA_KH)
)
GO

CREATE TABLE CHITIET_LH_NV
(
	MA_LH INT,
	MA_TRAINEE INT,
	DANHGIA BIT, --NULL LÀ CHƯA ĐÁNH GIÁ, 0 LÀ FAIL, 1 LÀ PASS
	CONSTRAINT PK_CT_LH_NV PRIMARY KEY(MA_LH, MA_TRAINEE)
)
GO

CREATE TABLE CHITIET_LH_KH_NV
(
	MA_LH INT,
	MA_KH INT,
	MA_TRAINEE INT,
	COTDIEM_BT1 FLOAT,
	COTDIEM_BT2 FLOAT,
	COTDIEM_BT3 FLOAT,
	COTDIEM_BT4 FLOAT,
	COTDIEM_BT5 FLOAT,
	COTDIEM_BT6 FLOAT,
	COTDIEM_BT7 FLOAT,
	COTDIEM_BT8 FLOAT,
	COTDIEM_BT9 FLOAT,
	COTDIEM_BT10 FLOAT,
	COTDIEM_THI FLOAT,
	CONSTRAINT PK_CT_LH_KH_NV PRIMARY KEY(MA_LH, MA_KH, MA_TRAINEE)
)
GO

CREATE TABLE CHITIET_KH_KN
(
	MA_KH INT,
	MA_KN INT,
	CONSTRAINT PK_CT_KH_KN PRIMARY KEY(MA_KH, MA_KN)
)
GO

CREATE TABLE CHITIET_KH_KT
(
	MA_KH INT,
	MA_KT INT,
	CONSTRAINT PK_CT_KH_KT PRIMARY KEY(MA_KH, MA_KT)
)
GO

CREATE TABLE CHITIET_KH_VT
(
	MA_KH INT,
	MA_VT INT,
	CONSTRAINT PK_CT_KH_VT PRIMARY KEY(MA_KH, MA_VT)
)
GO

CREATE TABLE CHITIET_VT_KN
(
	MA_VT INT,
	MA_KN INT,
	CONSTRAINT PK_CT_VT_KN PRIMARY KEY(MA_VT, MA_KN)
)
GO

CREATE TABLE CHITIET_VT_KT
(
	MA_VT INT,
	MA_KT INT,
	CONSTRAINT PK_CT_VT_KT PRIMARY KEY(MA_VT, MA_KT)
)
GO

CREATE TABLE CHITIET_PB_KN
(
	MA_PB INT,
	MA_KN INT,
	CONSTRAINT PK_CT_PB_KN PRIMARY KEY(MA_PB, MA_KN)
)
GO

CREATE TABLE CHITIET_PB_KT
(
	MA_PB INT,
	MA_KT INT,
	CONSTRAINT PK_CT_PB_KT PRIMARY KEY(MA_PB, MA_KT)
)
GO

CREATE TABLE CHITIET_DA_KN
(
	MA_DA INT,
	MA_KN INT,
	CONSTRAINT PK_CT_DA_KN PRIMARY KEY(MA_DA, MA_KN)
)
GO

CREATE TABLE CHITIET_DA_KT
(
	MA_DA INT,
	MA_KT INT,
	CONSTRAINT PK_CT_DA_KT PRIMARY KEY(MA_DA, MA_KT)
)
GO

CREATE TABLE CHITIET_DA_NV
(
	MA_DA INT,
	MA_NV INT,
	CONSTRAINT PK_CT_DA_NV PRIMARY KEY(MA_DA, MA_NV)
)
GO

CREATE TABLE CHITIET_DB_DTL
(
	MA_DB INT,
	MA_DTL INT,
	CONSTRAINT PK_CT_DB_DTL PRIMARY KEY(MA_DB, MA_DTL)
)
GO

CREATE TABLE CHITIET_DB_DTN
(
	MA_DB INT,
	MA_DTN INT,
	CONSTRAINT PK_CT_DB_DTN PRIMARY KEY(MA_DB, MA_DTN)
)
GO