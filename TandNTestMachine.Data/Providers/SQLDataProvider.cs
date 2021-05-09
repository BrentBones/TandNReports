using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TandNTestMachine.Data.Constants;
using TandNTestMachine.Data.Entity;
using TandNTestMachine.Data.Interfaces;
using TandNTestMachine.Data.Models;

namespace TandNTestMachine.Data.Providers
{
    public class SqlDataProvider : IDataProvider
    {
        private readonly IMapper _mapper;

        public SqlDataProvider(IMapper mapper)
        {
            _mapper = mapper;
        }


        #region App Data

        public string GetValue(string key)
        {
            using var db = new TestMachineContext();
            var entity = (from a in db.AppData
                where a.DataKey == key
                select a).FirstOrDefault();
            return entity != null ? entity.DataValue : string.Empty;
        }

        public string GetValue(string Key, string DefaultValue)
        {
            using var db = new TestMachineContext();
            var entity = (from a in db.AppData
                where a.DataKey == Key
                select a).FirstOrDefault();
            if (entity == null)
            {
                entity = new AppData();
                entity.DataKey = Key;
                entity.DataValue = DefaultValue;
                db.AppData.Add(entity);
                db.SaveChanges();
            }

            return entity.DataValue;
        }

        public bool UpdateValue(string Key, string Value)
        {
            using var db = new TestMachineContext();
            var entity = (from a in db.AppData
                where a.DataKey == Key
                select a).FirstOrDefault();
            if (entity == null)
            {
                entity = new AppData();
                entity.DataKey = Key;
                entity.DataValue = Value;
                db.AppData.Add(entity);
                db.SaveChanges();
            }
            else
            {
                entity.DataValue = Value;
            }

            return db.SaveChanges() > 0;
        }

        #endregion

        #region Tag Addresses

        private List<TagAddress> TagAddresses()
        {
            using var db = new TestMachineContext();
            var entity = (from x in db.TagAddress
                select x).ToList();

            return entity;
        }

        private Dictionary<string, string> AddressesToDictionary(List<TagAddress> addresses)
        {
            var result = new Dictionary<string, string>();
            foreach (var address in addresses) result.Add(address.TagName, address.PLCAddress);
            return result;
        }

        public Dictionary<string, string> GetTagAddresses()
        {
            var addresses = TagAddresses();
            return AddressesToDictionary(addresses);
        }

        public Dictionary<string, string> GetTagAddresses(AppDataKeys.TagAddressType type)
        {
            var addresses = TagAddresses();
            return AddressesToDictionary(addresses.Where(a => a.TagType == (int) type).ToList());
        }

        #endregion

        #region Operation

        public List<OperationModel> GetAllOperations()
        {
            using var db = new TestMachineContext();
            var ops = db.Operation.OrderBy(op => op.OpCode).ToList();
            return _mapper.Map<List<OperationModel>>(ops);
        }

        public OperationModel GetOperation(Guid id)
        {
            using var db = new TestMachineContext();
            var op = db.Operation.FirstOrDefault(op => op.Id == id);
            return _mapper.Map<OperationModel>(op);
        }

        public List<OperationModel> GetOperationsForRecipe(Guid recipeId)
        {
            using var db = new TestMachineContext();
            var operations = (from o in db.OperationRecipe
                join op in db.Operation
                    on o.OperationId equals op.Id
                where o.RecipeId == recipeId
                orderby o.OperationIndex
                select new OperationModel
                {
                    Id = op.Id,
                    OpCodeName = op.OpCodeName,
                    OperationIndex = o.OperationIndex,
                    OpCode = op.OpCode,
                    OperationRecipeId = o.OperationRecipeId,
                    Param1 = o.Param1,
                    Param2 = o.Param2,
                    Param3 = o.Param3,
                    Param4 = o.Param4,
                    Param5 = o.Param5,
                    Param1Name = op.Param1Name,
                    Param2Name = op.Param2Name,
                    Param3Name = op.Param3Name,
                    Param4Name = op.Param4Name,
                    Param5Name = op.Param5Name,
                    Data1Name = op.Data1Name,
                    Data2Name = op.Data2Name,
                    Data3Name = op.Data3Name,
                    Data4Name = op.Data4Name,
                    Data5Name = op.Data5Name
                }).ToList();

            return operations;
        }

