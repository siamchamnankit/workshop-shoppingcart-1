*** Settings ***
Library    SeleniumLibrary
Test Teardown    ปิดหน้าเบราเซอร์

*** Variables ***
${URL}    http://54.254.234.208
${BROWSER}    chrome

*** Test Cases ***
Open first page success
    เปิดหน้าแรก
    พบชื่อร้านค้า    SCK Shop

*** Keywords ***
เปิดหน้าแรก
    Open Browser    ${URL}    ${BROWSER}

พบชื่อร้านค้า
    [Arguments]     ${ชื่อร้านค้า}
    Wait Until Page Contains     ${ชื่อร้านค้า}
    Capture Page Screenshot

ปิดหน้าเบราเซอร์
    Close Browser