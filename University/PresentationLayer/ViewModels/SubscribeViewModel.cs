using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.PresentationLayer.ViewModels
{
    public class SubscribeViewModel
    {
        public int studentId { get; set; }

        public int courseID { get; set; }

        public List<SelectListItem> studentSelectList { get; set; }

        public List<SelectListItem> courseSelectList { get; set; }
    }
}
