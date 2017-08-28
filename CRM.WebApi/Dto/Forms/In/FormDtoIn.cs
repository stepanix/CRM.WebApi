using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.WebApi.Dto.Form.In
{
    public class FormDtoIn
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fields { get; set; }
    }
}