using System;
using System.Runtime.Serialization;

namespace OEmbedProxy.RestAPI
{
    [DataContract]
    public class OEmbed
    {
        [DataMember]
        public string ProviderName { get; set; }
        [DataMember]
        public Uri ProviderUrl { get; set; }

        [DataMember]
        public string Height { get; set; }

        [DataMember]
        public string Width{ get; set; }
    }

    [DataContract]
    public class OEmbeddedContentProvider
    {
        [DataMember]
        public string ProviderName { get; set; }

        [DataMember]
        public string ProviderUrl { get; set; }
    }
}