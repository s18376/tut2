using System;
using System.Xml.Serialization;

namespace TutorialSolution2
{
    [Serializable]
    [XmlType("student")]
    public class Student
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")] public string LastName { get; set; }

        [XmlElement(ElementName = "IndexNumber")]
        public string IndexNumber { get; set; }

        [XmlElement(ElementName = "BirthDate")]
        public string BirthDate { get; set; }

        [XmlElement(ElementName = "E-Mail")] public string Email { get; set; }

        [XmlElement(ElementName = "MotherName")]
        public string MotherName { get; set; }

        [XmlElement(ElementName = "FatherName")]
        public string FatherName { get; set; }

        [XmlElement(ElementName = "Studies")] public Studies studies { get; set; }
    }
}