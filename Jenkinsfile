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
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}