pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Chanty47/vlm'
            }
        }
        stage('docker') {
            steps {
                sh 'sudo apt install docker.io'
            }
        }
        stage('firewall') {
            steps {
                sh 'sudo ufw allow 5000'
            }
        }
        stage('deploy') {
            steps {
                sh """
                    if [ \$(sudo docker ps -a -q -f name=vlm) ]; then
                        sudo docker stop vlm
                        sudo docker rm vlm
                    else
                        echo "Container is not running"
                    fi
                    
                    # Build and run the container
                    sudo docker build -t vlm .
                    sudo docker run -d -p 5000:5000 --name vlm vlm
                """
            }
        }
    }
}
