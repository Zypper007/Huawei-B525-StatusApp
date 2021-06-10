using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;


namespace Router
{
    // Metody rozszczerzone do xml
    public static class XmlNodeExtensions
    {
        public static TimeSpan ToTimeSpan(this XmlNode xml) => new TimeSpan((long)xml.ToUInt64() * TimeSpan.TicksPerSecond);

        public static bool ToBoolean(this XmlNode xml) => xml.InnerText == "1";

        public static UInt64 ToUInt64(this XmlNode xml) => Convert.ToUInt64(xml.EscapeInteger());

        public static int ToInt32(this XmlNode xml) => Convert.ToInt32(xml.EscapeInteger());

        public static string EscapeInteger(this XmlNode xml) => xml.InnerText != "" ? Regex.Match(xml.InnerText, @"^-?\d+|\d+").Groups[0].Value : "0";
    }
}
