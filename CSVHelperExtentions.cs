using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel;

namespace CSVHelperSample
{
    /// <summary>
    /// 年齢をマスクする
    /// </summary>
    internal class WithoutAgeDataClassMap : ClassMap<ClassData>
    {
        internal WithoutAgeDataClassMap()
        {
            Map(m => m.Name).Index(0).Name("名前");//そのまま出力
            Map(m => m.Age).Convert(a => string.Empty).Index(1).Name("年齢");
            Map(m => m.Job).TypeConverter<EnumDescriptionConverter<JobType>>().Index(2).Name("職業");
        }
    }
    /// <summary>
    /// 年齢を0として読み込む
    /// </summary>
    internal class Age0DataClassMap : ClassMap<ClassData>
    {
        internal Age0DataClassMap()
        {
            Map(m => m.Name).Index(0).Name("名前");//そのまま出力
            Map(m => m.Age).Convert(a => 0).Index(1).Name("年齢");
            Map(m => m.Job).TypeConverter<EnumDescriptionConverter<JobType>>().Index(2).Name("職業");
        }
    }

    /// <summary>
    /// CSVHelper Converter 追加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumDescriptionConverter<T> : CsvHelper.TypeConversion.EnumConverter where T : Enum
    {
        Dictionary<string, T> DescriptionMapping = new Dictionary<string, T>();
        public EnumDescriptionConverter() : base(typeof(T))
        {
            T temp;
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                temp = (T)Enum.Parse(typeof(T), item, true);
                DescriptionMapping.Add(temp.GetEnumDescription(), temp);
            }

        }
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (!value.GetType().IsEnum) throw new InvalidEnumArgumentException();
            return ((Enum)value).GetEnumDescription();
        }

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            DescriptionMapping.TryGetValue(text, out var value);
            if (value is null) throw new NotImplementedException("Description未定義");
            return value;
        }

    }

}
