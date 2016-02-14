using System.Collections.Generic;

namespace Data.Mapper
{
    public interface IEntityMapper<TData, TDomain>
    {
        TDomain TransformTo(TData model);
        IEnumerable<TDomain> TransformTo(IEnumerable<TData> model);
    }
}
