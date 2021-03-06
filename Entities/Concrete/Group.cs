using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Group:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public byte[] GroupPhoto { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
