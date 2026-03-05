<<<<<<< HEAD
﻿using POS.Infrastructure.Commons.Bases.Request;
=======
﻿using POS.Infrastructure.Commons.Bases;
>>>>>>> 6d20b31533ce8f586b93660028abbb8bd68570ec

namespace POS.Infrastructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
    }
}
