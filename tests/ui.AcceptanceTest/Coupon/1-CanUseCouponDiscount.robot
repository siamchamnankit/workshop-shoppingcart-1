*** Settings ***
Library    SeleniumLibrary
Resource    ../Resource/shopping-cart-keywords.robot
Test Teardown    ปิดหน้าเบราเซอร์
Test Template    ซื้อสินค้าและสามารถใช้คูปองเป็นส่วนลดได้

*** Test Cases ***                         product_id    product_name    product_brand    product_price    discount    coupon_no    transport_fee    total    discount_after_used    total_after_used
ซื้อสินค้าราคามากกว่าขั้นต่ำและคูปองยังไม่ครบจำนวน         32        Lego Set A          Lego             150             0      VALENTINE200       50           200              150                  50
ซื้อสินค้าราคาเท่ากับยอดขั้นต่ำและคูปองยังไม่ครบจำนวน       33        Lego Set B          Lego             350             0      VALENTINE02        50           400              200                 200
ซื้อสินค้าราคาเท่ากับยอดขั้นต่ำและคูปองที่ใช้เป็นใบสุดท้าย      32        Lego Set A          Lego             150             0      VALENTINE03        50           200              150                  50
ซื้อสินค้าราคามากกว่ายอดขั้นต่ำและคคูปองที่ใช้เป็นใบสุดท้าย    33        Lego Set B          Lego             350             0      VALENTINE04        50           200              200                  50

*** Keywords ***
ซื้อสินค้าและสามารถใช้คูปองเป็นส่วนลดได้
    [Tags]    Not Implement    Success Case    Coupon Feature
    [Arguments]      ${product_id}    ${product_name}    ${product_brand}    ${product_price}    ${discount}     ${coupon_no}     ${transport_fee}     ${total}     ${discount_after_used}    ${total_after_used}
    เข้าหน้าแสดงรายการสินค้า พบรายการสินค้าทั้งหมด
    เลือกสินค้า    ${product_id} 
    แสดงรายละเอียดสินค้า     ${product_name}    ${product_brand}    ${product_price}
    เพิ่มสินค้าเข้าตะกร้า
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    ${product_name}    ${product_brand}    ${product_price}    ${discount}   ${transport_fee}    ${total}
    ใส่คูปองส่วนลด    ${coupon_no}
    แสดงรายการสินค้าที่อยู่ในตะกร้าสินค้าและมีราคารวมค่าสินค้าดังนี้    ${product_name}    ${product_brand}    ${product_price}    ${discount_after_used}   ${transport_fee}    ${total_after_used}
    กดยืนยันการสั่งซื้อสินค้า
    แสดงที่อยู่ในการจัดส่ง
    ยืนยันที่อยู่ในการจัดส่ง
    แสดงผลการสั่งซื้อ
