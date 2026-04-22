# Software Testing Project: NUnit Framework and Unit Testing Applications

## 1. Giới thiệu dự án (Project Overview)
Dự án được thực hiện trong khuôn khổ học phần **Kiểm thử phần mềm** tại **Trường Đại học Công nghệ GTVT (UTT)**. Mục tiêu cốt lõi là nghiên cứu và triển khai quy trình kiểm thử đơn vị (Unit Testing) chuyên sâu cho hệ thống quản lý giao dịch ngân hàng bằng framework **NUnit**.

**Mục tiêu chính:**
* Áp dụng NUnit để kiểm thử các nghiệp vụ tài chính: nạp tiền, rút tiền, chuyển khoản và thanh toán hóa đơn.
* Đánh giá chất lượng bộ kiểm thử thông qua các chỉ số bao phủ mã nguồn (Code Coverage).

---

## 2. Công nghệ sử dụng (Technical Stack)
* **Ngôn ngữ:** C# (.NET 8.0)
* **Testing Framework:** NUnit 3.14.0
* **Phân tích bao phủ mã nguồn:** ReportGenerator 5.5.4 (Parser: MultiReport Cobertura)
* **IDE:** Visual Studio 2022

---

## 3. Cấu trúc mã nguồn (Project Structure)
Dự án gồm hai phần chính:

* **BankSystem (Business Logic):**
  * `BankAccount.cs`: Triển khai các phương thức nghiệp vụ chuẩn.
* **BankingSystem.Tests (Test Suite):**
  * `DepositTests.cs`, `WithdrawTests.cs`, `TransferTests.cs`, `PayBillTests.cs`: Các lớp kiểm thử độc lập cho từng nghiệp vụ.

---

## 4. Kịch bản kiểm thử (Test Methodology)
Các test tuân thủ mô hình **Arrange - Act - Assert (AAA)**, bao gồm:

* **Happy Path:** Giao dịch thông thường với dữ liệu hợp lệ.
* **Negative Testing:** Kiểm tra xử lý ngoại lệ với dữ liệu không hợp lệ hoặc vi phạm ràng buộc số dư.
* **Boundary Value Analysis:** Kiểm thử giá trị biên (ví dụ: rút đúng số dư, thanh toán sát số dư trừ phí).
* **Data-Driven Testing:** Sử dụng attribute `[TestCase]` để chạy cùng kịch bản với nhiều bộ dữ liệu.

---

## 5. Kết quả độ bao phủ (Coverage Results)
Dựa trên công cụ phân tích ReportGenerator:

* **Hệ thống tổng thể:**
  * Line Coverage: **100% (60/60 dòng)**
  * Branch Coverage: **100% (20/20 nhánh)**
* **Chi tiết từng lớp:**
  * `BankSystem.BankAccount`: Line coverage 100%, Branch coverage 100%

Kết quả này khẳng định bộ kiểm thử đã thực thi qua toàn bộ các dòng lệnh và mọi nhánh điều kiện logic có trong mã nguồn dự án.

---

## 6. Thành viên thực hiện (Team Members)
* **Lê Quang Anh** - Lớp 74DCHT22 (Trưởng nhóm)
* **Nguyễn Bá Lộc**
* **Nguyễn Văn Hải**
* **Nguyễn Thị Trang**

**Giáo viên hướng dẫn:** ThS. Nguyễn Thị Lan Anh
