# jianjian.EasyRedis

#set



 services.AddJianjianRedisCache(option =>
            {
                option.Database = 3;
                option.Endpoints.Add(new JianJian.EasyRedis.Base.ServerEndPoint("", 6000));
            });
            
     
#use


  public IJianjianEasyCachingProvider jianjianEasyCachingProvider { get; set; }

