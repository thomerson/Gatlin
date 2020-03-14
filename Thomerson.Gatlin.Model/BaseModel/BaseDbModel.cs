using System;
using System.Collections.Generic;
using System.Text;

namespace Thomerson.Gatlin.Model
{
    public class BaseDbModel : BaseModel
    {
        public DateTime? LastUpdateStamp { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
