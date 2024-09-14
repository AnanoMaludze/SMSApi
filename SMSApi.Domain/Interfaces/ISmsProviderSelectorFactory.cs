using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Domain.Interfaces
{
    public interface ISmsProviderSelectorFactory
    {
        ISmsProviderSelector CreateSelector(string selectionLogic);
    }
}
