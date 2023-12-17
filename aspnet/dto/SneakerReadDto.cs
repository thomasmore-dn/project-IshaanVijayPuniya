using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.dto
{
    public class SneakerReadDto
    {
        public int Id { get; set; }
        public String Title { get; set; } = "";
        public String Description { get; set; } = "";
        public Double Price { get; set; }
        public String Picture { get; set; }
    }
}