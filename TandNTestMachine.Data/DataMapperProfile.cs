using System;
using AutoMapper;
using TandNTestMachine.Core.Models;
using TandNTestMachine.Data.Entity;
using TandNTestMachine.Data.Models;

namespace TandNTestMachine.Data
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<TestProcedure, TestProcedure>();
            CreateMap<Operation, Operation>();
            CreateMap<TestProcedureOperation, TestProcedureOperation>();

            CreateMap<Operation, TestProcedureOperation>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<TestLogEntryUDT, TestProcedureSensorLog>();
            CreateMap<TestProcedureOperation, OperationWidgetModel>();


            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<Operation, OperationModel>().ReverseMap();
            CreateMap<OperationRecipe, OperationModel>().ReverseMap();
            CreateMap<RecipeWithOperationsModel, Recipe>();
        }
    }
}