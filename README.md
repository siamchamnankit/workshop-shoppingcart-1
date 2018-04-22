Welcome

# Install Mysql
## Build image
docker build -t workshop-shoppingcart-mysql . -f Dockerfile_mysql

## Run container
docker run --name=workshop-shoppingcart-mysql -p 3306:3306 workshop-shoppingcart-mysql