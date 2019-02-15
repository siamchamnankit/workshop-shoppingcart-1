*** Settings ***
Library    SeleniumLibrary
Resource    ../Resource/shopping-cart-keywords.robot
Test Teardown    ปิดหน้าเบราเซอร์

*** Test Cases ***
ซื้อสินค้าราคามากกว่ายอดขั้นต่ำที่คูปองกำหนดและคูปองยังถูกใช้ไม่ครบจำนวน
    เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    เลือกสินค้า    32
    แสดงรายละเอียดสินค้า     Lego Set A (used for coupon feature) with 150THB    Lego    150
    เพิ่มสินค้าเข้าตะกร้า
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    Lego Set A (used for coupon feature) with 150THB    Lego    150    0   50    200
    ใส่คูปองส่วนลด    VALENTINE200
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    Lego Set A (used for coupon feature) with 150THB    Lego    150    150   50    50
    กดยืนยันการสั่งซื้อสินค้า
    แสดงที่อยู่ในการจัดส่ง
    ยืนยันที่อยู่ในการจัดส่ง
    แสดงผลการสั่งซื้อ