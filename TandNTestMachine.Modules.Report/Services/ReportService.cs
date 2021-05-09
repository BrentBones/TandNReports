using System;
using System.Collections.Generic;
using AutoMapper;
using TandNTestMachine.Data.Interfaces;
using TandNTestMachine.Modules.Report.Model;

namespace TandNTestMachine.Modules.Report.Services
{
    public class ReportService : IReportService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IMapper _mapper;

        public ReportService(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public List<TestProcedureReportModel> GetStandReports(DateTime startDate, DateTime endDate)
        {
            var procedures = _dataProvider.GetTestProcedures(ConvertStartDate(startDate), ConvertEndDate(endDate));
            return _mapper.Map<List<TestProcedureReportModel>>(procedures);
        }

        public List<IFDReportModel> GetIfdReports(DateTime starDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        private DateTime ConvertStartDate(DateTime date)
        {
            var result = date.Date;
            return result;
        }

        private DateTime ConvertEndDate(DateTime date)
        {
            var result = date.Date.AddDays(1);
            return result;
        }
    }
}