        public bool UpdateOperation(OperationModel operation)
        {
            using var db = new TestMachineContext();
            var entity = db.Operation.FirstOrDefault(op => op.Id == operation.Id);
            _mapper.Map(operation, entity);
            var result = db.SaveChanges() > 0;
            return result;
        }

        public bool AddOperationToRecipe(OperationModel operation, Guid recipeId)
        {
            using var db = new TestMachineContext();
            var newOperationRecipe = new OperationRecipe();
            newOperationRecipe.OperationIndex = operation.OperationIndex;
            newOperationRecipe.OperationRecipeId = Guid.NewGuid();
            if (operation.OperationIndex == 0)
            {
                var currentOperations = GetOperationsForRecipe(recipeId);
                int lastIndex;
                if (currentOperations.Count > 0)
                    lastIndex = currentOperations.Max(o => o.OperationIndex);
                else
                    lastIndex = 0;
                newOperationRecipe.OperationIndex = lastIndex + 10;
            }

            newOperationRecipe.RecipeId = recipeId;
            newOperationRecipe.OperationId = operation.Id;
            newOperationRecipe.Param1 = operation.Param1;
            newOperationRecipe.Param2 = operation.Param2;
            newOperationRecipe.Param3 = operation.Param3;
            newOperationRecipe.Param4 = operation.Param4;
            newOperationRecipe.Param5 = operation.Param5;
            db.OperationRecipe.Add(newOperationRecipe);
            var result = db.SaveChanges() > 0;
            return result;
        }

        public void DeleteOperationForRecipe(OperationModel operation)
        {
            using var db = new TestMachineContext();
            var entity = db.OperationRecipe.FirstOrDefault(o =>
                o.OperationRecipeId == operation.OperationRecipeId);
            if (entity != null)
            {
                db.OperationRecipe.Remove(entity);
                db.SaveChanges();
            }
        }

        public TestProcedure CreateTestProcedure(Guid RecipeId)
        {
            using var db = new TestMachineContext();
            var testProcedure = new TestProcedure();
            var recipe = db.Recipe.FirstOrDefault(r => r.Id == RecipeId);

            testProcedure.Name = recipe.Name;
            testProcedure.StartTime = DateTime.Now;
            var operations = (from o in db.OperationRecipe
                join op in db.Operation
                    on o.OperationId equals op.Id
                where o.RecipeId == RecipeId
                orderby o.OperationIndex
                select new TestProcedureOperation
                {
                    Id = Guid.NewGuid(),
                    OpCodeName = op.OpCodeName,
                    OpCode = op.OpCode,
                    OperationIndex = o.OperationIndex,
                    Param1 = o.Param1,
                    Param2 = o.Param2,
                    Param3 = o.Param3,
                    Param4 = o.Param4,
                    Param5 = o.Param5,
                    Param1Name = op.Param1Name,
                    Param2Name = op.Param2Name,
                    Param3Name = op.Param3Name,
                    Param4Name = op.Param4Name,
                    Param5Name = op.Param5Name,
                    Data1Name = op.Data1Name,
                    Data2Name = op.Data2Name,
                    Data3Name = op.Data3Name,
                    Data4Name = op.Data4Name,
                    Data5Name = op.Data5Name
                }).ToList();

            testProcedure.TestProcedureOperations = _mapper.Map<List<TestProcedureOperation>>(operations);

            return testProcedure;
        }

        #endregion

        #region Recipe

        public RecipeModel GetRecipe(Guid id)
        {
            using var db = new TestMachineContext();
            var entity = db.Recipe.FirstOrDefault(r => r.Id == id);
            return _mapper.Map<RecipeModel>(entity);
        }

        public List<RecipeModel> GetRecipes()
        {
            using var db = new TestMachineContext();
            var result = from r in db.Recipe select r;
            return _mapper.Map<List<RecipeModel>>(result.ToList());
        }

        public List<RecipeWithOperationsModel> GetRecipeWithOperations()
        {
            using var db = new TestMachineContext();
            var recipes = db.Recipe;
            var result = new List<RecipeWithOperationsModel>();
            foreach (var recipe in recipes) result.Add(GetRecipeWithOperations(recipe.Id));

            return result;
        }

