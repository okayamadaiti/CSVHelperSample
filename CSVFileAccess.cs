using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace CSVHelperSample
{
    internal class CSVFileAccess
    {
        internal string FileName { get; }
        internal CSVFileAccess(string fileName) { FileName = fileName; }

        //Generics で定義
        internal void NormalWrite<T>(IEnumerable<T> records)
        {            
            using var sw = new StreamWriter(FileName, true, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);            
            using var csv = new CsvHelper.CsvWriter(sw, ci);
            try
            {
                csv.WriteRecords(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Generics で定義
        internal IEnumerable<T> NormalRead<T>() 
        {
            using var sr = new StreamReader(FileName, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvReader(sr, ci);

            return csv.GetRecords<T>().ToList();
        }

        //Mapするためにクラスを固定
        internal void WithoutAgeWrite(IEnumerable<ClassData> records) {
            using var sw = new StreamWriter(FileName, true, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvWriter(sw, ci);
            csv.Context.RegisterClassMap<WithoutAgeDataClassMap>();//マップ設定
            try
            {
                csv.WriteRecords(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Mapするためにクラスを固定
        internal IEnumerable<ClassData> WithoutAgeRead()
        {
            using var sr = new StreamReader(FileName, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvReader(sr, ci);
            csv.Context.RegisterClassMap<Age0DataClassMap>();//マップ設定
            
            return csv.GetRecords<ClassData>().ToList();
        }


        //汎用
        internal void Write<R,M>(IEnumerable<R> records) where M : ClassMap
        {
            using var sw = new StreamWriter(FileName, true, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvWriter(sw, ci);
            csv.Context.RegisterClassMap<M>();                
            
            try
            {
                csv.WriteRecords(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void Write<R>(IEnumerable<R> records)
        {
            using var sw = new StreamWriter(FileName, true, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvWriter(sw, ci);
            try
            {
                csv.WriteRecords(records);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //汎用
        internal IEnumerable<R> Read<R,M>() where M : ClassMap
        {
            using var sr = new StreamReader(FileName, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvReader(sr, ci);
            csv.Context.RegisterClassMap<M>();//マップ設定

            return csv.GetRecords<R>().ToList();
        }

        //汎用
        internal IEnumerable<R> Read<R>()
        {
            using var sr = new StreamReader(FileName, Encoding.UTF8);
            var ci = new CultureInfo("ja-JP", false);
            using var csv = new CsvHelper.CsvReader(sr, ci);
            return csv.GetRecords<R>().ToList();
        }

    }
}
