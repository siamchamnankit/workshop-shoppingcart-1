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
                echo '# Start Database Server'
                echo '## Build database docker image'
                sh 'docker build -t workshop-shoppingcart-mysql . -f Dockerfile_mysql'

                echo '## Run container'
                sh 'docker stop workshop-shoppingcart-mysql'
                sh 'docker run --rm -d --name=workshop-shoppingcart-mysql -p 3306:3306 workshop-shoppingcart-mysql'

                sh 'sleep 15'

                echo '# Data Migration into Mysql'
                echo '## run docker liquibase\'s image to migrate data from changelog.yml'
                
                def workspace = $(pwd)
                echo workspace
                /*
                dir("data") {
                    sh 'docker run --rm -v $(pwd):/liquibase/ -e "LIQUIBASE_URL=jdbc:mysql://docker.for.mac.localhost/workshop_shoppingcart" -e "LIQUIBASE_USERNAME=root" -e "LIQUIBASE_PASSWORD=1234" -e "LIQUIBASE_CHANGELOG=/liquibase/changelog.yml" webdevops/liquibase:mysql update'
                }
                */
                echo '# Install API'

                echo '## Build Image'
                dir("src/api/") {
                    sh 'docker build -t workshop-shoppingcart-api .'
                }

                echo '## Run container'
                sh 'docker run --rm -d --name workshop-shoppingcart-api -p 5001:5001 -e ConnectionString="server=docker.for.mac.localhost;userid=root;password=1234;database=workshop_shoppingcart;convert zero datetime=True;CHARSET=utf8;" workshop-shoppingcart-api'

                echo '# Install UI'
                echo '## Build Image'
                
                dir("src/ui/") {
                    sh 'docker build -t workshop-shoppingcart-ui .'
                }


                echo '## Run container'
                sh 'docker run --rm -d --name workshop-shoppingcart-ui -p 80:80 workshop-shoppingcart-ui'

                echo '# Run Robot Framework'

                dir("tests/ui.AcceptanceTest/") {
                    echo '## Run Robot on Docker'
                    sh 'docker run --rm -v $(pwd)/reports:/opt/robotframework/reports -v $(pwd):/opt/robotframework/tests -e BROWSER=chrome -e ROBOT_OPTIONS=" --variable URL:http://docker.for.mac.localhost --variable BROWSER:firefox" siamchamnankit/sck-robot-framework'
                }
            }
        }
        stage('UAT Deploy') {
            steps {
                echo 'UAT Deploying....'
            }
        }
    }
}



docker run --rm -v /var/jenkins_home/workspace/workshop-shoppingcart-1_master/tests/ui.AcceptanceTest/reports:/opt/robotframework/reports -v /var/jenkins_home/workspace/workshop-shoppingcart-1_master/tests/ui.AcceptanceTest:/opt/robotframework/tests -e 'BROWSER=chrome' -e 'ROBOT_OPTIONS= --variable URL:http://docker.for.mac.localhost --variable BROWSER:firefox' siamchamnankit/sck-robot-framework

Unable to find image 'siamchamnankit/sck-robot-framework:latest' locally