        public RecipeWithOperationsModel GetRecipeWithOperations(Guid recipeId)
        {
            using var db = new TestMachineContext();
            var result = new RecipeWithOperationsModel();
            var recipe = (from r in db.Recipe
                where r.Id == recipeId
                select r).FirstOrDefault();
            if (recipe == null)
                return result;

            result.Id = recipe.Id;
            result.Name = recipe.Name;

            result.Operations = (from o in db.OperationRecipe
                join op in db.Operation
                    on o.OperationId equals op.Id
                where o.RecipeId == recipeId
                orderby o.OperationIndex
                select new OperationModel
                {
                    Id = op.Id,
                    OpCodeName = op.OpCodeName,
                    OperationIndex = o.OperationIndex,
                    OperationRecipeId = o.OperationRecipeId,
                    OpCode = op.OpCode,
                    Param1 = o.Param1,
                    Param2 = o.Param2,
                    Param3 = o.Param3,
                    Param4 = o.Param4,
                    Param5 = o.Param5,
                    Param1Name = op.Param1Name,
                    Param2Name = op.Param2Name,
                    Param3Name = op.Param3Name,
                    Param4Name = op.Param4Name,
                    Param5Name = op.Param5Name,
                    Data1Name = op.Data1Name,
                    Data2Name = op.Data2Name,
                    Data3Name = op.Data3Name,
                    Data4Name = op.Data4Name,
                    Data5Name = op.Data5Name
                }).ToList();
            return result;
        }

        public bool UpdateTestOperation(OperationModel operation)
        {
            using var db = new TestMachineContext();


            //var entity =
            //    db.OperationRecipe.FirstOrDefault(o =>
            //        o.OperationId == operation.Id && o.RecipeId == recipeId &&
            //        o.OperationIndex == operation.OperationIndex);
            var entity = db.OperationRecipe.FirstOrDefault(o => o.OperationRecipeId == operation.OperationRecipeId);
            if (entity == null)
                return false;

            if (operation.OperationIndex != entity.OperationIndex)
                return UpdateTestOperationIndex(operation);

            entity.Param1 = operation.Param1;
            entity.Param2 = operation.Param2;
            entity.Param3 = operation.Param3;
            entity.Param4 = operation.Param4;
            entity.Param5 = operation.Param5;
            var result = db.SaveChanges() > 0;
            return result;
        }

        private bool UpdateTestOperationIndex(OperationModel operation)
        {
            using var db = new TestMachineContext();
            var oldEntity =
                db.OperationRecipe.FirstOrDefault(o => o.OperationRecipeId == operation.OperationRecipeId);
            if (oldEntity != null)
            {
                var recipeId = oldEntity.RecipeId;
                db.OperationRecipe.Remove(oldEntity);
                var result = db.SaveChanges();
                return AddOperationToRecipe(operation, recipeId);
            }

            return false;
        }

        public bool UpdateRecipe(RecipeWithOperationsModel recipe)
        {
            using var db = new TestMachineContext();
            var entity = db.Recipe.FirstOrDefault(r => r.Id == recipe.Id);
            if (entity == null)
                return AddRecipe(recipe);
            _mapper.Map(recipe, entity);
            var result = db.SaveChanges() > 0;
            return result;
        }

