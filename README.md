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
### design & developed by Biswa Nath Ghosh (Tapos)

