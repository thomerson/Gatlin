using System;
using System.Collections.Generic;
using System.Text;

namespace Thomerson.Gatlin.Model
{
    public class BaseDbModel : BaseModel
    {
        public DateTime? CreateStamp { get; set; }
        public string CreateBy { get; set; }
        public DateTime? LastUpdateStamp { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
