# Open API SDK for .Net Core developers

原sdk是建议直接下载编译链接使用的，但是如果你和我一样在使用dotnet core 1.1/2.0 mvc，可能会和我一样遇到
`Cannot find compilation library location for package`错误。参考链接：

* https://github.com/dotnet/core-setup/issues/3397
* https://github.com/dotnet/core-setup/issues/2981

基本解决方案就是不用直接引用，而是使用nuget包，所以这里我就上传了一份可以用的版本。

## Dependence

- 支持 .Net Core 1.0 及以上版本；

## Nuget

只要短信功能的话：
```
PM> Install-Package IcerDesign.Aliyun.Acs.Sms -Version 1.0.1 
```

如果需要其他功能，可能需要：
```
PM> Install-Package IcerDesign.Aliyun.Acs.Core -Version 1.0.0 
```

## Example

```cs
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;
using System;
    
class Sample
{
    static void Main(string[] args)
    {
	TestDescribeInstanceAttribute();
    }
     
    private static void TestDescribeInstanceAttribute()
    {
	
	IClientProfile clientProfile = DefaultProfile.GetProfile("cn-hangzhou", "<your access key id>", "<your access key secret>");
	DefaultAcsClient client = new DefaultAcsClient(clientProfile);
	
	DescribeInstanceAttributeRequest request = new DescribeInstanceAttributeRequest();
	request.InstanceId = "<your instances id>";
	try
	{
	    DescribeInstanceAttributeResponse response = client.GetAcsResponse(request);
	    Console.Write(response.InstanceId);
	}
	catch (ServerException e)
	{
	    Console.WriteLine(e.ErrorCode);
	    Console.WriteLine(e.ErrorMessage);
	}
	catch (ClientException e)
	{
	    Console.WriteLine(e.ErrorCode);
	    Console.WriteLine(e.ErrorMessage);
	}
    }
}
```

发送短信的示例：

```cs
//以下字段换成自己的
string regionId = "cn-hangzhou";
string accessKeyId = "xxxxxxxxxxxxxxxx";
string accessKeySecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
string signName = "xx";
string phoneNumbers = "xxxxxxxxxxx";
string templateCode = "SMS_xxxxxxxxx";
string templateParam = "{\"code\":\"000000\"}";


IClientProfile clientProfile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
DefaultProfile.AddEndpoint(regionId, regionId, "Dysmsapi", "dysmsapi.aliyuncs.com");

IAcsClient acsClient = new DefaultAcsClient(clientProfile);

var request = new SendSmsRequest();

request.SignName = signName;
request.TemplateCode = templateCode;
request.PhoneNumbers = phoneNumbers;
request.TemplateParam = templateParam;

try
{
    var response = acsClient.GetAcsResponse(request);
}
catch (Exception ex)
{

}
```

## Questions

1. 怎么判断API调用成功？

	通过catch异常判断API是否调用成功，当 API 的 http status>=200 且 <300 表示API调用成功；当http status>=300且<500 SDK抛ClientException；当http status >=500 SDK 抛 ServerException

2. IClientProfile clientProfile = DefaultProfile.GetProfile("< your request regionid >", "< your access key id >", "< your access key secret >");

	此处的regionid参数指你需要操作的region的id，例如要操作杭州region，则regionid=cn-hangzhou；默认填cn-hangzhou.

3. docker for linux 环境中，如何无错运行Aliyun SDK Application?
请在Dockerfile中指定FROM microsoft/dotnet:latest, 而不是FROM microsoft/aspnetcore:latest.

## Authors && Contributors

- [Ma Lijie](https://github.com/malijiefoxmail)
- [Allen Cai](https://github.com/VAllens)
- [Icer Liang](https://github.com/wizicer)

## License

licensed under the [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0.html)
