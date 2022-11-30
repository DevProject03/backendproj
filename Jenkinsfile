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
        
        stage('SonarQube Analysis') {
//                 def scannerHome = tool 'SonarScanner for MSBuild'
//                     withSonarQubeEnv() 
            steps{
                script{
//                     sonar-scanner -Dsonar.projectKey=Frontendapp -Dsonar.host.url=https://72e8-41-58-130-138.eu.ngrok.io -Dsonar.login=sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4"
//                    
                   sh "cd backendproj && dotnet-sonarscanner begin /k;"backendapp" /d:sonar.host.url="https://72e8-41-58-130-138.eu.ngrok.io" /d:sonar.login="sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4""
                   sh "cd backendproj && dotnet build"
                   sh "cd backendproj && dotnet sonarscanner end /d:sonar.login="sqp_6a630dc78f2e3584a8d63f0dd8608eed6dba98b4""
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
