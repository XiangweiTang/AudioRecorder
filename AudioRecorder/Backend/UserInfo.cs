using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecorder.Backend
{
    class UserInfo
    {
        public string UserId { get; } = new Guid().ToString();
        public byte Age { get; set; } = 0;
        public string Gender { get; set; } = "U";
        public string Dialect { get; set; } = "U";
        public UserInfo(params string[] args)
        {
            UserId = Guid.NewGuid().ToString();

        }
    }
}
