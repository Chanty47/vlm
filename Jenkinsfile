pipeline{
    agent any
    stages{
        stage('Checkout'){
            steps{
                git 'https://github.com/Chanty47/vlm'
            }
        }
        stage('restore the dependencies'){
            steps{
                sh 'dotnet restore'
            }
        }

        stage('build'){
            steps{
                sh 'dotnet build'
            }
        }

        stage('publish'){
            steps{
                sh 'dotnet publish -c release -o ./publish'
            }
        }    
        
        stage('deploy'){
            steps{
                sh """
                    sudo docker stop vlm
                    sudo docker rm vlm

                    sudo docker build -t vlm .
                    sudo docker run -d -p 5000:5000 --name vlm vlm
                """
            }

        }
    }

}