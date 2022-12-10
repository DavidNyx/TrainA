USE TRAINA
GO

DELETE FROM NHANVIEN
DELETE FROM VITRI
DELETE FROM PHONGBAN
DELETE FROM DUAN
DELETE FROM KINANG
DELETE FROM KIENTHUC
DELETE FROM CHITIET_NV_KN
DELETE FROM CHITIET_NV_KT
DELETE FROM CHITIET_VT_KN
DELETE FROM CHITIET_VT_KT
DELETE FROM CHITIET_PB_KN
DELETE FROM CHITIET_PB_KT
DELETE FROM CHITIET_DA_KN
DELETE FROM CHITIET_DA_KT
DELETE FROM CHITIET_DA_NV

INSERT NHANVIEN
VALUES
(1, N'Nguyễn Văn A', '2001-01-01', 0, '12345', N'Admin', 1, 1),
(2, N'Lê Hoàng B', '2001-02-02', 0, 'asdfg', N'Admin', 1, 2),
(3, N'Nguyễn Xuân C', '2001-03-03', 1, '12345', N'Admin', 1, 2),
(4, N'Trần Ngọc D', '2001-04-04', 1, '12345', N'Admin', 1, 3),
(5, N'Hoàng Quốc E', '2001-05-05', 0, '12345', N'Quản lý', 2, 1),
(6, N'Lý Đình Thiên F', '2001-06-06', 1, '12345', N'Quản lý', 2, 2),
(7, N'Lê Thành G', '2001-07-07', 0, '12345', N'Quản lý', 2, 3),
(8, N'Nguyễn Trần Linh H', '2001-08-08', 1, '12345', N'Trainer', 1, 1),
(9, N'Vũ Hoàng I', '2001-09-09', 1, '12345', N'Trainer', 1, 2),
(10, N'Trần Lê Thiên J', '2001-10-10', 1, '12345', N'Trainer', 1, 3),
(11, N'Nguyễn Kim K', '2001-11-11', 0, '12345', N'Trainer', 1, 4),
(12, N'Nguyễn Hoàng Minh L', '2001-12-12', 0, '12345', N'Trainer', 1, 5),
(13, N'Trần M', '2001-01-13', 0, '12345', N'Trainee', 3, 1),
(14, N'Lê Minh N', '2001-02-14', 0, '12345', N'Trainee', 4, 1),
(15, N'Hoàng Lê O', '2001-03-15', 1, '12345', N'Trainee', 6, 1),
(16, N'Lý P', '2001-04-16', 0, '12345', N'Trainee', 3, 2),
(17, N'Trần Thị Q', '2001-05-17', 1, '12345', N'Trainee', 4, 2),
(18, N'Nguyễn Chiến R', '2001-06-18', 0, '12345', N'Trainee', 6, 2),
(19, N'Nguyễn Phương S', '2001-07-19', 0, '12345', N'Trainee', 5, 2),
(20, N'Nguyễn T', '2001-08-20', 1, '12345', N'Trainee', 4, 2),
(21, N'Lê Thiên U', '2001-09-21', 0, '12345', N'Trainee', 6, 2),
(22, N'Lý Minh V', '2001-10-22', 1, '12345', N'Trainee', 5, 3),
(23, N'Trần Lai W', '2001-11-23', 1, '12345', N'Trainee', 3, 3),
(24, N'Trần X', '2001-12-24', 1, '12345', N'Trainee', 3, 3),
(25, N'Lê An Y', '2001-01-25', 1, '12345', N'Trainee', 4, 3),
(26, N'Lê Linh Z', '2001-02-26', 1, '12345', N'Trainee', 6, 3)

INSERT VITRI
VALUES
(1, N'Senior Developer'),
(2, N'Sennior Marketing'),
(3, N'Developer'),
(4, N'BA'),
(5, N'UI Designer'),
(6, N'HR'),
(7, N'Thư ký'),
(8, N'Thực tập sinh')

INSERT PHONGBAN
VALUES
(1, N'Công nghệ thông tin', N'Làm việc liên quan đến công nghệ thông tin'),
(2, N'Nhân sự', N'Làm việc liên quan đến nhân sự'),
(3, N'Kế toán', N'Làm việc liên quan đến kế toán'),
(4, N'Kinh doanh', N'Làm việc liên quan đến kinh doanh'),
(5, N'Marketing', N'Làm việc liên quan đến marketing')