        public bool DeleteRecipe(RecipeWithOperationsModel recipe)
        {
            using var db = new TestMachineContext();
            var entity = db.Recipe.FirstOrDefault(r => r.Id == recipe.Id);
            if (entity != null)
            {
                db.Recipe.Remove(entity);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        private bool AddRecipe(RecipeWithOperationsModel recipe)
        {
            using var db = new TestMachineContext();
            recipe.Id = Guid.NewGuid();
            db.Recipe.Add(_mapper.Map<Recipe>(recipe));
            var result = db.SaveChanges() > 0;
            return result;
        }

        #endregion

        #region Test Procedure Logs

        public TestProcedure UpdateTestProcedure(TestProcedure testProcedure)
        {
            using var db = new TestMachineContext();
            var procedure = (from p in db.TestProcedure
                where p.Id == testProcedure.Id
                select p).FirstOrDefault();
            if (procedure == null)
                return InsertTestProcedure(testProcedure, db);
            return UpdateTestProcedure(testProcedure, procedure, db);
        }

        public TestProcedureOperation UpdateTestProcedureOperation(TestProcedureOperation operation)
        {
            using var db = new TestMachineContext();
            var procedureOperation = (from p in db.TestProcedureOperation
                where p.Id == operation.Id
                select p).FirstOrDefault();
            if (procedureOperation == null)
                procedureOperation = InsertTestProcedureOperation(operation, db);
            else
                procedureOperation = UpdateTestProcedureOperation(operation, procedureOperation, db);
            return procedureOperation;
        }

        public List<TestProcedureOperation> UpdateTestProcedureOperations(
            List<TestProcedureOperation> testProcedureOperations)
        {
            using var db = new TestMachineContext();
            foreach (var op in testProcedureOperations)
            {
                var procedureOperation = (from p in db.TestProcedureOperation
                    where p.Id == op.Id
                    select p).FirstOrDefault();
                if (procedureOperation == null)
                    procedureOperation = InsertTestProcedureOperation(op, db);
                else
                    procedureOperation = UpdateTestProcedureOperation(op, procedureOperation, db);
            }

            return testProcedureOperations;
        }

        public bool InsertSensorLogs(TestLogEntryUDT[] sensorLogs, Guid testProcedureId)
        {
            var entityLogs = _mapper.Map<TestProcedureSensorLog[]>(sensorLogs);
            foreach (var log in entityLogs) log.TestProcedureId = testProcedureId;
            using var db = new TestMachineContext();
            db.TestProcedureSensorLog.AddRange(entityLogs);
            return db.SaveChanges() > 0;
        }

        private TestProcedure InsertTestProcedure(TestProcedure testProcedure, TestMachineContext db)
        {
            db.TestProcedure.Add(testProcedure);
            db.SaveChanges();
            return testProcedure;
        }

        private TestProcedureOperation InsertTestProcedureOperation(TestProcedureOperation testProcedure,
            TestMachineContext db)
        {
            db.TestProcedureOperation.Add(testProcedure);
            db.SaveChanges();
            return testProcedure;
        }

        private TestProcedure UpdateTestProcedure(TestProcedure testProcedure, TestProcedure testProcedureEntity,
            TestMachineContext db)
        {
            _mapper.Map(testProcedure, testProcedureEntity);
            db.SaveChanges();
            return testProcedure;
        }

        private TestProcedureOperation UpdateTestProcedureOperation(TestProcedureOperation testProcedureOperation,
            TestProcedureOperation testProcedureOperationEntity, TestMachineContext db)
        {
            _mapper.Map(testProcedureOperation, testProcedureOperationEntity);
            db.SaveChanges();
            return testProcedureOperation;
        }

        #endregion


        #region Reports

        public List<ReportTypeModel> GetReportTypes()
        {
            var result = new List<ReportTypeModel>();
            result.Add(new ReportTypeModel {ReportID = ReportIDTypes.TestProcedures, ReportName = "Test Logs"});
            return result;
        }

        public List<TestProcedure> GetTestProcedures(DateTime startDate, DateTime endDate)
        {
            using var db = new TestMachineContext();
            var entityTestProcedure = db.TestProcedure.Where(tp => tp.StartTime >= startDate && tp.StartTime <= endDate)
                .Include(etp => etp.TestProcedureOperations.OrderBy(tpo => tpo.OperationIndex));
            return entityTestProcedure.ToList();
        }


        public List<TestProcedureSensorLog> GetTestSensorLogs(Guid id)
        {
            using var db = new TestMachineContext();
            var entity = db.TestProcedureSensorLog.Where(sl => sl.TestProcedureId == id)
                .OrderBy(l => l.ElapsedTime);
            return entity.ToList();
        }

        #endregion

        //#region Helpers

        //private void SetOperationModelLastIndex(ref OperationModel op)
        //{
        //    op.LastOperationIndex = op.OperationIndex;
        //}

        //private void SetOperationModelLastIndex(ref List<OperationModel> ops)
        //{
        //    foreach (var op in ops)
        //        op.LastOperationIndex = op.OperationIndex;
        //}

        //#endregion
    }
}

//using (AdventureWorks db = new AdventureWorks())
//{
//    var person = (from p in db.People
//                  join e in db.EmailAddresses
//                  on p.BusinessEntityID equals e.BusinessEntityID
//                  where p.FirstName == "KEN"
//                  select new
//                  {
//                      ID = p.BusinessEntityID,
//                      FirstName = p.FirstName,
//                      MiddleName = p.MiddleName,
//                      LastName = p.LastName,
//                      EmailID = e.EmailAddress1
//                  }).ToList();

//    foreach (var p in person)
//    {
//        Console.WriteLine("{0} {1} {2} {3} {4}", p.ID, p.FirstName, p.MiddleName, p.LastName, p.EmailID);
//    }
//}