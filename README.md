# asp net core 5 docker complete solution

## Important Docker Command

``
docker run --name my-redis -p 6379:6379 -d --network="tapos-test" redis 
``

``docker run --name my-percona -e MYSQL_ROOT_PASSWORD=tapos007 -p 3306:3306 -d --network="tapos-test" percona:8.0
``

``docker run --name my-myadmin -d --link my-percona:db -p 8080:80 --network="tapos-test" phpmyadmin
``


``
docker run --name my-dotnetcore  -p 8777:80 \
-e "ConnectionStrings:DefaultConnection"="server=my-percona;user=root;password=tapos007;database=fordocker" \
-e "RedisSetup:MyRedisConStr"="my-redis" \
-e "RedisSetup:InstanceName"="mytestInstance" \
--network="tapos-test" \
-d my-docker:1.0
``

## setup jenkins server 

```
docker run -d --name my-jenkins -v jenkins_home:/var/jenkins_home -p 8080:8080 -p 50000:50000 jenkins/jenkins:lts-jdk11

docker rm -f my-jenkins

docker run -d --name my-jenkins \
 -v jenkins_home:/var/jenkins_home  \
 -v /var/run/docker.sock:/var/run/docker.sock \
 -v $(which docker):/usr/bin/docker \
 -p 8080:8080 -p 50000:50000  \
 jenkins/jenkins:lts-jdk11

docker exec -u 0  -it my-jenkins /bin/bash
chmod 666 /var/run/docker.sock

apt update 
apt install wget

wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
 &&
dpkg -i packages-microsoft-prod.deb &&
rm packages-microsoft-prod.deb
ta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pos
```
### design & developed by Biswa Nath Ghosh (Tapos)

