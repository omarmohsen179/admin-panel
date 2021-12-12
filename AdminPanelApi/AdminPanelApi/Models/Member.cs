using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string MemberNameEn { get; set; }
        public string Note { get; set; }
        public string NoteEn { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}
