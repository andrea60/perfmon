using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Pipelines
{
    public class UnitOfWorkPipeline<TReq, TResp> : IPipelineBehavior<TReq, TResp> where TReq : IRequest<TResp>
    {
        private IUnitOfWork UoW;

        public UnitOfWorkPipeline(IUnitOfWork uow)
        {
            UoW = uow;
        }

        public async Task<TResp> Handle(TReq request, RequestHandlerDelegate<TResp> next, CancellationToken cancellationToken)
        {
            try
            {
                var result = await next();
                await UoW.CommitAsync();
                return result;
            }
            catch
            {
                await UoW.DiscardAsync();
                throw;
            }
        }
    }
}
