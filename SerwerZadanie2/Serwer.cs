using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    [ServiceContract]
    public interface IZadanie2
    {
        [OperationContract]
        string Test(string arg);
    }

    public class Zadanie2 : IZadanie2
    {
        public string Test(string arg)
        {
            return $"{arg}";
        }
    }

    public class Serwer
    {
        public static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie2));
            host.AddServiceEndpoint(typeof(IZadanie2), new NetNamedPipeBinding(), "net.pipe://localhost/ksr-wcf1-zad2");

            host.Open();
            Console.WriteLine("Host opened");


            Console.ReadLine();
            host.Close();
            Console.WriteLine("Host closed");
            Console.ReadLine();
        }
    }
}