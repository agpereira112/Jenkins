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
            dir('MeuApp') {
                bat 'dotnet --info'
                bat 'dotnet restore MeuApp.csproj'
            }

            dir('MeuApp_Tests') {
                bat 'dotnet restore MeuApp_Tests.csproj --force'
            }
        }

        stage('Compilar (.NET)') {
            dir('MeuApp') {
                bat 'dotnet build MeuApp.csproj --configuration Release --no-restore'
            }

            dir('MeuApp_Tests') {
                bat 'dotnet build MeuApp_Tests.csproj --configuration Release --no-restore'
            }
        }

        stage('Executar Testes (.NET)') {
            dir('MeuApp_Tests') {
                bat 'dotnet test MeuApp_Tests.csproj --verbosity minimal'
            }
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
