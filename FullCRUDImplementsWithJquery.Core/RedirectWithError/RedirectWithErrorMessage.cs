using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Redirect;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.RedirectWithError
{
    public class RedirectWithErrorMessage
    {
        public RedirectToPage RedirectToPage { get; set; }
        public ErrorMessageCode ErrorMessageCode { get; set; }

        public RedirectWithErrorMessage(RedirectToPage redirectToPage,ErrorMessageCode errorMessageCode) {
            this.ErrorMessageCode = errorMessageCode;
            this.RedirectToPage = redirectToPage;
        }
    }
}
