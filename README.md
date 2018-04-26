# SonarQube
https://sonarcloud.io/dashboard?id=workshop-shoppingcart

# Install Mysql
## Build image
docker build -t workshop-shoppingcart-mysql . -f Dockerfile_mysql

## Run container
docker run --name=workshop-shoppingcart-mysql -p 3306:3306 -v /Users/ifew/mysql_db:/var/lib/mysql workshop-shoppingcart-mysql

(ตรง -v /Users/ifew/mysql_db ให้แก้เป็นที่อยู่โฟลเดอร์ที่ต้องการจะใช้เก็บข้อมูล)