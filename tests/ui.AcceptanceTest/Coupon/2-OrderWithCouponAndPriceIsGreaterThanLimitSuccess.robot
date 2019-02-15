*** Settings ***
Library    SeleniumLibrary
Resource    ../Resource/shopping-cart-keywords.robot
Test Teardown    ปิดหน้าเบราเซอร์

*** Test Cases ***
ซื้อสินค้าราคาเท่ากับยอดขั้นต่ำที่คูปองกำหนดและคูปองยังถูกใช้ไม่ครบจำนวน
    เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    เลือกสินค้า    33 
    แสดงรายละเอียดสินค้า     Lego Set B (used for coupon feature) with 350THB    CoolKidz    350
    เพิ่มสินค้าเข้าตะกร้า
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    Lego Set B (used for coupon feature) with 350THB    CoolKidz    350    0   50    400
    ใส่คูปองส่วนลด    VALENTINE02
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    Lego Set B (used for coupon feature) with 350THB    CoolKidz    350    200   50    200
    กดยืนยันการสั่งซื้อสินค้า
    แสดงที่อยู่ในการจัดส่ง
    ยืนยันที่อยู่ในการจัดส่ง
    แสดงผลการสั่งซื้อ