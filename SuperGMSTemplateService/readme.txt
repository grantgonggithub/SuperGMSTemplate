�����Ŀ��SuperGMS��һ��ʾ����Ŀ https://github.com/grantgonggithub/SuperGMS.git

1��SuperGMSTemplateService��Service�㣬������Ŀ����Ҫ����SuperGMSTemplateModel��Model�㣩��SuperGMSTemplateDto��Dto�㣩����ʵ���Ǹ�����ṹ

2��SuperGMSTemplateService������Ը��ݻ�����������ļ������������л�����ӱ���ֵ�� 
   �磺���Ի���a��ASPNETCORE_ENVIRONMENT=test_a
	   ���Ի���b: ASPNETCORE_ENVIRONMENT=test_b
	   Ԥ����������ASPNETCORE_ENVIRONMENT=pre
	   ��ʽ������ASPNETCORE_ENVIRONMENT=prod
   ������Ҫ�Զ������ּ��ɣ��������ñ���������ļ���Ӧ���統ǰ��Ŀ�ṩ��5�ֻ����������ļ�
   (�ļ�����Ҫ����Ϊʼ��������ݣ��ڶ�Ӧ���ļ����Ҽ�-->����->���Ƶ����Ŀ¼��ѡ��ʼ�ա������ɲ�����ѡ�����ݡ�)
   �������ػ�����Ĭ�ϣ���config.json 
   ���Ի���a           : config.test_a.json
   ���Ի���b		   : config.test_b.json
   Ԥ��������          : config.pre.json
   ��ʽ����			   : config.prod.json
   ע�⣺��Ŀ�е������ļ���ָ���ļ���������ʵ�ʵ����ã���ָ�����������ĵĵ�ַ���������ĵ����ͣ��μ���Ӧ�������ļ�
         �������������Zookeeper��Nacosϵͳ��һ��������Ĭ�ϳ�ʼ�����ã���Щ���û���Ҫ�����ݾ�����������޸ģ������ô���ʱ���Ͳ��ٳ�ʼ��


***************�ص�˵��****************

һ�����ݿ������޸�
��һ������·��config��������ã����ݿ����ã�
	1��ִ����ĿSuperGMSTemplateModel �µ� dbscript-->supergms_user.sql �������ݿ�ͱ�
	1��database.config-->DataBaseInfo-->supergms_userContext-->UserName,PassWord �ĳɶ�Ӧ�����ݿ���˺ź����룻

�������������߱�������
 ��һ������config.json �еģ��������ã��޸������ֱ������Ŀ��
	1��ServerConfig-->RpcService-->IP�޸�Ϊ���㱾�ػ��߻���ip����ͬ��ֵ��
	2��RedisConfig-->Nodes-->Server��Port��Pwd �ĳ��㻷���е�redis��ip��Port�����룻
	3��RpcClients-->Clients-->Ip �ĳ��㱾�ػ��߶�Ӧ������ip��

  ������������������Nacos����һ����Ŀ���Զ���ʼ�����ýṹ��Ȼ����Ҫ����ʵ�ʻ����޸Ĳ�������ip��
	1��ֻ�ý��������ĵ�ַ�޸�ΪNacos�ĵ�ַ���ɣ�����μ�config.test_b.json
	2��config.test_b.json-->Ip��Ϊ���Ӧ������Nacos��ַ�Ͷ˿ڼ���

  ������������������Zookeeper
	1��ֻ�ý��������ĵ�ַ�޸�ΪZookeeper�ĵ�ַ���ɣ�����μ�config.prod.json
	2��config.prod.json-->Ip��Ϊ���Ӧ������Zookeeper��ַ�Ͷ˿ڼ���

  ���ģ�������������WebApi��Url
	1��ֻ�ý��������ĵ�ַ�޸�Ϊ�����ļ���Url��ַ���ɣ�����μ�config.test_a.json
	2��config.test_a.json-->Ip��Ϊ���Ӧ�����������ļ���Url��ַ����

��ʹ�ù��������κ���������ϵ���ߣ����ڵ�һʱ�����������
