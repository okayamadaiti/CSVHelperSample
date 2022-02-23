using CsvHelper.Configuration.Attributes;

namespace CSVHelperSample
{
    public class ClassData
    {
        [Index(0), Name("名前")]
        public string Name { get; set; } = String.Empty;
        [Index(1), Name("年齢")]
        public int Age { get; set; } = 0;
        [Index(2), Name("職業"), TypeConverter(typeof(EnumDescriptionConverter<JobType>))]
        public JobType Job { get; set; } = JobType.NoJob;
    }

    public struct StructData
    {
        public string Name { get; set; } = String.Empty;
        [Index(1), Name("年齢")]
        public int Age { get; set; } = 0;
        [Index(2), Name("職業"), TypeConverter(typeof(EnumDescriptionConverter<JobType>))]
        public JobType Job { get; set; } = JobType.NoJob;
    }
}
