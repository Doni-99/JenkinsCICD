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
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/SimulasiCICD.sln\""
            }
        }        
        stage('Docker Build') {
            steps {
                script {
                    dockerImage = docker.build("JenkinsCiCd")
                }
            }
        }
        stage('Test'){
            steps{
                bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/SimulasiCICD.UITes/SimulasiCICD.UITes.csproj\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
                step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
            }
        }
    }
}