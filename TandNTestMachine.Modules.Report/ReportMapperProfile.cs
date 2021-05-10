using AutoMapper;
using TandNTestMachine.Data.Entity;
using TandNTestMachine.Modules.Report.Model;

namespace TandNTestMachine.Modules.Report
{
    public class ReportMapperProfile : Profile
    {
        public ReportMapperProfile()
        {
            CreateMap<TestProcedure, TestProcedureReportModel>();
            CreateMap<TestProcedureOperation, TestOperationReportModel>();
            CreateMap<TestProcedure, IfdReportModel>();
        }
    }
}