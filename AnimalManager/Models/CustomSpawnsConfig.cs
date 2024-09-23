using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager.Models
{
    public class CustomSpawnsConfig
    {
        [XmlAttribute]
        public bool Enabled { get; set; }
        public bool ShouldSerializeEnabled() => Enabled;

        public int DefaultRespawnTime { get; set; }
        public int DefaultMaxRadius { get; set; }
        public bool BlockUnderwater { get; set; }
    }
}
