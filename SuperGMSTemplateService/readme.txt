这个项目是SuperGMS的一个示例项目 https://github.com/grantgonggithub/SuperGMS.git

1、SuperGMSTemplateService是Service层，是主项目，需要引用SuperGMSTemplateModel（Model层）和SuperGMSTemplateDto（Dto层），其实就是个三层结构

2、SuperGMSTemplateService下面可以根据环境添加配置文件，都是在运行环境添加变量值： 
   如：测试环境a：ASPNETCORE_ENVIRONMENT=test_a
	   测试环境b: ASPNETCORE_ENVIRONMENT=test_b
	   预发布环境：ASPNETCORE_ENVIRONMENT=pre
	   正式环境：ASPNETCORE_ENVIRONMENT=prod
   根据需要自定义名字即可，环境配置必须跟配置文件对应，如当前项目提供了5种环境的配置文件
   (文件属性要设置为始终输出内容，在对应的文件上右键-->属性->复制到输出目录，选择“始终”，生成操作，选择“内容”)
   开发本地环境（默认）：config.json 
   测试环境a           : config.test_a.json
   测试环境b		   : config.test_b.json
   预发布环境          : config.pre.json
   正式环境			   : config.prod.json
   注意：项目中的配置文件是指向文件，并不是实际的配置，他指向了配置中心的地址，配置中心的类型，参见对应的配置文件
         如果配置中心是Zookeeper、Nacos系统第一次启动会默认初始化配置，这些配置还需要您根据具体情况进行修改，当配置存在时，就不再初始化


***************重点说明****************

一、数据库配置修改
（一）、将路径config下面的配置（数据库配置）
	1、执行项目SuperGMSTemplateModel 下的 dbscript-->supergms_user.sql 创建数据库和表；
	1、database.config-->DataBaseInfo-->supergms_userContext-->UserName,PassWord 改成对应的数据库的账号和密码；

二、配置中心走本地配置
 （一）、将config.json 中的（本地配置，修改完可以直接跑项目）
	1、ServerConfig-->RpcService-->IP修改为跟你本地或者环境ip段相同的值；
	2、RedisConfig-->Nodes-->Server，Port，Pwd 改成你环境中的redis的ip，Port，密码；
	3、RpcClients-->Clients-->Ip 改成你本地或者对应环境的ip；

  （二）、配置中心走Nacos（第一跑项目会自动初始化配置结构，然后需要根据实际环境修改部分配置ip）
	1、只用将配置中心地址修改为Nacos的地址即可，详情参见config.test_b.json
	2、config.test_b.json-->Ip改为你对应环境的Nacos地址和端口即可

  （三）、配置中心走Zookeeper
	1、只用将配置中心地址修改为Zookeeper的地址即可，详情参见config.prod.json
	2、config.prod.json-->Ip改为你对应环境的Zookeeper地址和端口即可

  （四）、配置中心走WebApi的Url
	1、只用将配置中心地址修改为配置文件的Url地址即可，详情参见config.test_a.json
	2、config.test_a.json-->Ip改为你对应环境的配置文件的Url地址即可

在使用过程中有任何问题请联系作者，会在第一时间帮你解答问题
