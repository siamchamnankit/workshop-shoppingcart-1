# SonarQube
https://sonarcloud.io/dashboard?id=workshop-shoppingcart

# Install UI
## Build Image
cd src/ui/ 

docker build -t workshop-shoppingcart-ui .

## Run container
docker run --name workshop-shoppingcart-ui -p 80:80 workshop-shoppingcart-ui

# Install API
## Build Image
cd src/api/

docker build -t workshop-shoppingcart-api .

## Run container
docker run --name workshop-shoppingcart-api -p 5001:5001 workshop-shoppingcart-api

## Run container on Localhost
docker run --name workshop-shoppingcart-api -p 5001:5001 -e ASPNETCORE_ENVIRONMENT=Localhost workshop-shoppingcart-api

## Temporary Run on Localhost, not use docker
ASPNETCORE_ENVIRONMENT=Localhost dotnet run

# Install Mysql
## Build image
docker build -t workshop-shoppingcart-mysql . -f Dockerfile_mysql

## Run container
docker run --name=workshop-shoppingcart-mysql -p 3306:3306 -v /Users/ifew/mysql_db:/var/lib/mysql workshop-shoppingcart-mysql

(ตรง -v /Users/ifew/mysql_db ให้แก้เป็นที่อยู่โฟลเดอร์ที่ต้องการจะใช้เก็บข้อมูล)

# Run Robot Framework
cd tests/ui.AcceptanceTest/

## UAT
pybot --variable URL:http://54.254.234.208 .

## Localhost
pybot --variable URL:http://localhost .
