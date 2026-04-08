Software Testing Project: NUnit Framework and Unit Testing Applications
1. Giới thiệu dự án (Project Overview)
Dự án được thực hiện trong khuôn khổ học phần Kiểm thử phần mềm tại Trường Đại học Công nghệ GTVT (UTT). Mục tiêu cốt lõi là nghiên cứu và triển khai quy trình kiểm thử đơn vị (Unit Testing) chuyên sâu cho hệ thống quản lý giao dịch ngân hàng bằng framework NUnit.

Dự án tập trung vào:

Áp dụng framework NUnit để kiểm thử các nghiệp vụ tài chính: nạp tiền, rút tiền, chuyển khoản và lãi suất.

Thực hiện kỹ thuật Bug Reveal Testing: Sử dụng bộ test để phát hiện và minh chứng các lỗi logic trong phiên bản mã nguồn lỗi (BankAccountBuggy).

Đánh giá chất lượng bộ kiểm thử thông qua các chỉ số bao phủ mã nguồn (Code Coverage).

2. Công nghệ sử dụng (Technical Stack)
Ngôn ngữ: C# (.NET 8.0).

Testing Framework: NUnit 3.14.0.

Coverage Analysis: ReportGenerator 5.5.4 (Parser: MultiReport Cobertura).

IDE: Visual Studio 2022.

3. Cấu trúc mã nguồn (Project Structure)
Dự án được chia làm hai phần chính:

BankSystem (Business Logic):

BankAccount.cs: Triển khai các phương thức nghiệp vụ chuẩn.

BankAccountBuggy: Phiên bản chứa các lỗi logic cố ý (trừ sai số dư, cộng sai lãi suất) nhằm phục vụ mục đích mô phỏng phát hiện lỗi.

BankingSystem.Tests (Test Suite):

DepositTests.cs, WithdrawTests.cs, TransferTests.cs, InterestTests.cs: Các lớp kiểm thử độc lập cho từng module nghiệp vụ.

4. Kịch bản kiểm thử (Test Methodology)
Quy trình kiểm thử tuân thủ mô hình Arrange - Act - Assert (AAA). Các kịch bản kiểm thử bao phủ:

Happy Path: Các luồng giao dịch thông thường với dữ liệu hợp lệ.

Negative Testing: Kiểm tra khả năng xử lý ngoại lệ khi dữ liệu đầu vào không hợp lệ hoặc vi phạm ràng buộc số dư.

Boundary Value Analysis: Kiểm tra tại các giá trị biên (số tiền rút bằng đúng số dư, lãi suất cực tiểu...).

Data-Driven Testing: Tối ưu hóa mã nguồn kiểm thử bằng cách sử dụng attribute [TestCase] để chạy một kịch bản trên nhiều bộ dữ liệu khác nhau.

5. Kết quả độ bao phủ (Coverage Results)
Dựa trên báo cáo tổng hợp từ công cụ phân tích:

Tổng hợp hệ thống: Đạt mức độ bao phủ tuyệt đối với 100% Line Coverage (60/60 dòng) và 100% Branch Coverage (20/20 nhánh).

Chi tiết từng lớp:

BankSystem.BankAccount: Line coverage 100%, Branch coverage 100%.

BankSystem.BankAccountBuggy: Line coverage 100%, Branch coverage 100%.

Kết quả này khẳng định bộ kiểm thử đã thực thi qua toàn bộ các dòng lệnh và mọi nhánh điều kiện logic có trong mã nguồn dự án.

6. Thành viên thực hiện (Team Members)
Lê Quang Anh - Lớp 74DCHT22 (Trưởng nhóm)

Nguyễn Bá Lộc

Nguyễn Văn Hải

Nguyễn Thị Trang

Giáo viên hướng dẫn: ThS. Nguyễn Thị Lan Anh