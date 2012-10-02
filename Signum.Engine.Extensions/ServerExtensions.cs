﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Signum.Entities;
using Signum.Entities.Basics;
using System.Reflection;
using Signum.Entities.Authorization;
using Signum.Entities.DynamicQuery;
using Signum.Engine.DynamicQuery;
using Signum.Engine;
using Signum.Engine.Maps;
using Signum.Engine.Authorization;
using Signum.Entities.Operations;
using Signum.Engine.Operations;
using Signum.Utilities;
using Signum.Engine.Basics;
using Signum.Entities.Chart;
using Signum.Utilities.DataStructures;
using Signum.Entities.Reports;
using Signum.Engine.Reports;
using Signum.Engine.SMS;
using Signum.Entities.UserQueries;
using Signum.Engine.UserQueries;
using Signum.Entities.SMS;
using Signum.Engine.Chart;
using Signum.Engine.Exceptions;
using System.IO;
using System.Xml;
using Signum.Engine.Profiler;


namespace Signum.Services
{
    public abstract class ServerExtensions : ServerBasic, ILoginServer, IOperationServer, IQueryServer, 
        IChartServer, IExcelReportServer, IUserQueryServer, IQueryAuthServer, IPropertyAuthServer, 
        ITypeAuthServer, IFacadeMethodAuthServer, IPermissionAuthServer, IOperationAuthServer, ISmsServer,
        IProfilerServer
    {
        protected override T Return<T>(MethodBase mi, string description, Func<T> function, bool checkLogin = true)
        {
            try
            {
                using (ScopeSessionFactory.OverrideSession(session))
                using (ExecutionContext.Scope(GetDefaultExecutionContext(mi, description)))
                {
                    if (checkLogin)
                        FacadeMethodAuthLogic.AuthorizeAccess((MethodInfo)mi);

                    return function();
                }
            }
            catch (Exception e)
            {
                e.LogException(el =>
                {
                    el.ControllerName = GetType().Name;
                    el.ActionName = mi.Name;
                    el.QueryString = description;
                    el.Version = Schema.Current.Version.ToString();
                });
                throw new FaultException(e.Message);
            }
            finally
            {
                Statics.CleanThreadContextAndAssert();
            }
        }

        #region ILoginServer Members
        public virtual void Login(string username, string passwordHash)
        {
            Execute(MethodInfo.GetCurrentMethod(), null, () =>
            {
                UserDN.Current = AuthLogic.Login(username, passwordHash);
            }, checkLogin: false);
        }

        public virtual void ChagePassword(Lite<UserDN> user, string passwordHash, string newPasswordHash)
        {
            Execute(MethodInfo.GetCurrentMethod(), () =>
            {
                AuthLogic.ChangePassword(user, passwordHash, newPasswordHash);
            });
        }


        public virtual void LoginChagePassword(string username, string passwordHash, string newPasswordHash)
        {
            Execute(MethodInfo.GetCurrentMethod(), null, () =>
            {
                UserDN.Current = AuthLogic.ChangePasswordLogin(username, passwordHash, newPasswordHash);
            }, checkLogin: false);
        }

        public virtual void Logout()
        {
            using (ScopeSessionFactory.OverrideSession(session))
            {
                UserDN.Current = null;
            }
        }

        public UserDN GetCurrentUser()
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => UserDN.Current);
        }


        public string PasswordNearExpired()
        {
            return Return(MethodInfo.GetCurrentMethod(),
             () => AuthLogic.OnLoginMessage());
        }

        #endregion

        #region IOperationServer Members
        public List<OperationInfo> GetEntityOperationInfos(IdentifiableEntity entity)
        {
            return Return(MethodInfo.GetCurrentMethod(), entity.GetType().Name,
                () => OperationLogic.ServiceGetEntityOperationInfos(entity));
        }

        public List<OperationInfo> GetQueryOperationInfos(Type entityType)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => OperationLogic.ServiceGetQueryOperationInfos(entityType));
        }

        public List<OperationInfo> GetConstructorOperationInfos(Type entityType)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => OperationLogic.ServiceGetConstructorOperationInfos(entityType));
        }

        public IIdentifiable ExecuteOperation(IIdentifiable entity, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
               () => OperationLogic.ServiceExecute(entity, operationKey, args));
        }

        public IIdentifiable ExecuteOperationLite(Lite lite, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceExecuteLite(lite, operationKey, args));
        }

        public IIdentifiable Delete(Lite lite, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceDelete(lite, operationKey, args));
        }

        public IIdentifiable Construct(Type type, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceConstruct(type, operationKey, args));
        }

        public IIdentifiable ConstructFrom(IIdentifiable entity, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceConstructFrom(entity, operationKey, args));
        }

        public IIdentifiable ConstructFromLite(Lite lite, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceConstructFromLite(lite, operationKey, args));
        }

        public IIdentifiable ConstructFromMany(List<Lite> lites, Type type, Enum operationKey, params object[] args)
        {
            return Return(MethodInfo.GetCurrentMethod(), operationKey.ToString(),
              () => OperationLogic.ServiceConstructFromMany(lites, type, operationKey, args));
        }
        #endregion

        #region IQueryServer Members
        [SuggestUserInterface]
        public QueryDN RetrieveOrGenerateQuery(object queryName)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => QueryLogic.RetrieveOrGenerateQuery(queryName));
        }

        #endregion

        #region IPropertyAuthServer Members
        public PropertyRulePack GetPropertyRules(Lite<RoleDN> role, TypeDN typeDN)
        {
            return Return(MethodInfo.GetCurrentMethod(),
             () => PropertyAuthLogic.GetPropertyRules(role, typeDN));
        }

        public void SetPropertyRules(PropertyRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
             () => PropertyAuthLogic.SetPropertyRules(rules));
        }

        public DefaultDictionary<PropertyRoute, PropertyAllowed> AuthorizedProperties()
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => PropertyAuthLogic.AuthorizedProperties());
        }
        #endregion

        #region ITypeAuthServer Members

        public TypeRulePack GetTypesRules(Lite<RoleDN> role)
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => TypeAuthLogic.GetTypeRules(role));
        }

        public void SetTypesRules(TypeRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
              () => TypeAuthLogic.SetTypeRules(rules));
        }

        public DefaultDictionary<Type, TypeAllowedAndConditions> AuthorizedTypes()
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => TypeAuthLogic.AuthorizedTypes());
        }

        public bool IsAllowedFor(Lite lite, TypeAllowedBasic allowed)
        {
            return Return(MethodInfo.GetCurrentMethod(),
             () => TypeAuthLogic.IsAllowedFor(lite, allowed, Signum.Engine.ExecutionContext.Current));
        }

        public byte[] DownloadAuthRules()
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () =>
              {
                  using (MemoryStream ms = new MemoryStream())
                  {
                      using (XmlWriter wr = new XmlTextWriter(ms, Encoding.UTF8) { Formatting = Formatting.Indented })
                      {

                          AuthLogic.ExportRules().WriteTo(wr);
                      }
                      return ms.ToArray();
                  }
              });
        }

        #endregion

        #region IFacadeMethodAuthServer Members

        public FacadeMethodRulePack GetFacadeMethodRules(Lite<RoleDN> role)
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => FacadeMethodAuthLogic.GetFacadeMethodRules(role));
        }

        public void SetFacadeMethodRules(FacadeMethodRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
              () => FacadeMethodAuthLogic.SetFacadeMethodRules(rules));
        }

        public DefaultDictionary<string, bool> FacadeMethodRules()
        {
            return Return(MethodInfo.GetCurrentMethod(),
             () => FacadeMethodAuthLogic.FacadeMethodRules());

            throw new NotImplementedException();
        }

        #endregion

        #region IQueryAuthServer Members

        public QueryRulePack GetQueryRules(Lite<RoleDN> role, TypeDN typeDN)
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => QueryAuthLogic.GetQueryRules(role, typeDN));
        }

        public void SetQueryRules(QueryRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
               () => QueryAuthLogic.SetQueryRules(rules));
        }

        public DefaultDictionary<object, bool> QueriesRules()
        {
            return Return(MethodInfo.GetCurrentMethod(),
            () => QueryAuthLogic.QueryRules());
        }

        #endregion

        #region IPermissionAuthServer Members

        public PermissionRulePack GetPermissionRules(Lite<RoleDN> role)
        {
            return Return(MethodInfo.GetCurrentMethod(),
            () => PermissionAuthLogic.GetPermissionRules(role));
        }

        public void SetPermissionRules(PermissionRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
            () => PermissionAuthLogic.SetPermissionRules(rules));
        }

        public DefaultDictionary<Enum, bool> PermissionRules()
        {
            return Return(MethodInfo.GetCurrentMethod(),
           () => PermissionAuthLogic.ServicePermissionRules());
        }

        #endregion

        #region IOperationAuthServer Members
        public OperationRulePack GetOperationRules(Lite<RoleDN> role, TypeDN typeDN)
        {
            return Return(MethodInfo.GetCurrentMethod(),
              () => OperationAuthLogic.GetOperationRules(role, typeDN));
        }

        public void SetOperationRules(OperationRulePack rules)
        {
            Execute(MethodInfo.GetCurrentMethod(),
               () => OperationAuthLogic.SetOperationRules(rules));
        }

        public DefaultDictionary<Enum, bool> OperationRules()
        {
            return Return(MethodInfo.GetCurrentMethod(),
            () => OperationAuthLogic.OperationRules());
        }
        #endregion

        #region IChartServer
        [SuggestUserInterface]
        public ResultTable ExecuteChart(ChartRequest request)
        {
            return Return(MethodInfo.GetCurrentMethod(),
               () => ChartLogic.ExecuteChart(request));
        }

        [SuggestUserInterface]
        public List<Lite<UserChartDN>> GetUserCharts(object queryName)
        {
            return Return(MethodInfo.GetCurrentMethod(),
            () => UserChartLogic.GetUserCharts(queryName));
        }

        [SuggestUserInterface]
        public void RemoveUserChart(Lite<UserChartDN> lite)
        {
            Execute(MethodInfo.GetCurrentMethod(),
              () => UserChartLogic.RemoveUserChart(lite));
        }

        #endregion

        #region IExcelReportServer Members

        [SuggestUserInterface]
        public List<Lite<ExcelReportDN>> GetExcelReports(object queryName)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => ReportsLogic.GetExcelReports(queryName));
        }

        [SuggestUserInterface]
        public byte[] ExecuteExcelReport(Lite<ExcelReportDN> excelReport, QueryRequest request)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => ReportsLogic.ExecuteExcelReport(excelReport, request));
        }

        [SuggestUserInterface]
        public byte[] ExecutePlainExcel(QueryRequest request)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => ReportsLogic.ExecutePlainExcel(request));
        }

        #endregion

        #region IUserQueriesServer
        [SuggestUserInterface]
        public List<Lite<UserQueryDN>> GetUserQueries(object queryName)
        {
            return Return(MethodInfo.GetCurrentMethod(),
            () => UserQueryLogic.GetUserQueries(queryName));
        }

        [SuggestUserInterface]
        public void RemoveUserQuery(Lite<UserQueryDN> lite)
        {
            Execute(MethodInfo.GetCurrentMethod(),
              () => UserQueryLogic.RemoveUserQuery(lite));
        }
        #endregion

        #region SMS Members
        public string GetPhoneNumber(IdentifiableEntity ie)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => SMSLogic.GetPhoneNumber(ie));
        }

        public List<string> GetLiteralsFromDataObjectProvider(TypeDN type)
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => SMSLogic.GetLiteralsFromDataObjectProvider(type.ToType()));
        }    
    
        public List<Lite> GetAssociatedTypesForTemplates()
        {
            return Return(MethodInfo.GetCurrentMethod(),
                () => SMSLogic.RegisteredDataObjectProviders().Select(rt => (Lite)rt).ToList());
        }

        #endregion

        #region Profiler
        public void PushProfilerEntries(List<HeavyProfilerEntry> entries)
        {
            Execute(MethodInfo.GetCurrentMethod(), () =>
                ProfilerLogic.ProfilerEntries(entries)); 
        }
        #endregion
    }
}
