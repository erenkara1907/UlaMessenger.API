using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
