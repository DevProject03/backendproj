pipeline{
    agent any

    stages{
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
                    sh "git clone https://github.com/DevProject03/backendproj"
                }
                
            }
        }
        stage('Restore packages') {
            steps {
                script{
                    sh "cd backendproj && dotnet restore BankingAPIs"
                }
            }
        }
        
        stage('SonarQube analysis') {
           
            steps{
//                  def sqScannerMsBuildHome = tool 'SonarScanner'
                script{
                 withSonarQubeEnv('sonarqube-9.7.1') {
                    sh "dotnet-sonarscanner begin k:backendapp d:sonar.host.url=https://72e8-41-58-130-138.eu.ngrok.io d:sonar.login=sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4"
                    sh "dotnet build"
                    sh "dotnet sonarscanner end d:sonar.login=sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4"
//                  }
//                 script{
//                    sh "cd backendproj/BankingAPIs && dotnet tool install --global dotnet-sonarscanner --version 5.8.0"
//                    sh "cd backendproj/BankingAPIs && dotnet-sonarscanner begin k:backendapp d:sonar.host.url=https://72e8-41-58-130-138.eu.ngrok.io d:sonar.login=sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4"
//                    sh "cd backendproj/BankingAPIs && dotnet build"
//                    sh "cd backendproj/BankingAPIs && dotnet sonarscanner end d:sonar.login=sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4"
//                 } 
                 }
             }
                
        }

        stage('Build'){
            steps{
                script{
                    sh "cd backendproj && dotnet build BankingAPIs"
                }
            }
        }
         stage('Publish'){
            steps{
                script{
                    sh "cd backendproj && dotnet publish BankingAPIs"
                 }
            }
        }
    
        stage('Build image'){
            steps{
                script{
                    sh "cd backendproj && docker build -t lizdockerhub/dotnetapp ."
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
