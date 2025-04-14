pipeline{
    agent any
    stages{
        stage('Checkout'){
            steps{
                git 'https://github.com/Chanty47/vlm'
            }
        }
        stage('firewall'){
            steps{
                sh 'sudo ufw allow 5000'
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