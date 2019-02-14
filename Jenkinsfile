pipeline {
    agent any
    environment {
        PATH = "$PATH:/usr/local/bin"
    }
    stages {
      stage('Build') {
            steps {
                echo 'Building..'
                sh 'docker build -t workshop-shoppingcart-api-test .'
            }
        }
        stage('Run Unit and Integrate Test') {
            parallel {
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
            }
        }
        stage('Setup Integrate Test Environment') {
            steps {
                
                echo '# Start Server'
                echo '## Build Docker Image for DB, API, UI'
                sh 'docker-compose build'

                echo '## Start Container for DB, API, UI'
                sh 'docker-compose up'

                sh 'sleep 15'

                echo '# Data Migration into Mysql'
                echo '## run docker liquibase\'s image to migrate data from changelog.yml'
                

                dir("data") {
                    script {
                        def workspace = pwd()
                        def myVar = "${env.BASE_PATH}"

                        def outter_docker_workspace = workspace.replace("/var/jenkins_home",myVar)

                        sh "docker run --rm -v $outter_docker_workspace:/liquibase/ -e \"LIQUIBASE_URL=jdbc:mysql://docker.for.mac.localhost/workshop_shoppingcart\" -e \"LIQUIBASE_USERNAME=root\" -e \"LIQUIBASE_PASSWORD=1234\" -e \"LIQUIBASE_CHANGELOG=/liquibase/changelog.yml\" webdevops/liquibase:mysql update"
                    }
                }
            }
        }
        stage('Run UI Integrate Test') {
            parallel {
                stage('Test On Chrome') {
                    steps {
                        dir("tests/ui.AcceptanceTest/") {
                            script {
                                def workspace = pwd()
                                def myVar = "${env.BASE_PATH}"

                                def outter_docker_workspace = workspace.replace("/var/jenkins_home",myVar)
            
                                sh "docker run --rm -v $outter_docker_workspace/chrome/reports:/opt/robotframework/reports -v $outter_docker_workspace:/opt/robotframework/tests -e ROBOT_OPTIONS=\" --variable URL:http://docker.for.mac.localhost --variable BROWSER:firefox\" siamchamnankit/sck-robot-framework"
                            }
                        }
                    }
                }
                stage('Test On Firefox') {
                    steps {
                        dir("tests/ui.AcceptanceTest/") {
                            script {
                                def workspace = pwd()
                                def myVar = "${env.BASE_PATH}"

                                def outter_docker_workspace = workspace.replace("/var/jenkins_home",myVar)
            
                                sh "docker run --rm -v $outter_docker_workspace/firefox/reports:/opt/robotframework/reports -v $outter_docker_workspace:/opt/robotframework/tests -e ROBOT_OPTIONS=\" --variable URL:http://docker.for.mac.localhost --variable BROWSER:firefox\" siamchamnankit/sck-robot-framework"
                            }
                        }                        
                    }
                }
                stage('Test On Safari') {
                    steps {
                        dir("tests/ui.AcceptanceTest/") {
                            script {
                                def workspace = pwd()
                                def myVar = "${env.BASE_PATH}"

                                def outter_docker_workspace = workspace.replace("/var/jenkins_home",myVar)
            
                                sh "docker run --rm -v $outter_docker_workspace/safari/reports:/opt/robotframework/reports -v $outter_docker_workspace:/opt/robotframework/tests -e ROBOT_OPTIONS=\" --variable URL:http://docker.for.mac.localhost --variable BROWSER:firefox\" siamchamnankit/sck-robot-framework"
                            }
                        }                        
                    }
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
