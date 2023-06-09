using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_PaulBikeStore.Business.DTOs
{
    public class DTOEmployee
    {
        public int staff_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int store_id { get; set; }
        public int manager_id { get; set; }
    }

    public class PageModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? SearchText { get; set; }
    }
}
