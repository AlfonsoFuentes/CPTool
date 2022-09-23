using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Interfaces
{
    public interface IAuditableEntityDTO
    {
        public int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string? Name { get; set; }

        string? Description { get; set; }

        Func<IAuditableEntityDTO, CancellationToken, Task<IResult<IAuditableEntityDTO>>>? SaveObject { get; set; }

        Func<IAuditableEntityDTO, IAuditableEntityDTO>? TransferDataToObject { get; set; }

        void OnSubscribeTransferData();

    }
}
