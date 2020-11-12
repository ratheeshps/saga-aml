using AmlService.Repository;
using MassTransit;
using rabbitmqbus;
using sagamessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmlService
{
    
    public class AmlValidateSagaConsumer : IConsumer<IAmlValidationEvent>
    {
        public async Task Consume(ConsumeContext<IAmlValidationEvent> context)
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
                    RemitterID = remitterData.RemitterID
                });
                var endpoint = await context.GetSendEndpoint(new Uri("queue:" + BusConfiguration.AmlQueueName));

                await endpoint.Send<IAmlData>(new
                {
                    RemitterID = remitterData.RemitterID,
                    AmlStatus = "Block",
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
                var endpoint = await context.GetSendEndpoint(new Uri("queue:" + BusConfiguration.AmlQueueName));

                await endpoint.Send<IAmlData>(new
                {
                    RemitterID = remitterData.RemitterID,
                    AmlStatus = "Allow",
                });
                await Task.FromResult(true);
            }
            await Task.FromResult(false);
        }
    }
}
