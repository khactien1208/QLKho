# 📦 Hệ thống Quản Lý Kho - Bánh Kẹo Á Châu

## 📋 Mục lục
- [Giới thiệu](#giới-thiệu)
- [Hướng dẫn cài đặt](#hướng-dẫn-cài-đặt)
- [Hướng dẫn sử dụng](#hướng-dẫn-sử-dụng)
- [Các tính năng chính](#các-tính-năng-chính)

---

## 🎯 Giới thiệu

**QLKhoAChau** là một hệ thống quản lý kho hàng hoàn chỉnh được phát triển bằng C# với Windows Forms. Ứng dụng cung cấp các tính năng quản lý hàng hóa, phiếu nhập/xuất, theo dõi tồn kho, cảnh báo và báo cáo thống kê.

**Công ty:** Bánh Kẹo Á Châu

---


## 📥 Hướng dẫn Cài Đặt

#### Cấu hình Connection String (nếu cần):
1. Mở file `appsettings.json` (hoặc `App.config`)
2. Kiểm tra connection string:
   ```json
   {
     "ConnectionStrings": {
       "QLKho": "Data Source=.;Initial Catalog=QLKho_AChau;Integrated Security=True;TrustServerCertificate=True"
     }
   }
   ```

---

## 🚀 Hướng Dẫn Sử Dụng

## 👥 Tài Khoản Mẫu

| Tên Đăng Nhập | Mật Khẩu | Vai Trò | Quyền Hạn |
|---------------|----------|--------|-----------|
| admin | admin123 | Quản trị | Toàn quyền: quản lý tất cả chức năng, quản lý người dùng |
| thukho | 123456 | Thủ kho | Quản lý hàng hóa, phiếu nhập/xuất, tồn kho, báo cáo |
| thuesac | 123456 | Thủ Kho Xuất | Chỉ được phép tạo phiếu xuất và xem báo cáo |

**Hướng dẫn đổi mật khẩu:**
1. Sau khi đăng nhập, chọn menu **Tài Khoản** (nếu có)
2. Bấm **Đổi Mật Khẩu**
3. Nhập mật khẩu cũ
4. Nhập mật khẩu mới
5. Xác nhận mật khẩu mới
6. Bấm **Lưu**

---

### 1. Đăng Nhập

Khi ứng dụng khởi động, bạn sẽ thấy màn hình **Đăng Nhập**:

1. Nhập **Tên đăng nhập** (Username)
2. Nhập **Mật khẩu** (Password)
3. Chọn vai trò (nếu có)
4. Bấm nút **Đăng Nhập**

**Lưu ý:** Các tài khoản và quyền hạn khác nhau sẽ hiển thị các tính năng khác nhau.

### 2. Giao Diện Chính

Sau khi đăng nhập thành công, bạn sẽ vào **Màn hình Chính** với các menu:

- **Danh Mục** - Quản lý thông tin cơ bản
- **Hàng Hóa** - Quản lý sản phẩm
- **Phiếu Nhập** - Lập phiếu nhập kho
- **Phiếu Xuất** - Lập phiếu xuất kho
- **Tồn Kho** - Kiểm tra số lượng hàng
- **Báo Cáo** - Xem báo cáo thống kê
- **Quản Trị** - Quản lý người dùng (chỉ Admin)

### 3. Các Chức Năng Chi Tiết

#### 3.1 Quản Lý Danh Mục

**Mục đích:** Quản lý các danh mục cơ bản như nhà cung cấp, khách hàng

**Cách sử dụng:**
1. Chọn **Danh Mục** từ menu chính
2. Chọn loại danh mục cần quản lý (Nhà Cung Cấp, Khách Hàng, v.v.)
3. Bấm **Thêm Mới** để tạo danh mục
4. Nhập thông tin và bấm **Lưu**
5. Có thể **Sửa** hoặc **Xóa** danh mục hiện có

#### 3.2 Quản Lý Hàng Hóa

**Mục đích:** Quản lý danh sách sản phẩm trong kho

**Cách sử dụng:**
1. Chọn **Hàng Hóa** từ menu chính
2. Danh sách hàng hóa sẽ hiển thị với các cột: Mã, Tên, Đơn vị, Giá, v.v.
3. **Thêm hàng hóa:**
   - Bấm **Thêm Mới**
   - Nhập: Tên hàng hóa, Đơn vị tính, Giá nhập, Giá bán, Tồn kho tối thiểu
   - Bấm **Lưu**
4. **Sửa thông tin:**
   - Chọn hàng hóa cần sửa
   - Bấm **Sửa**
   - Thay đổi thông tin
   - Bấm **Cập Nhật**
5. **Xóa:** Chọn hàng hóa → Bấm **Xóa** (chú ý: không thể xóa nếu đã có phiếu liên quan)

#### 3.3 Lập Phiếu Nhập

**Mục đích:** Ghi nhận hàng hóa nhập vào kho từ nhà cung cấp

**Cách sử dụng:**
1. Chọn **Phiếu Nhập** từ menu chính
2. Bấm **Phiếu Nhập Mới**
3. Điền thông tin:
   - **Nhà Cung Cấp:** Chọn từ danh sách
   - **Ngày Nhập:** Chọn ngày (mặc định là ngày hôm nay)
   - **Ghi chú:** (tùy chọn)
4. **Thêm hàng hóa vào phiếu:**
   - Bấm nút **Thêm Hàng**
   - Chọn hàng hóa từ danh sách
   - Nhập số lượng
   - Bấm **OK**
5. Xem lại chi tiết phiếu
6. Bấm **Lưu Phiếu** để hoàn tất
7. **Tự động:** Hệ thống sẽ cập nhật tồn kho

**Lưu ý:** 
- Không thể chỉnh sửa phiếu sau khi lưu (để đảm bảo tính toàn vẹn dữ liệu)
- Nếu có lỗi, cần phải hủy và tạo phiếu mới

#### 3.4 Lập Phiếu Xuất

**Mục đích:** Ghi nhận hàng hóa xuất ra khỏi kho cho khách hàng

**Cách sử dụng:**
1. Chọn **Phiếu Xuất** từ menu chính
2. Bấm **Phiếu Xuất Mới**
3. Điền thông tin:
   - **Khách Hàng:** Chọn từ danh sách
   - **Ngày Xuất:** Chọn ngày
   - **Ghi chú:** (tùy chọn)
4. **Thêm hàng hóa vào phiếu:**
   - Bấm nút **Thêm Hàng**
   - Chọn hàng hóa
   - Nhập số lượng (không thể vượt quá tồn kho hiện tại)
   - Bấm **OK**
5. Kiểm tra chi tiết phiếu
6. Bấm **Lưu Phiếu**
7. **Tự động:** Hệ thống sẽ cập nhật tồn kho

**Lưu ý:**
- Hệ thống sẽ cảnh báo nếu số lượng xuất vượt quá tồn kho
- Không thể xuất hàng nếu tồn kho < 0

#### 3.5 Kiểm Tra Tồn Kho

**Mục đích:** Xem tình trạng tồn kho hiện tại

**Cách sử dụng:**
1. Chọn **Tồn Kho** từ menu chính
2. Hiển thị bảng với các cột:
   - **Mã Hàng:** Mã sản phẩm
   - **Tên Hàng:** Tên sản phẩm
   - **Tồn Kho:** Số lượng hiện tại
   - **Tối Thiểu:** Mức cảnh báo
   - **Trạng Thái:** Bình thường / Cảnh báo
3. **Cảnh báo tồn dưới mức tối thiểu:**
   - Nếu tồn kho ≤ mức tối thiểu, sẽ hiển thị cảnh báo màu đỏ
   - Bấm vào cảnh báo để xem chi tiết

#### 3.6 Báo Cáo

**Mục đích:** Xem báo cáo thống kê về nhập, xuất, tồn kho

**Cách sử dụng:**
1. Chọn **Báo Cáo** từ menu chính
2. Chọn loại báo cáo:
   - **Báo Cáo Nhập:** Thống kê hàng nhập theo khoảng thời gian
   - **Báo Cáo Xuất:** Thống kê hàng xuất theo khoảng thời gian
   - **Báo Cáo Tồn Kho:** Tình trạng tồn kho tại thời điểm
3. Chọn khoảng thời gian (Từ ngày - Đến ngày)
4. Bấm **Xem Báo Cáo**
5. **Xuất báo cáo:**
   - Có thể xuất sang Excel hoặc In bằng nút **Xuất Excel** hoặc **In**

#### 3.7 Quản Trị Hệ Thống (chỉ Admin)

**Mục đích:** Quản lý người dùng, phân quyền

**Cách sử dụng:**
1. Chọn **Quản Trị** từ menu chính (chỉ hiển thị nếu bạn là Admin)
2. Quản lý người dùng:
   - **Danh sách người dùng:** Xem tất cả tài khoản
   - **Thêm người dùng:** Bấm **Thêm Mới**, nhập thông tin, chọn vai trò, bấm **Lưu**
   - **Sửa:** Chọn người dùng, bấm **Sửa**, cập nhật thông tin, bấm **Cập Nhật**
   - **Xóa:** Chọn người dùng, bấm **Xóa** (xác nhận lại)

---


## ✨ Các Tính Năng Chính

| Tính Năng | Mô Tả |
|-----------|--------|
| **Đăng Nhập Phân Quyền** | Hệ thống xác thực người dùng với các vai trò khác nhau |
| **Quản Lý Danh Mục** | Quản lý nhà cung cấp, khách hàng, v.v. |
| **Quản Lý Hàng Hóa (CRUD)** | Tạo, sửa, xóa, xem danh sách sản phẩm |
| **Phiếu Nhập/Xuất** | Lập phiếu nhập từ nhà cung cấp và xuất cho khách hàng |
| **Cập Nhật Tồn Kho Tự Động** | Hệ thống tự động cập nhật tồn kho qua SQL Trigger |
| **Kiểm Tra Tồn Kho** | Xem tình trạng hàng hóa hiện tại trong kho |
| **Cảnh Báo Tồn Dưới Ngưỡng** | Thông báo khi tồn kho dưới mức tối thiểu |
| **Báo Cáo Thống Kê** | Báo cáo Nhập, Xuất, Tồn kho |
| **Quản Lý Người Dùng** | Thêm, sửa, xóa tài khoản người dùng (Admin) |

---
