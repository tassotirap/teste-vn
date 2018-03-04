using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViajaNet.Test.DataInsert
{
    class Program
    {
        static void Main(string[] args)
        {
           var client = new ApiClient();
            client.Run();
        }
    }
}
