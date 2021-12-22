using System;
using System.Collections.Generic;
using System.Text;

namespace Dinglo.Domain.Models.Results
{
    public class UserModelResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }

        public UserModelResult()
        {

        }
    }
}