INSERT DUAN
VALUES
(1, N'Dự án 1', '2022-01-01', '2023-01-01', N'Nội dung gì đó không biết nữa...'),
(2, N'Dự án 2', '2022-02-02', '2023-02-02', N'Cũng không biết viết nội dung gì luôn...'),
(3, N'Dự án 3', '2022-03-03', '2023-03-03', N'Cái này cũng không biết viết nội dung gì...')

INSERT KINANG
VALUES
(1, N'Kĩ năng giao tiếp'),
(2, N'Kĩ năng thuyết trình'),
(3, N'Kĩ năng xử lý tình huống'),
(4, N'Kĩ năng lập kế hoạch'),
(5, N'Kĩ năng đàm phán')

INSERT KIENTHUC
VALUES
(1, N'Tin học văn phòng'),
(2, N'C++'),
(3, N'SQL'),
(4, N'Java'),
(5, N'Python'),
(6, N'Tính sổ sách'),
(7, N'Marketing truyền thống'),
(8, N'Marketing điện tử'),
(9, N'Marketing qua mạng xã hội')

INSERT CHITIET_NV_KN
VALUES
(1,1),
(1,2),
(1,3),
(2,1),
(2,3),
(3,2),
(5,5),
(6,3),
(9,2),
(9,4),
(10,1),
(13,1),
(13,3),
(13,4),
(14,1),
(14,2),
(17,3),
(17,4),
(17,5),
(19,1),
(21,2),
(21,3),
(21,4),
(22,2),
(22,5),
(23,1),
(26,2),
(26,3)

INSERT CHITIET_NV_KT
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(2,1),
(2,3),
(2,4),
(2,7),
(3,1),
(3,2),
(3,3),
(3,4),
(4,7),
(4,8),
(4,9),
(5,5),
(5,6),
(6,3),
(6,4),
(6,5),
(7,1),
(7,2),
(7,3),
(7,4),
(8,5),
(8,6),
(8,7),
(8,8),
(9,2),
(9,4),
(10,1),
(11,1),
(12,1),
(13,1),
(13,3),
(13,4),
(14,1),
(14,2),
(15,1),
(15,2),
(16,1),
(16,2),
(17,3),
(17,4),
(17,5),
(18,1),
(19,1),
(20
,1),
(21,2),
(21,3),
(21,4),
(22,2),
(22,5),
(23,1),
(24,1),
(25,1),
(25,7),
(26,9)

INSERT CHITIET_VT_KN
VALUES
(1,1),
(1,2),
(1,3),
(2,1),
(2,3),
(3,2),
(4,1),
(4,2),
(5,1),
(5,2),
(6,1),
(6,2),
(7,2),
(8,2)

INSERT CHITIET_VT_KT
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,1),
(2,3),
(3,2),
(3,4),
(3,5),
(4,1),
(4,2),
(5,1),
(5,2),
(6,1),
(6,2),
(7,1),
(8,1)

INSERT CHITIET_PB_KN
VALUES
(1,1),
(1,2),
(1,3),
(2,1),
(2,3),
(3,2),
(4,1),
(4,2),
(5,1),
(5,2)

INSERT CHITIET_PB_KT
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,1),
(2,3),
(3,2),
(3,4),
(3,5),
(4,1),
(4,2),
(5,1),
(5,2)

INSERT CHITIET_DA_KN
VALUES
(1,1),
(1,2),
(1,3),
(2,1),
(2,3),
(3,2)

INSERT CHITIET_DA_KT
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,1),
(2,3),
(3,2),
(3,4),
(3,5)

INSERT CHITIET_DA_NV
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,15),
(1,16),
(1,18),
(1,19),
(1,20),
(1,22),
(1,24),
(2,11),
(2,12),
(2,13),
(2,17),
(2,18),
(2,19),
(2,22),
(2,25),
(3,11),
(3,12),
(3,13),
(3,17),
(3,18),
(3,19),
(3,22),
(3,23)