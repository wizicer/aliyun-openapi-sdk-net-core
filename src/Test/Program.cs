using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20170525;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //以下字段换成自己的
            string regionId = "cn-hangzhou";
            string accessKeyId = "";
            string accessKeySecret = "";
            string signName = "";
            string phoneNumbers = "xxxxxxxxxxx";
            string templateCode = "SMS_xxxxxxxxx";
            string templateParam = "{\"code\":\"123456\"}";


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
        }
    }
}
