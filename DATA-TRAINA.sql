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
(1, N'Nguyễn Văn A', '2001-01-01', 0, '12345', N'Admin', 1, 1, 1),
(2, N'Lê Hoàng B', '2001-02-02', 0, 'asdfg', N'Admin', 1, 2, 1),
(3, N'Nguyễn Xuân C', '2001-03-03', 1, '12345', N'Admin', 1, 2, 1),
(4, N'Trần Ngọc D', '2001-04-04', 1, '12345', N'Admin', 1, 3, 2),
(5, N'Hoàng Quốc E', '2001-05-05', 0, '12345', N'Quản lý', 2, 1, 3),
(6, N'Lý Đình Thiên F', '2001-06-06', 1, '12345', N'Quản lý', 2, 2, 3),
(7, N'Lê Thành G', '2001-07-07', 0, '12345', N'Quản lý', 2, 3, 2),
(8, N'Nguyễn Trần Linh H', '2001-08-08', 1, '12345', N'Trainer', 1, 1, 4),
(9, N'Vũ Hoàng I', '2001-09-09', 1, '12345', N'Trainer', 1, 2, 2),
(10, N'Trần Lê Thiên J', '2001-10-10', 1, '12345', N'Trainer', 1, 3, 4),
(11, N'Nguyễn Kim K', '2001-11-11', 0, '12345', N'Trainer', 1, 4, 2),
(12, N'Nguyễn Hoàng Minh L', '2001-12-12', 0, '12345', N'Trainer', 1, 5, 1),
(13, N'Trần M', '2001-01-13', 0, '12345', N'Trainee', 3, 1, 3),
(14, N'Lê Minh N', '2001-02-14', 0, '12345', N'Trainee', 4, 1, 2),
(15, N'Hoàng Lê O', '2001-03-15', 1, '12345', N'Trainee', 6, 1, 3),
(16, N'Lý P', '2001-04-16', 0, '12345', N'Trainee', 3, 2, 3),
(17, N'Trần Thị Q', '2001-05-17', 1, '12345', N'Trainee', 4, 2, 1),
(18, N'Nguyễn Chiến R', '2001-06-18', 0, '12345', N'Trainee', 6, 2, 4),
(19, N'Nguyễn Phương S', '2001-07-19', 0, '12345', N'Trainee', 5, 2, 4),
(20, N'Nguyễn T', '2001-08-20', 1, '12345', N'Trainee', 4, 2, 4),
(21, N'Lê Thiên U', '2001-09-21', 0, '12345', N'Trainee', 6, 2, 4),
(22, N'Lý Minh V', '2001-10-22', 1, '12345', N'Trainee', 5, 3, 3),
(23, N'Trần Lai W', '2001-11-23', 1, '12345', N'Trainee', 3, 3, 3),
(24, N'Trần X', '2001-12-24', 1, '12345', N'Trainee', 3, 3, 4),
(25, N'Lê An Y', '2001-01-25', 1, '12345', N'Trainee', 4, 3, 4),
(26, N'Lê Linh Z', '2001-02-26', 1, '12345', N'Trainee', 6, 3, 4)

INSERT VITRI
VALUES
(1, N'DevOps', N'Có kinh nghiệm với các điện toán đám mây (AWS, Azure, GCP) để triển khai các bản nâng cấp và sửa lỗi. Thực hiện các công cụ và khung tự động hóa (CI/CD pipelines)'),
(2, N'Marketing', N'Nghiên cứu sản phẩm của công ty và đối thủ, thị trường. Phát triển thị trường cho các sản phẩm mới theo kế hoạch được giao'),
(3, N'Backend developer', N'Chịu trách nhiệm chính cho Server của các ứng dụng chạy trên Web, tìm cách tối ưu chức năng, đảm bảo về tốc độ xử lý và hiệu suất của toàn bộ trang web.'),
(4, N'BA', N'phân tích nhu cầu của khách hàng và phối hợp với nội bộ công ty để đưa ra phương án giải quyết phù hợp. Bên cạnh đó, họ còn giúp đổi mới cách thức vận hành kinh doanh giữa các bộ phận để sử dụng tốt nhất nguồn lực đang có'),
(5, N'UI Designer', N'Thiết kế giao diện và trải nghiệm cho người dùng sản phẩm, có thể là của một website hoặc một app điện thoại'),
(6, N'HR', N'Các công việc của HR liên quan đến các hoạt động tuyển dụng, lên kế hoạch triển khai các chính sách phù hợp để duy trì nguồn nhân lực cho công ty và có kế hoạch bồi dưỡng phát triển năng lực các cá nhân, phòng ban '),
(7, N'Thư ký', N'Thực hiện các công việc liên quan đến công tác hỗ trợ việc quản lý, điều hành trong văn phòng, thực hiện các công việc liên quan đến giấy tờ, các công việc tạp vụ hành chính, sắp xếp hồ sơ, soạn thảo văn bản, tiếp khách, lên lịch trình, tổ chức cuộc họp, hội nghị, lên kế hoạch'),
(8, N'Frontend developer', N'Sử dụng các ngôn ngữ HTML, CSS hay ngôn ngữ lập trình Javascript để các lập trình viên thiết kế ra các giao diện ứng dụng hoặc trang web cho người dùng')

INSERT TRINHDO
VALUES
(1, N'Senior'),
(2, N'Junior'),
(3, N'Fresher'),
(4, N'Intern')

INSERT PHONGBAN
VALUES
(1, N'Công nghệ thông tin', N'Làm việc liên quan đến công nghệ thông tin'),
(2, N'Nhân sự', N'Làm việc liên quan đến nhân sự'),
(3, N'Kế toán', N'Làm việc liên quan đến kế toán'),
(4, N'Kinh doanh', N'Làm việc liên quan đến kinh doanh'),
(5, N'Marketing', N'Làm việc liên quan đến marketing')

INSERT DUAN
VALUES
(1, N'Dự án 1', '2022-01-01', '2023-01-01', N'Dự án Bệnh viện Đa khoa Quốc tế nằm trên địa bàn phường Thạnh Mỹ Lợi, Quận 2,
Tp.HCM. Bệnh viện có vị trí đắc địa, hiếm có và mang tầm chiến lược. Nguyên nhân là do
Quận 2 đang được Nhà nước đầu tư xây dựng mới hoàn toàn để trở thành một khu đô thị Thủ
Thiêm có hệ thống hạ tầng giao thông, hạ tầng xã hội hiện đại đồng bộ.'),
(2, N'Dự án 2', '2022-02-02', '2023-02-02', N'Khu đất bằng phẳng, nền đất có sức chịu tải yếu (0,7kg/cm 2 -1,0kg/cm 2 ) nên công trình
xây dựng cần có giải pháp kết cấu móng an toàn cho loại nền đất này.'),
(3, N'Dự án 3', '2022-03-03', '2023-03-03', N'Dự kiến toàn bộ dự án sẽ được đầu tư nâng cấp trên diện tích đã có sẵn là 1.600 m 2 và đầu tư
xây dựng mới trên diện tích 8.000 m 2 . Tổng diện tích đất cho toàn bộ dự án vào khoản
10.000m 2 .')

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