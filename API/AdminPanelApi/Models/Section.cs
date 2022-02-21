using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class Section
    {
        public int Id{ get; set; }
        public string SectionName{ get; set; }
        public int Index { get; set; }

        public IEnumerable<Text> Text { get; set; }
        public SectionImages Image { get; set; }
    }
}
