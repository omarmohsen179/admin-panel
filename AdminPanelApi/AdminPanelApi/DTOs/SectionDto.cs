using AdminPanelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public int Index { get; set; }

        public string Text { get; set; }
        public string Image { get; set; }
    }
}
