using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    public class BeLoginResult
    {
        public bool Success { get; set; }
        public BeUser User { get; set; }
        public string Message { get; set; }
        public BeLoginResult()
        {

        }
        public BeLoginResult(bool Success, string Message, BeUser User)
        {
            this.Success = Success;
            this.Message = Message;
            this.User = User;
        }
    }
}
