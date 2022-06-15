using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePeers.Models
{
    /**
    * [Clase para calcular los peers a crear]
    * 
    * @Version 05-Jun-2022 , 1.0.0.0
    */
    class NumbersPeer
    {
        public int from { get; set; }
        public int until { get; set; }

        public NumbersPeer(int _from, int _until)
        {
            from = _from;
            until = _until;
        }
    }
}
