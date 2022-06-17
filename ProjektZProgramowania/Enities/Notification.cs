using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Enities
{
    
    public class Notification : DefaulEntity
    {
        public enum PriorityType 
        {
            Low,
            Medium,
            High
        }

        public string title { get; set; }
        public string description { get; set; }
        public User? creator { get; set; }
        public long? creatorId { get; set; }
        public PriorityType priority { get; set; }

    }
}
