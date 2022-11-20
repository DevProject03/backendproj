pipeline{
    agent any

    stages {
        stage('Initial_cleanup'){
            steps {

                dir ("${WORKSPACE}"){
                    deleteDir()
                }
                
            }
        }
        stage('checkout'){
            steps {
                script {
                    sh "git clone https://github.com/DevProject03/DevOpsproj"
                }
                
            }
        }
        stage('Restore packages') {
            steps {
                script{
                    sh "cd BankingAPIs && dotnet restore BankingAPIs"
                }
            }
        }
        stage('Unit Test'){
            steps{
                script{
                    sh "cd BankingAPIs && dotnet test --logger:trx"
                }
                
            }
        }
        stage('Build image'){
            steps{
                script{
                    sh "cd BankingAPIs && dotnet install"
                }
            }
        }
        stage('Build image'){
            steps{
                script{
                    sh "cd BankingAPIs && docker build -t lizdockerhub/dotnetapp ."
                }
            }
        }
        stage('Push image'){
            steps{
                script{
                    sh "docker login -u ${env.username} -p ${env.password}"
                    sh "docker push lizdockerhub/dotnetapp"
                }
                
            }
        }
        stage('Logout'){
            steps{
                script{
                    sh "docker logout"
                }
                
            }
        }

            

           
        
        
    }
}