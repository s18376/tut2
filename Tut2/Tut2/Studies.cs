using System;
using System.Xml.Serialization;

namespace TutorialSolution2
{
    [Serializable]
    public class Studies
    {
        [XmlElement("course", typeof(string))] public string Course { get; set; }

        [XmlElement("StudiesMode", typeof(string))]
        public string StudiesMode { get; set; }
    }
}