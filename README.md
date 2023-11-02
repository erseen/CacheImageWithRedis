# CacheImageWithRedis
"First of all, you should run Redis as a container in Docker
docker run --name my-redis-container -p 6379:6379 -d redis  --> you can use that to run redis in your docker 

 You can change config options which is available in service registration 
 services.AddStackExchangeRedisCache(options =>
 {
     options.Configuration = "localhost:6379";

 });


