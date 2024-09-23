using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager.Models
{
    public class LootItem
    {
        public LootItem(ushort id, Guid guid, string name, int min, int max)
        {
            Id = id;
            Guid = guid;
            Name = name;
            Min = min;
            Max = max;
        }

        public LootItem() { }

        [XmlAttribute]
        public ushort[] Id { get; set; }
        public bool ShouldSerializeId() => Id != null && Id.Length > 0;
        [XmlAttribute]
        public Guid Guid { get; set; }
        public bool ShouldSerializeGuid() => Guid != Guid.Empty;
        [XmlAttribute]
        public string Name { get; set; }
        public bool ShouldSerializeName() => !string.IsNullOrEmpty(Name);

        [XmlAttribute]
        public int Min { get; set; }
        [XmlAttribute]
        public int Max { get; set; }
    }
}
