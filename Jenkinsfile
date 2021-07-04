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
                bat "\"C:/Program Files/dotnet/dotnet.exe\" run --project \"${workspace}/SimulasiCICD/SimulasiCICD.csproj\""
            }
        }
    }
}