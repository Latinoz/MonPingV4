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
        //переменная вывода сообщения в окно "вывода"
        public TextOutAnswer outAnswer;

        private async Task<IPStatus> DoWork(string address)
        {
            PingReply reply;

            Ping pingSender = new Ping();

            reply = pingSender.Send(address);
            Thread.Sleep(1000);
            return reply.Status;
        }

        //Метод отправки icmp запросов 
        public async Task<TextOutAnswer> DoPingThreadAsync(string address)
        { 
            try
            {                
                {
                    {                       
                        var result = await DoWork(address);

                        if (result == IPStatus.Success)
                        {                            
                            outAnswer = TextOutAnswer.Success;
                        }
                        else
                        {                            
                            outAnswer = TextOutAnswer.Warning;
                        }
                        return outAnswer;
                    }
                }
            }

            catch (PingException)
            {               
                outAnswer = TextOutAnswer.Error;
            }
            return outAnswer;
        }
    }

}
