<h5>#CacheImageWithRedis </h5>
<h3>#Step 1 Run Redis In Docker  </h3>

<p>First of all, you should run Redis as a container in Docker. You can use the following command to run Redis in your Docker</p>

 <p>"docker run --name my-redis-container -p 6379:6379 -d redis "</p>
<h3>#Step3 Configure Redis in Your Application</h3>
<p> You can change config options which is available in service registration </p>
 
 "services.AddStackExchangeRedisCache(options =>
 {
     options.Configuration = "localhost:6379";

 });"


