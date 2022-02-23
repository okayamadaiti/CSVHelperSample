using System.ComponentModel;

namespace CSVHelperSample
{
    public enum JobType
    {
        [Description("無職")]
        NoJob,
        [Description("学生")]
        Student,
        [Description("会社員")]
        OfficeWorker,
        [Description("公務員")]
        CivilServant
    }
}
