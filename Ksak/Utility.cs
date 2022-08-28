using System;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeqDistKPlus
{
    static class Utility
    {
        public static long GetFastaFileSequenceLength(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return 0L;
            }
            var sequenceText = File.ReadAllText(filePath);
            var length = 0L;
            foreach (var line in File.ReadLines(filePath))
            {
                if (!line.StartsWith(">"))
                {
                    length += line.Length;
                }
            }
            return length;
        }

        public static Dictionary<string, string> GetFastFileConfigs(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            var configStr = File.ReadAllLines(filePath).FirstOrDefault();
            if (configStr.StartsWith(">"))
            {
                return GetConfigs(configStr);
            }
            return null;
        }

        public static string SerializeConfigs(IDictionary<string, string> configs)
        {
            return $"{{{{{string.Join("}}{{", from configKv in configs select $"{configKv.Key}: {configKv.Value}")}}}}}";
        }

        public static Dictionary<string, string> GetConfigs(string configStr)
        {
            var a = configStr.Split(new string[] { "{{" }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            var b = from c in a select c.Split(new string[] { "}}" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            var result = new Dictionary<string, string>();
            foreach (var item in b)
            {
                var kvArray = item.Split(':');
                var key = kvArray[0].Trim();
                result[kvArray[0].Trim()] = kvArray[1].Trim();
            }
            return result;
        }

        public static string RemoveConfigs(string configStr)
        {
            var sb = new StringBuilder();
            var a = configStr.Split(new string[] { "{{" }, StringSplitOptions.RemoveEmptyEntries);
            sb.Append(a[0]);
            foreach (var b in a.Skip(1))
            {
                var c = b.Split(new string[] { "}}" }, StringSplitOptions.RemoveEmptyEntries);
                if (c.Length > 1)
                {
                    sb.Append(c[1]);
                }
            }
            return sb.ToString();
        }

    }
}
