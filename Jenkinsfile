pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                docker build -t workshop-shoppingcart-api-test .
            }
        }
        stage('Unit Test') {
            steps {
                docker run --rm -e RUNNING_PROJECT=./tests/api.UnitTest/api.UnitTest.csproj workshop-shoppingcart-api-test
            }
        }
        stage('Integrate Test') {
            steps {
                docker run --rm -e RUNNING_PROJECT=./tests/api.IntegrationTest/api.IntegrationTest.csproj workshop-shoppingcart-api-test
            }
        }
    }
}