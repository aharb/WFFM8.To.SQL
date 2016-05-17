using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WFFM8.To.SQL.Model
{
    public interface IField
    {
        [DataMember]
        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false)]
        Guid Id { get; }

        [EdmScalarProperty(IsNullable = false)]
        [DataMember]
        Guid FieldId { get; set; }

        [DataMember]
        [EdmScalarProperty]
        string Data { get; set; }

        [EdmScalarProperty]
        [DataMember]
        string Value { get; set; }

        [EdmScalarProperty]
        [DataMember]
        string FieldName { get; set; }

        [SoapIgnore]
        [XmlIgnore]
        [DataMember]
        IForm Form { get; set; }
    }
}
