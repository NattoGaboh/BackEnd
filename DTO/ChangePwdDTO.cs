using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
   //DTO=Data Transfer Option
    public class ChangePwdDTO
    {
        public string passwordBefore { get; set; }
        public string passwordNew { get; set; }
    }
}
