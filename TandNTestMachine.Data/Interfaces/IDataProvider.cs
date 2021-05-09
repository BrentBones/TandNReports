using System;
using System.Collections.Generic;
using TandNTestMachine.Data.Constants;
using TandNTestMachine.Data.Entity;
using TandNTestMachine.Data.Models;

namespace TandNTestMachine.Data.Interfaces
{
    public interface IDataProvider
    {
        #region Application Data

        /// <summary>
        ///     Get Application Data.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        ///     Get Application Data and use default value if entry does
        ///     not exist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue">
        ///     Default value to create entry if it
        ///     doesn't already exist.
        /// </param>
        /// <returns></returns>
        string GetValue(string key, string defaultValue);

        /// <summary>
        ///     Updates value in database.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool UpdateValue(string key, string value);

        #endregion

        #region Tag Addresses

        Dictionary<string, string> GetTagAddresses();
        Dictionary<string, string> GetTagAddresses(AppDataKeys.TagAddressType type);

        #endregion

        #region Operations

        //RecipeWithOperationsModel GetOperationsForTest(Guid RecipeId);
        List<RecipeWithOperationsModel> GetRecipeWithOperations();
        RecipeWithOperationsModel GetRecipeWithOperations(Guid recipeId);

        TestProcedure CreateTestProcedure(Guid recipeId);
        List<OperationModel> GetAllOperations();
        OperationModel GetOperation(Guid id);
        List<OperationModel> GetOperationsForRecipe(Guid recipeId);
        bool UpdateOperation(OperationModel operation);

        bool AddOperationToRecipe(OperationModel operation, Guid recipeId);
        void DeleteOperationForRecipe(OperationModel operation);

        #endregion

        #region Recipe

        List<RecipeModel> GetRecipes();
        RecipeModel GetRecipe(Guid id);
        bool UpdateTestOperation(OperationModel operation);
        bool UpdateRecipe(RecipeWithOperationsModel recipe);
        bool DeleteRecipe(RecipeWithOperationsModel recipe);

        #endregion

        #region Test Procedure Logs

        TestProcedure UpdateTestProcedure(TestProcedure testProcedure);

        List<TestProcedureOperation>
            UpdateTestProcedureOperations(List<TestProcedureOperation> testProcedureOperations);

        TestProcedureOperation UpdateTestProcedureOperation(TestProcedureOperation operation);

        bool InsertSensorLogs(TestLogEntryUDT[] sensorLogs, Guid testProcedureId);

        #endregion

        #region Reports

        List<ReportTypeModel> GetReportTypes();

        List<TestProcedure> GetTestProcedures(DateTime startDate, DateTime endDate);

        List<TestProcedureSensorLog> GetTestSensorLogs(Guid id);

        #endregion
    }
}