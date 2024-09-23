using System;
using System.Xml.Serialization;

namespace RestoreMonarchy.AnimalManager.Models
{
    public class AnimalConfig
    {
        [XmlAttribute]
        public ushort Id { get; set; }
        public bool ShouldSerializeId() => Id != 0;
        [XmlAttribute]
        public Guid Guid { get; set; }
        public bool ShouldSerializeGuid() => Guid != Guid.Empty;
        [XmlAttribute]
        public string Name { get; set; }
        public bool ShouldSerializeName() => !string.IsNullOrEmpty(Name);

        [XmlArrayItem]
        public LootItem[] LootItems { get; set; }
        public bool ShouldSerializeLootItems() => LootItems != null;
    }
}
