using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using TandNTestMachine.Data.Constants;
using TandNTestMachine.Data.Entity;
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

        public List<IfdReportModel> GetIfdReports(DateTime startDate, DateTime endDate)
        {
            var result = new List<IfdReportModel>();

            var procedures = _dataProvider.GetTestProcedures(ConvertStartDate(startDate), ConvertEndDate(endDate));
            var ifdReportName = _dataProvider.GetValue(AppDataKeys.IfdRecipeName, "IFD");
            var ifdProcedures = procedures.Where(p => p.Name == ifdReportName).ToList();
            var cycleIds = ifdProcedures.Select(p => p.CycleId).Distinct().ToList();

            foreach (var cycleId in cycleIds)
            {
                float ifdSum = 0;
                var ifdCount = 0;
                float ifdAverage = 0;

                // get test procedures for a CycleId
                var groupProcedures = ifdProcedures.Where(p => p.CycleId == cycleId).ToList();

                foreach (var procedure in groupProcedures)
                {
                    var reportModel = IfdReportForProcedure(procedure);

                    ifdSum += Convert.ToSingle(reportModel.Ifd);
                    ifdCount++;
                    result.Add(reportModel);
                }

                if (ifdCount > 0) ifdAverage = ifdSum / ifdCount;
                foreach (var r in result)
                    r.IfdAverage = ifdAverage.ToString(CultureInfo.CurrentCulture);
            }

            return result;
        }

        private IfdReportModel IfdReportForProcedure(TestProcedure procedure)
        {
            // true after first depression is recorded
            var depressionCount = 0;
            var firstForceRecorded = false;
            var ops = procedure.TestProcedureOperations.OrderBy(p => p.OperationIndex);
            var ifdOperationId = _dataProvider.GetValue(AppDataKeys.IfdOperationName, "IFD Calculation").ToLower();
            var depressionOperationId =
                _dataProvider.GetValue(AppDataKeys.DepressionOperationName, "Depress Percentage").ToLower();
            var readForceOperationId =
                _dataProvider.GetValue(AppDataKeys.ReadForceOperationName, "Read Force").ToLower();


            var result = _mapper.Map<IfdReportModel>(procedure);

            foreach (var op in ops)
            {
                var opCodeName = op.OpCodeName.ToLower();
                if (opCodeName == ifdOperationId)
                {
                    result.Ifd = op.Data1;
                }
                else if (opCodeName == depressionOperationId)
                {
                    depressionCount++;
                    if (depressionCount == 3)
                        result.DepthPercent1 = op.Param2;
                    else if (depressionCount == 4) result.DepthPercent2 = op.Param2;
                }
                else if (opCodeName == readForceOperationId)
                {
                    if (!firstForceRecorded)
                    {
                        result.Force1 = op.Data1;
                        result.PlateHeight1 = op.Data2;
                        firstForceRecorded = true;
                    }
                    else
                    {
                        result.Force2 = op.Data1;
                        result.PlateHeight2 = op.Data2;
                    }
                }
            }

            return result;
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