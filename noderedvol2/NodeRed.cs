using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
namespace noderedvol2
{
    public class NodeRed
    {
        String messageFromPLC;
        DataFromPLC data;
        public void subscribe()
        {
            IPAddress ip = new IPAddress(new byte[4] { 192, 168, 0, 100 });
            MqttClient mqttClient = new MqttClient(ip);

            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

            mqttClient.Connect(Guid.NewGuid().ToString(), "falcon98", "admin");

            Console.WriteLine("Substriber: FromNodeRed");

            mqttClient.Subscribe(new string[] { "fromNodeRed" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }


        public void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String message = System.Text.Encoding.UTF8.GetString(e.Message);
            messageFromPLC = message;
            data = JsonConvert.DeserializeObject<DataFromPLC>(messageFromPLC);
            Console.WriteLine(data.iSetPoint);

            Console.WriteLine(message);
        }
    }
}
