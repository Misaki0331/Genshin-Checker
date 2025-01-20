using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CharacterDetailPost
{
    public class Root
    {
        public int role_id { get; set; }
        public string server { get; set; } = "";
        public List<int> character_ids { get; set; } = new();
    }
}
