using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    
    
        public record SchoolDto(Guid Id, string Name, string FullAddress);
    
}
