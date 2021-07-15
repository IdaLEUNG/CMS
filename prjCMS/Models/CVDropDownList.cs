using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCMS.Models
{
    public class CVDropDownList
    {
        public List<cMake> make { get; set; }

        public List<cModel> model { get; set; } 

        public List<cBody> body { get; set; }

        public List<cFuel> fuel { get; set; }

        public List<cGear> gear { get; set; }

        public List<cColor> color { get; set; }

        public List<cEngine> engine { get; set; }
    }
}