using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * [Método principal]
 * 
 * @Version 05-Jun-2022 , 1.0.0.0
 */
namespace CreatePeers
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePeers.Services.CreatePeers create = new CreatePeers.Services.CreatePeers();

            create.created();
        }
    }
}
