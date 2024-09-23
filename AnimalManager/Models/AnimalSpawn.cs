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
        [XmlAttribute]
        public decimal Radius { get; set; }

        public PositionData Position { get; set; }
    }
}
