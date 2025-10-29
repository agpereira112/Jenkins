pipeline {
    agent any

    stages {
        stage('Clonar Repositório') {
            steps {
                git branch: 'main', url: 'https://github.com/agpereira112/Jenkins.git'
            }
        }

        stage('Restaurar Dependências') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Compilar Projeto') {
            steps {
                bat 'dotnet build --no-restore'
            }
        }

        stage('Executar Testes Automatizados') {
            steps {
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }

    post {
        success {
            echo "✅ Build e testes executados com sucesso!"
        }
        failure {
            echo "❌ Falha na execução dos testes ou build."
        }
    }
}