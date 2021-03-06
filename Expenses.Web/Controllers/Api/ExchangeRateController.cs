﻿using System.Threading.Tasks;
using Expenses.Data.Contracts;
using Expenses.Web.Filters;
using System;
using System.Web.Http;

namespace Expenses.Web.Controllers.Api
{
    [ValidateHttpAntiForgeryToken]
    public class ExchangeRateController : ApiController
    {
        
        public ExchangeRateController(ICurrencyProvider currencyProvider)
        {
            _currencyProvider = currencyProvider;
        }
        
        public async Task<decimal> Get(string baseIso, string targetIso, DateTime exchangeDate)
        {
            if (_currencyProvider == null)
                return 1;
            if (string.Compare(baseIso, targetIso, System.StringComparison.OrdinalIgnoreCase) == 0)
                return 1;
                
            return _currencyProvider != null ? await _currencyProvider.GetExchangeRate(baseIso, targetIso, exchangeDate) : 1;
        }


        private readonly ICurrencyProvider _currencyProvider = null;
    }
}
