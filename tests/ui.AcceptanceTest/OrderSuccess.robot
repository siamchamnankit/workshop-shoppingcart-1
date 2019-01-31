*** Settings ***
Library    SeleniumLibrary
Test Teardown    ปิดหน้าเบราเซอร์

*** Variables ***
${URL}     http://3.1.20.19

*** Test Cases ***
ผู้ใช้สามารถสั่งซื้อสินค้าได้สำเร็จ
    เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    เลือกสินค้า 43 Piece dinner Set
    แสดงรายละเอียดสินค้า 43 Piece dinner Set
    เพิ่มสินค้าเข้าตะกร้า
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้า
    กดยืนยันการสั่งซื้อสินค้า
    แสดงที่อยู่ในการจัดส่ง
    ยืนยันที่อยู่ในการจัดส่ง
    แสดงผลการสั่งซื้อ

*** Keywords ***
เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    Open Browser    ${URL}    chrome
    Wait Until Page Contains     43 Piece dinner Set    3s

เลือกสินค้า 43 Piece dinner Set
    Click Element    link-product-detail-id-2

แสดงรายละเอียดสินค้า 43 Piece dinner Set
    Wait Until Element Contains     label-product-name    43 Piece dinner Set    3s
    Wait Until Element Contains     label-product-brand    CoolKidz    3s
    Wait Until Element Contains     label-product-price    12.95    3s

เพิ่มสินค้าเข้าตะกร้า
    Click Button    button-add-product-to-cart

แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้า
    Wait Until Page Contains     43 Piece dinner Set    3s
    Wait Until Page Contains     CoolKidz    3s
    Wait Until Page Contains     12.95    3s
    Wait Until Element Contains     label-subtotal    12.95    3s
    Wait Until Element Contains     label-shipping-fee    25.00    3s

กดยืนยันการสั่งซื้อสินค้า
    Click Button    button-confirm-cart

แสดงที่อยู่ในการจัดส่ง
    Wait Until Element Contains     textbox-user-fullname    Chonnikan Tobunrueang    3s
    Wait Until Element Contains     textbox-address1    3 อาคารพร้อมพันธ์ 3 ห้อง 1001    3s
    Wait Until Element Contains     textbox-address2    จอมพล    3s
    Wait Until Element Contains     textbox-city    จตุจักร    3s
    Wait Until Element Contains     textbox-province    กรุงเทพ    3s
    Wait Until Element Contains     textbox-postcode    10900    3s

ยืนยันที่อยู่ในการจัดส่ง
    Click Button    button-confirm-shipping-address

แสดงผลการสั่งซื้อ
    Wait Until Page Contains     Thank you    3s

ปิดหน้าเบราเซอร์
    Close Browser