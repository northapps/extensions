﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Signum.Entities.Basics;
using Signum.Utilities;

namespace Signum.Entities.Help
{
    [Serializable, EntityKind(EntityKind.SharedPart, EntityData.Master)]
    public class OperationHelpDN : Entity
    {
        [NotNullable]
        OperationSymbol operation;
        [NotNullValidator]
        public OperationSymbol Operation
        {
            get { return operation; }
            set { Set(ref operation, value); }
        }

        [NotNullable]
        CultureInfoDN culture;
        [NotNullValidator]
        public CultureInfoDN Culture
        {
            get { return culture; }
            set { Set(ref culture, value); }
        }

        [NotNullable, SqlDbType(Size = int.MaxValue)]
        string description;
        [NotNullValidator]
        public string Description
        {
            get { return description; }
            set { Set(ref description, value); }
        }

        static Expression<Func<OperationHelpDN, string>> ToStringExpression = e => e.Operation.ToString();
        public override string ToString()
        {
            return ToStringExpression.Evaluate(this);
        }
    }


    public static class OperationHelpOperation
    {
        public static readonly ExecuteSymbol<OperationHelpDN> Save = OperationSymbol.Execute<OperationHelpDN>();
    }
}
