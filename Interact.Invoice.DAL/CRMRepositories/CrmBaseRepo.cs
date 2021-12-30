using System;
using System.Collections.Generic;
using Interact.Invoice.Core;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Interact.Invoice.DAL.CRMRepositories
{
    public class CrmBaseRepo
    {
        protected readonly IOrganizationService Service;

        protected CrmBaseRepo(IOrganizationService service)
        {
            this.Service = service;
        }

        protected DataCollection<Entity> GetDataFromEntityByOneFieldEquality(string entity,
            string attributeName, object value)
        {
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entity,
                    ColumnSet =
                        new ColumnSet(true),

                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = attributeName,
                                Operator = ConditionOperator.Equal,
                                Values = { value }
                            }
                        }
                    }
                };
                return Service.RetrieveMultiple(query).Entities;
            }
            catch (Exception e)
            {
                StaticLogger<CrmBaseRepo>.LogError(e);
                return null;
            }
        }

        protected DataCollection<Entity> GetDataFromEntityByMultipleConditions(string entity,
            List<string> attributes, List<object> values, List<ConditionOperator> operators)
        {
            FilterExpression filters = new FilterExpression();

            for (int i = 0; i < attributes.Count; i++)
            {
                filters.AddCondition(new ConditionExpression
                {
                    AttributeName = attributes[i],
                    Operator = operators[i],
                    Values = { values[i] }
                });
            }
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entity,
                    ColumnSet =
                        new ColumnSet(true),

                    Criteria = filters
                };
                return Service.RetrieveMultiple(query).Entities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StaticLogger<CrmBaseRepo>.LogError(e);
                throw e;
            }

        }

        protected DataCollection<Entity> GetDataFromEntityByOneFieldEqualityLink(string entity,
            string attributeName, object value)
        {
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entity,
                    ColumnSet =
                        new ColumnSet(true),

                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = attributeName,
                                Operator = ConditionOperator.Equal,
                                Values = { value }
                            }
                        }
                    }
                };
                LinkEntity linkEntity = query.AddLink("role", "roleid", "roleid", JoinOperator.Inner);
                linkEntity.LinkCriteria.AddCondition("name", ConditionOperator.Equal, "System Administrator");
                return Service.RetrieveMultiple(query).Entities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StaticLogger<CrmBaseRepo>.LogError(e);
                throw e;
            }
        }
    }
}