using System.Collections.Generic;

namespace FCam_Tool_042020.Models
{
    public class SubKeyLv1
    {
        public string KeyLv1 { get; set; }
        public List<string> KeyLv2 { get; set; }
        public Dictionary<string, string> KeyLv3 { get; set; }
        //
        public List<string> GenStringLv2(string KeyLv0)
        {
            var result = new List<string>();
            foreach (var lv2 in KeyLv2)
            {
                var trans = "\"" + KeyLv0 + "." + KeyLv1 + "." + lv2 + "\"";
                result.Add(trans);
            }

            // level2
            return result;
        }
    }
}
