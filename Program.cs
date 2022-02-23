namespace CSVHelperSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoNormal();
            DoMapping();
            DoGenerics();
            DoStruct();
        }

        //属性定義による出力と読み込み
        static void DoNormal()
        {
            //リスト作成
            List<ClassData> list = new();
            list.Add(new ClassData() { Name = "User1", Age = 22, Job = JobType.OfficeWorker });
            list.Add(new ClassData() { Name = "User2", Age = 27, Job = JobType.OfficeWorker });
            list.Add(new ClassData() { Name = "User3", Age = 16, Job = JobType.Student });
            list.Add(new ClassData() { Name = "User4", Age = 78, Job = JobType.NoJob });
            list.Add(new ClassData() { Name = "User5", Age = 45, Job = JobType.CivilServant });

            //出力
            Console.WriteLine("定義のまま出力します……");
            string fileName = $"_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            CSVFileAccess cfa = new(fileName);
            cfa.NormalWrite(list);
            Console.WriteLine("定義のまま出力しました");
            Console.ReadLine();

            //読み込み
            Console.WriteLine("同じファイルを読み込みます……");
            Console.ReadLine();
            foreach (var item in cfa.NormalRead<ClassData>())
            {
                Console.WriteLine($"{item.Name}, {item.Age}, {item.Job}");
                //Console.WriteLine($"{item.Name}, {item.Age}, {item.Job.GetEnumDescription()}");
            }
            Console.WriteLine("読み込み完了しました");
            Console.ReadLine();
        }

        //mapを定義しての出力と読み込み
        static void DoMapping()
        {
            //リスト作成
            List<ClassData> list = new();
            list.Add(new ClassData() { Name = "User2-1", Age = 22, Job = JobType.OfficeWorker });
            list.Add(new ClassData() { Name = "User2-2", Age = 27, Job = JobType.OfficeWorker });
            list.Add(new ClassData() { Name = "User2-3", Age = 16, Job = JobType.Student });
            list.Add(new ClassData() { Name = "User2-4", Age = 78, Job = JobType.NoJob });
            list.Add(new ClassData() { Name = "User2-5", Age = 45, Job = JobType.CivilServant });

            //年齢をマスクして出力
            Console.WriteLine("年齢を空文字して出力します……");
            Console.ReadLine();
            string fileName = $"_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            CSVFileAccess cfa = new(fileName);
            cfa.WithoutAgeWrite(list);
            Console.WriteLine("年齢をマスクして出力しました");
            Console.ReadLine();

            //「最初のデータ」を、今度は年齢をマスクして読み込み
            Console.WriteLine("年齢を0にマスクして読み込みます……");
            Console.ReadLine();
            foreach (var item in cfa.WithoutAgeRead())
            {
                Console.WriteLine($"{item.Name}, {item.Age}, {item.Job}");
                //Console.WriteLine($"{item.Name}, {item.Age}, {item.Job.GetEnumDescription()}");
            }
            Console.WriteLine("年齢をマスクして読み込み完了しました");
            Console.ReadLine();
        }

        //汎用的なメソッドサンプル
        static void DoGenerics()
        {
            //汎用
            //リスト作成
            List<ClassData> list = new();
            list.Add(new ClassData() { Name = "User3-1", Age = 10, Job = JobType.Student });
            list.Add(new ClassData() { Name = "User3-2", Age = 20, Job = JobType.OfficeWorker });
            list.Add(new ClassData() { Name = "User3-3", Age = 17, Job = JobType.Student });
            list.Add(new ClassData() { Name = "User3-4", Age = 3, Job = JobType.NoJob });
            list.Add(new ClassData() { Name = "User3-5", Age = 33, Job = JobType.CivilServant });
            
            //出力
            Console.WriteLine("MAPを追記しつつ出力します……");
            string fileName = $"_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            CSVFileAccess cfa = new(fileName);
            cfa.Write<ClassData, WithoutAgeDataClassMap>(list);
            Console.WriteLine("出力しました");
            Console.ReadLine();

            Console.WriteLine("MAPを追記しつつ読み込みます……");
            foreach (var item in cfa.Read<ClassData, Age0DataClassMap>())
            {
                Console.WriteLine($"{item.Name}, {item.Age}, {item.Job}");
                //Console.WriteLine($"{item.Name}, {item.Age}, {item.Job.GetEnumDescription()}");
            }
            ;
            Console.WriteLine("年齢をマスクして読み込み完了しました");
            Console.ReadLine();
        }

        //汎用的なメソッドサンプル：構造体使用
        static void DoStruct()
        {
            //汎用
            //リスト作成
            List<StructData> list = new();
            list.Add(new StructData() { Name = "User4-1", Age = 30, Job = JobType.CivilServant });
            list.Add(new StructData() { Name = "User4-2", Age = 29, Job = JobType.OfficeWorker });
            list.Add(new StructData() { Name = "User4-3", Age = 5, Job = JobType.NoJob });
            list.Add(new StructData() { Name = "User4-4", Age = 41, Job = JobType.OfficeWorker });
            list.Add(new StructData() { Name = "User4-5", Age = 35, Job = JobType.OfficeWorker });

            //出力
            Console.WriteLine("定義のまま出力します……");
            string fileName = $"_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            CSVFileAccess cfa = new(fileName);
            cfa.Write<StructData>(list);
            Console.WriteLine("定義のまま出力しました");
            Console.ReadLine();

            //読み込み
            Console.WriteLine("同じファイルを読み込みます……");
            foreach (var item in cfa.Read<StructData>())
            {
                Console.WriteLine($"{item.Name}, {item.Age}, {item.Job}");
                //Console.WriteLine($"{item.Name}, {item.Age}, {item.Job.GetEnumDescription()}");
            }
    ;
            Console.WriteLine("読み込み完了しました");
            Console.ReadLine();
        }

    }
}