node {
    def repoUrl = 'https://github.com/agpereira112/Jenkins.git'

    try {
        stage('Preparar Workspace') {
            deleteDir() 
        }

        stage('Checkout') {
            checkout([$class: 'GitSCM',
                      branches: [[name: '*/main']],
                      userRemoteConfigs: [[url: repoUrl]]
            ])
        }

        stage('Restaurar Dependências (.NET)') {
            bat 'dotnet --info'
            bat 'dotnet restore'
        }

        stage('Compilar (.NET)') {
            bat 'dotnet build --configuration Release --no-restore'
        }

        stage('Executar Testes (.NET)') {
            bat 'dotnet test --no-build --verbosity minimal'
        }

        stage('Sucesso') {
            echo "✅ Build e testes concluídos com sucesso."
        }

    } catch (err) {
        echo "❌ Pipeline falhou: ${err}"
        currentBuild.result = 'FAILURE'
        throw err
    } finally {
        echo "Pipeline finalizado. Workspace: ${env.WORKSPACE}"
    }
}