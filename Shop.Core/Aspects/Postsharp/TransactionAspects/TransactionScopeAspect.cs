using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Transactions;

namespace Shop.Core.Aspects.Postsharp.TransactionAspects
{
    [PSerializable]
    public sealed class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var transactionScope = new TransactionScope(TransactionScopeOption.Required);
            args.MethodExecutionTag = transactionScope;
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Dispose();
        }
    }
}
