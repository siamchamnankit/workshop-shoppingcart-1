# Data Migration into Mysql
## run docker liquibase's image to migrate data from changelog.yml

docker run --rm -v $(pwd):/liquibase/ -e "LIQUIBASE_URL=jdbc:mysql://docker.for.mac.localhost/workshop_shoppingcart" -e "LIQUIBASE_USERNAME=root" -e "LIQUIBASE_PASSWORD=1234" -e "LIQUIBASE_CHANGELOG=changelog.yml" webdevops/liquibase:mysql update 
