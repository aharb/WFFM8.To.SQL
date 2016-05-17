using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WFFM8.To.SQL.Model
{
    public interface IForm
    {
        [DataMember]
        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false)]
        Guid Id { get; }

        [DataMember]
        [EdmScalarProperty(IsNullable = false)]
        Guid FormItemId { get; set; }

        [DataMember]
        [EdmScalarProperty(IsNullable = false)]
        Guid InteractionId { get; set; }

        [DataMember]
        [EdmScalarProperty(IsNullable = false)]
        Guid ContactId { get; set; }

        [EdmScalarProperty]
        [DataMember]
        DateTime Timestamp { get; }

        [SoapIgnore]
        [XmlIgnore]
        [DataMember]
        IEnumerable<IField> Field { get; set; }

        [EdmScalarProperty]
        [DataMember]
        string Data { get; set; }
    }
}
