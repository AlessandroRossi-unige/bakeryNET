using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum UnitsOfMeasure
    {
        [EnumMember(Value = "Kilos")]
        Kilos,
        [EnumMember(Value = "Grams")]
        Grams,
        [EnumMember(Value = "Litres")]
        Litres,
        [EnumMember(Value = "Ml")]
        Ml,
        [EnumMember(Value = "Cups")]
        Cups,
        [EnumMember(Value = "Tablespoons")]
        Tablespoons,
        [EnumMember(Value = "Teaspoons")]
        Teaspoons,
        
    }
}