pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Doni-99/JenkinsCICD.git'
            }
        }
        stage('Build') {
            steps {
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/SimulasiCICD.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"${workspace}/SimulasiCICD.sln\" -c Release"
            }
        }        
        stage('Docker Build') {
            steps {
                script {
                    dockerImage = docker.build("jenkinscicd")
                    dockerImage.run('-p 5000:80')
                }
            }
        }
        stage('Test'){
            steps{
                bat returnStatus: true, script: "dotnet test \"${workspace}/SimulasiCICD.UITes/SimulasiCICD.UITes.csproj\" --logger \"trx;LogFileName=unit_tests.xml\" -c Release --no-build"
                step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
            }
        }
    }
}