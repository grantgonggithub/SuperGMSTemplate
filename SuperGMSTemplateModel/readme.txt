这个项目里存放的是数据库表生成的Models和DBContext,为了说明适用过程，这里提供了创建库和表的示例脚本（mysql）	dbscript/supergms_user.sql
创建完数据库和表在VS的当前项目中打开	NuGet包管理器-->程序包管理器控制台  执行如下命令行脚本：
Scaffold-DbContext "Data Source=192.168.0.20;port=3306;Initial Catalog=supergms_user;user id=supergms;password=supergms_*123456;" "Pomelo.EntityFrameworkCore.Mysql" -o "supergms_user_db_models"

这样就会在当前项目，这里是SuperGMSTemplateModel目录下生成数据库中的所有Models

Data Source=您的数据库链接地址；
port=你的数据库端口号
Initial Catalog=你要生成的数据库实例名称
user id=数据库登录用户名
password=登录密码
-o 后面的 supergms_user_db_models 表示输出的目录