using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class Text
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public int SectionId { get; set; }
        [JsonIgnore]
        public Section Section { get; set; }
    }
}
