pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                sh 'docker build -t workshop-shoppingcart-api-test .'
            }
        }
        stage('Unit Test') {
            steps {
                echo 'Unit Testing..'
                sh 'docker run --rm -e RUNNING_PROJECT=./tests/api.UnitTest/api.UnitTest.csproj workshop-shoppingcart-api-test'
            }
        }
        stage('Integrate Test') {
            steps {
                echo 'Integrate Testing..'
                sh 'docker run --rm -e RUNNING_PROJECT=./tests/api.IntegrationTest/api.IntegrationTest.csproj workshop-shoppingcart-api-test'
            }
        }
        stage('UI Integrate Test') {
            steps {
                echo 'UI Integrate Testing....'
                echo ' # Start Database Server'
                echo ' ## Build database docker image'
                sh 'docker build -t workshop-shoppingcart-mysql . -f Dockerfile_mysql'

                echo ' ## Run container'
                sh 'docker stop workshop-shoppingcart-mysql'
                sh 'docker run --rm -d --name=workshop-shoppingcart-mysql -p 3306:3306 workshop-shoppingcart-mysql'

                sh 'sleep 5'

                echo ' # Data Migration into Mysql'
                echo ' ## run docker liquibase\'s image to migrate data from changelog.yml'

                sh 'docker run --rm -v $(pwd):/liquibase/ -e "LIQUIBASE_URL=jdbc:mysql://docker.for.mac.localhost/workshop_shoppingcart" -e "LIQUIBASE_USERNAME=root" -e "LIQUIBASE_PASSWORD=1234" -e "LIQUIBASE_CHANGELOG=data/changelog.yml" webdevops/liquibase:mysql update'

            }
        }
        stage('UAT Deploy') {
            steps {
                echo 'UAT Deploying....'
            }
        }
    }
}