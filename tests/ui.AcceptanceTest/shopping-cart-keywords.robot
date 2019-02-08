*** Keywords ***
เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    Open Browser    ${URL}    chrome
    Wait Until Page Contains     43 Piece dinner Set    3s
    Capture Page Screenshot

ค้าหาสินค้า ช่วงอายุ 3 ถึง 5 ปี และเพศหญิง
    Select From List by Value    age-input    3_to_5
    Select From List by Value    gender-input    Female 
    Click Element    search-button
    Wait Until Page Contains     43 Piece dinner Set    3s
    Wait Until Page Contains     Sleeping Queens Board Game    3s
    Wait Until Page Contains     Princess Palace    3s
    Wait Until Page Contains     Best Friends Forever Magnetic Dress Up    3s
    Wait Until Page Contains     Princess Training Bicycle    3s
    Capture Page Screenshot

เลือกสินค้า 43 Piece dinner Set
    Click Element    link-product-detail-id-2
    Capture Page Screenshot

แสดงรายละเอียดสินค้า 43 Piece dinner Set
    Wait Until Element Contains     label-product-name    43 Piece dinner Set    3s
    Wait Until Element Contains     label-product-brand    CoolKidz    3s
    Wait Until Element Contains     label-product-price    12.95    3s
    Capture Page Screenshot

เพิ่มจำนวนสินค้าที่ต้องการจะซื้อเป็น 2 ชิ้น
    Select From List by Value    product-quantity    2 
    Wait Until Element Contains     product-total-price   25.9    3s
    Capture Page Screenshot

เพิ่มสินค้าเข้าตะกร้า
    Click Button    button-add-product-to-cart

แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมเท่ากับ
    [Arguments]      ${subtotal}
    Wait Until Page Contains     43 Piece dinner Set    3s
    Wait Until Page Contains     CoolKidz    3s
    Wait Until Page Contains     12.95    3s
    Wait Until Element Contains     label-subtotal    ${subtotal}    3s
    Wait Until Element Contains     label-shipping-fee    50.00    3s
    Capture Page Screenshot

กดยืนยันการสั่งซื้อสินค้า
    Click Button    button-confirm-cart

แสดงที่อยู่ในการจัดส่ง
    Wait Until Element Contains     textbox-user-fullname    Chonnikan Tobunrueang    3s
    Wait Until Element Contains     textbox-address1    3 อาคารพร้อมพันธ์ 3 ห้อง 1001    3s
    Wait Until Element Contains     textbox-address2    จอมพล    3s
    Wait Until Element Contains     textbox-city    จตุจักร    3s
    Wait Until Element Contains     textbox-province    กรุงเทพ    3s
    Wait Until Element Contains     textbox-postcode    10900    3s
    Capture Page Screenshot

ยืนยันที่อยู่ในการจัดส่ง
    Click Button    button-confirm-shipping-address

แสดงผลการสั่งซื้อ
    Wait Until Page Contains     Thank you    3s
    Capture Page Screenshot

ปิดหน้าเบราเซอร์
    Close Browser
