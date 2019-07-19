using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MonPingV4.Models
{
    public class PingClass
    {
        //переменная для подсчета количества icmp запросов

        //переменная вывода сообщения в окно "вывода"
        public TextOutAnswer outAnswer;

        //Метод отправки icmp запросов в цикле
        public async Task<TextOutAnswer> DoPingThreadAsync(string address)
        {
            Ping pingSender = new Ping();

            try
            {
                PingReply reply;
                {
                    {
                        var result = await Task.Run(() =>
                        {
                            reply = pingSender.Send(address);
                            Thread.Sleep(1000);
                            return reply.Status;
                        });

                        if (result == IPStatus.Success)
                        {
                            //outAnswer = "ICMP answer received - " + n + " times" + '\n';
                            //outAnswer = "ICMP answer received";
                            outAnswer = TextOutAnswer.Success;
                        }
                        else
                        {
                            //outAnswer = "Host is not available!";
                            outAnswer = TextOutAnswer.Warning;
                        }
                        return outAnswer;
                    }
                }
            }

            catch (PingException)
            {
                //outAnswer = "Invalid ip address!";
                outAnswer = TextOutAnswer.Error;
            }
            return outAnswer;
        }
    }

}
