using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XmlUtils
{
    public class CMySection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property =
            new ConfigurationProperty(string.Empty, typeof(KeyValueCollection), null,
                ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("",Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public KeyValueCollection KeyValues
        {
            get
            {
                return (KeyValueCollection)base[s_property];
            }
        }
    }

    [ConfigurationCollection(typeof(KeyValueSetting))]
    public class KeyValueCollection : ConfigurationElementCollection
    {
        public KeyValueCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {

        }

        new public KeyValueSetting this[string name]
        {
            get
            {
                return (KeyValueSetting)base.BaseGet(name);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyValueSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((KeyValueSetting)element).Key;
        }

        public void Add(KeyValueSetting setting)
        {
            this.BaseAdd(setting);
        }

        public void Clear()
        {
            base.BaseClear();
        }

        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

    }

    public class KeyValueSetting : ConfigurationElement
    {
        [ConfigurationProperty("key",IsRequired = true)]
        public string Key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value",IsRequired = true)]
        public string Value
        {
            get { return this["value"].ToString(); }
            set { this["value"] = value; }
        }
    }
}
