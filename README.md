# VRILLAR_Test_Entry
1. Tổng quan: Chương trình này nhận Input của user, chi tiết hóa vị trí của mặt trời khớp với thời gian, ngày, và vị trí hiện tại mà user nhập vào. 
2. Cách thực hiện:
	2.1 khởi tạo project với các level theo yêu cầu
	2.2 tạo UI cho người dùng nhập vào
	2.3 Viết mã để nhận và kiểm tra dữ liệu người dùng nhập vào
	2.4 Viết mã cho đối tượng mặt trời
	2.5 Điều chỉnh vị trí các text giờ
3. Mô tả chi tiết:
	3.1 Thông qua tham khảo tài liệu shadows của Unity, em có thêm phần Lens Flare để nhìn thấy hình ảnh mặt trời di chuyển. Các thông số còn lại của mặt trời (Direct light) em vẫn giữ nguyên
	3.2 Xử lý thời gian người dùng nhập vào để tạo hiệu ứng bóng cho cột theo hướng chiếu sáng của mặt trời:
		+ Tính góc xoay của mặt trời (rotation y) dùng hàm CalculateAngle: tính toán góc nghiêng dựa trên thời gian nhập vào, tính tổng số giây rồi lấy tổng số giây chia cho 86400 (86400giây/ngày), sau đó lấy kết quả này nhân với 360 => sẽ tính dc góc nghiêng tương ứng với thời gian
		+ Tính thời gian của mặt trời theo ngày dùng hàm CalculateDayLight:
		Giả sử lúc 12h trưa (trời đứng bóng), thì mặt trời sẽ nằm ở góc 90 độ (trên đỉnh đầu của vật thể). Suy ra chúng ta có thể tính theo số độ dựa theo công thức
		số độ = (số giờ / 12) * 90
		Nếu muốn tính thêm cả giờ + phút + giây thì công thức sẽ là
		số độ = ((số giờ + (số phút / 60) + (số giây / 3600)) / 12) * 90
		Trong công thức trên, ta chia số phút cho 60 và số giây cho 3600 để đổi về dạng thập phân của một giờ. Sau đó, chúng ta cộng tổng số giờ, số phút và số giây lại với nhau, và chia kết quả cho 12 (tổng số giờ trong một chu kỳ 12 giờ trên đồng hồ) để tính tỷ lệ. Cuối cùng, nhân với 90 để tìm số độ tương ứng.
		=> Set lại vị trí và góc chiếu sáng của mặt trời theo góc xoay và thời gian của mặt trời theo ngày vừa tính được.
3. Báo cáo kết quả:
- Lấy ý tưởng từ hiệu ứng đổ bóng của mặt trời em có gắn thêm text số để cho nó giống với đồng hồ mặt trời

- Cụ thể hóa vị trí của mặt trời hiện tại tương ứng với Input của User và tạo ra bóng trên trụ do ánh mặt trời:
-> Hiện tại đã tạo ra bóng trên trụ do ánh sáng mặt trời chiếu vào dựa theo thời gian mà người dùng nhập vào, còn về phần vĩ độ và kinh độ em chưa biết áp dụng như thế nào nên hiện tại em chỉ gán đơn giản cho nó vào vị trí x và y của mặt trời, với kinh độ: nếu là kinh độ Tây thì sẽ là -x, ngược lại thì là x. Còn với vĩ độ: nếu là vĩ độ Nam thì sẽ là -y, ngược lại là y.

- Độ cao của mặt trời nên thay đổi theo ngày, và do đó độ dài của bóng cũng nên được thay đổi:
-> Đã xử lý theo thời gian người dùng nhập vào

- Giá trị, vị trí v.v của mặt trời có thể được thể hiện riêng để tăng độ chính xác của kết quả
-> Giữ nguyên các giá trị của mặt trời lúc vừa khởi tạo, chỉ thêm component Lens Flare.

- Phần chưa xử lý: chưa có input cho ngày hiện tại (tháng/ngày)
4. Tài liệu tham khảo:
https://www.wikihow.vn/Ghi-kinh-%C4%91%E1%BB%99-v%C3%A0-v%C4%A9-%C4%91%E1%BB%99
https://vi.wikipedia.org/wiki/Kinh_tuy%E1%BA%BFn_g%E1%BB%91c
https://docs.unity3d.com/Manual/Shadows.html
5. Câu hỏi:
- em vẫn còn thắc mắc việc áp dụng vĩ độ và kinh độ vào việc tính vị trí của mặt trời, em hy vọng sẽ được công ty gửi mail giải đáp thắc mắc này giúp em ạ. Em cảm ơn trước ạ