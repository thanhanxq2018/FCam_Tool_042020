using System.Collections.Generic;

namespace FCam_Tool_042020.Models
{
    public class JSON
    {
        public string KeyLv0 { get; set; }
        public List<string> KeyLv1 { get; set; }
        public List<SubKeyLv1> KeyLv1HasSub { get; set; }

        public List<string> GenString()
        {
            var result = new List<string>();
            foreach (var keyLv1 in KeyLv1)
            {
                var trans = "\"" + KeyLv0 + "." + keyLv1 + "\"";
                result.Add(trans);
            }

            // level2

            foreach (var keyLv2 in KeyLv1HasSub)
            {
                var lv2 = keyLv2.GenStringLv2(KeyLv0);
                result.AddRange(lv2);
            }
            return result;
        }
    }
}
