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
<<<<<<< HEAD
                    if[/$(sudo docker ps -a -q -f name=vlm)];then
                    sudo docker stop vlm
                    sudo docker rm vlm
                    else
                    echo "Container is not running"
=======
>>>>>>> 3f152eb24f1c861def88e28a0a7e0999a22cb764

                    sudo docker build -t vlm .
                    sudo docker run -d -p 5000:5000 --name vlm vlm

                    fi
                """
            }

        }
    }

}
