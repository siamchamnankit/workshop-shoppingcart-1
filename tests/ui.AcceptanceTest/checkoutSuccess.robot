*** Settings ***
Library    Selenium2Library
Test Setup    Add First Item To Cart
Force Tags      checkout_success    Story_1

*** Variables ***
${ITEM_ID_1}    1
${ITEM_ID_2}    2
${GENDER}    female
${AGE}    3-5
${QTY_1}    2
${PROMO_CODE}    a1s2d3f4
${IS_SAVE_SHIPPING_ADD}    ${TRUE}
${CHECKOUT_BUTTON}    BTN_Checkout

*** Test Cases ***
Checkout With New Item And Submit New Shipping Address Information Should Be Order Complete
    Go To Search Items Page
    Search Items    ${GENDER}    ${AGE}
    Choose Item    ${ITEM_ID_2}
    Item Detail Page Should Show Information Correctly    ${ITEM_ID_2}
    Add to cart    ${QTY_1}
    Go To Checkout From Item Detail Page
    Total Price Should Be Correct
    Confirm Checkout    ${PROMO_CODE}
    Submit New Shipping Address information    ${IS_SAVE_SHIPPING_ADD}
    Order Complete And Should Be Show Thank You page

Checkout With Same Item And Select Saved Shipping Address Information Should Be Order Complete
    Go To Item Detail Page    ${ITEM_ID_1}
    Item Detail Page Should Show Information Correctly    ${ITEM_ID_1}
    Add to cart    ${QTY_1}
    Go To Checkout From Item Detail Page
    Total Price Should Be Correct
    Confirm Checkout    ${PROMO_CODE}
    Select Shipping Address Information From List    1
    Order Complete And Should Be Show Thank You page

*** Keywords ***
Add First Item To Cart
    Go To Item Detail Page    ${ITEM_ID_1}
    Item Detail Page Should Show Information Correctly    ${ITEM_ID_1}
    Add to cart    ${QTY_1}

Go To Item Detail Page
    [Arguments]    ${ITEM_ID_1}
    No Operation

Item Detail Page Should Show Information Correctly
    [Arguments]    ${ITEM_ID_1}
    No Operation

Add to cart
    [Arguments]    ${QTY_1}
    No Operation

Go To Search Items Page
    No Operation
    
Search Items
    [Arguments]    ${GENDER}    ${AGE}
    No Operation
    
Choose Item
    [Arguments]    ${ITEM_ID_2}
    No Operation

Go To Checkout From Item Detail Page
    No Operation

Total Price Should Be Correct
    No Operation

Confirm Checkout
    [Arguments]    ${PROMO_CODE}
    #Run Keyword If    ${PROMO_CODE} == ${PROMO_CODE}    Enter PROMO_CODE    ${PROMO_CODE}
    #Click Button    ${CHECKOUT_BUTTON}
    No Operation

Submit New Shipping Address information
    [Arguments]    ${IS_SAVE_SHIPPING_ADD}
    No Operation

Order Complete And Should Be Show Thank You page
    No Operation

Select Shipping Address Information From List
    [Arguments]    ${Position_List_Number}
    No Operation

Enter PROMO_CODE
    [Arguments]    ${PROMO_CODE}
    No Operation

Change Qty Of Item On Item Detail Page
    [Arguments]    ${Qty_To_Change}
    No Operation

Change Qty Of Item On Checkout Page
    [Arguments]    ${Qty_To_Change}
    No Operation

Delete Item From Setting Up Cart
    No Operation