# Hệ thống quản lý kho - Bánh kẹo Á Châu

## Yêu cầu
- Visual Studio 2019/2022 (Workload .NET desktop development)
- .NET Framework 4.8
- SQL Server 2016+ (hoặc SQL Server Express)
- SQL Server Management Studio (SSMS)

## Cài đặt
1. Mở SSMS, mở file `QLKho_AChau.sql` và bấm Execute (F5).
2. Mở `QLKhoAChau.sln` bằng Visual Studio.
3. Mở `App.config` và sửa connection string:
   SQL Server bản đầy đủ: `Data Source=.`
4. Bấm F5 để chạy.

## Tài khoản mẫu
| User | Pass | Vai trò |
|------|------|---------|
| admin | admin123 | Quản trị |
| thukho | 123456 | Thủ kho |

## Tính năng
- Đăng nhập phân quyền
- Quản lý hàng hóa (CRUD)
- Lập phiếu nhập / phiếu xuất (transaction)
- Tự động cập nhật tồn kho qua trigger
- Tồn kho
- Cảnh báo tồn dưới ngưỡng tối thiểu
- Báo cáo Nhập - Xuất - Tồn
