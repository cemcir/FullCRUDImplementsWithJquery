using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Responses
{
    public class BaseResponse<TEntity> where TEntity : class
    {
        public TEntity Extra { get; set; }

        public bool Success { get; set; }

        public int ErrorMessageCode { get; set; }

        public BaseResponse(TEntity extra)
        {
            this.Success = true;
            this.Extra = extra;
        }

        public BaseResponse(int errorMessageCode)
        {
            this.Success = false;
            this.ErrorMessageCode = errorMessageCode;
        }
    }
}
