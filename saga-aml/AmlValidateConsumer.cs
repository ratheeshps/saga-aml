using AmlService.Repository;
using MassTransit;
using rabbitmqbus;
using sagamessages;
using System;
using System.Threading.Tasks;

namespace AmlService
{

    public class AmlValidateConsumer : IConsumer<IRemitterMessage>
    {
        public async Task Consume(ConsumeContext<IRemitterMessage> context)
        {
            AmlDataAccess amlDataAccess = new AmlDataAccess();
            var remitterData = context.Message;
            if (remitterData.RemitterFirstName.Contains("modi"))
            {
                amlDataAccess.SaveData(new Models.AmlData
                {
                    AmlStatus = "Block",
                    CountryName = remitterData.RemitterCountry,
                    CustomerName = String.Format($"{remitterData.RemitterFirstName} {remitterData.RemitterLastName}"),
                    RemitterID=remitterData.RemitterID
                });
                var endpoint = await context.GetSendEndpoint(new Uri("queue:" + BusConfiguration.AmlQueueName));

                await endpoint.Send<IAmlData>(new
                {
                    RemitterID = remitterData.RemitterID,
                    AmlStatus = remitterData.RemitterStatus,
                });
                await Task.FromResult(true);
            }
            else
            {
                amlDataAccess.SaveData(new Models.AmlData
                {
                    AmlStatus = "Allow",
                    CountryName = remitterData.RemitterCountry,
                    CustomerName = String.Format($"{remitterData.RemitterFirstName} {remitterData.RemitterLastName}"),
                    RemitterID = remitterData.RemitterID
                });
               
                await Task.FromResult(true);
            }
            await Task.FromResult(false);
        }
    }
}
