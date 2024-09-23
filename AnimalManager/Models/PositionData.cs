using System.Xml.Serialization;
using UnityEngine;

namespace RestoreMonarchy.AnimalButcher.Models
{
    public class PositionData
    {
        public PositionData() { }
        public PositionData(Vector3 vector)
        {
            X = vector.x;
            Y = vector.y;
            Z = vector.z;
        }

        [XmlAttribute]
        public float X { get; set; }
        [XmlAttribute]
        public float Y { get; set; }
        [XmlAttribute]
        public float Z { get; set; }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    }
}
