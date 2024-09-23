using RestoreMonarchy.AnimalButcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager.Models
{
    public class AnimalSpawn
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public ushort[] AnimalId { get; set; }
        [XmlAttribute]
        public uint RespawnTime { get; set; }
        public bool ShouldSerializeRespawnTime() => RespawnTime != 0;
        [XmlAttribute]
        public float Radius { get; set; }
        public bool ShouldSerializeRadius() => Radius != 0;

        [XmlAttribute]
        public float X { get; set; }
        [XmlAttribute]
        public float Y { get; set; }
        [XmlAttribute]
        public float Z { get; set; }
    }
}
