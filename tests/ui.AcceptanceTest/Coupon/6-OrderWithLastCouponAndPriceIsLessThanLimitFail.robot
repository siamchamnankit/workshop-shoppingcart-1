*** Settings ***
Library    SeleniumLibrary
Resource    ../Resource/shopping-cart-keywords.robot
Test Teardown    ปิดหน้าเบราเซอร์

*** Test Cases ***
ซื้อสินค้าราคาน้อยกว่ายอดขั้นต่ำที่คูปองกำหนดและคูปองที่ใช้เป็นใบสุดท้าย
    เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    เลือกสินค้า 43 Piece dinner Set
    แสดงรายละเอียดสินค้า 43 Piece dinner Set
    เพิ่มสินค้าเข้าตะกร้า
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าเท่ากับ    140    0   50    190
    ใส่คูปองส่วนลด    BLACKVAL06
    แสดงข้อความไม่สามารถร่วมรายการการใช้งานคูปองได้
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าเท่ากับ    140    0   50    190
    