using BatchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchApp.IRepository
{
    public interface IBatchRepository
    {
        ICollection<BatchModel> GetBatches();
        BatchModel GetBatch(Guid batchId);
        bool CreateBatch(BatchModel batchObj);
        bool CheckIfBUExists(string businessUnitName);

        //bool CheckIfIdExists(Guid batchId);
        bool CheckAtribute(IEnumerable<Models.Atribute> atributesList);
        bool CheckACL(IEnumerable<Models.ACL> aclList);
        bool UpdateBatch(BatchModel batchObj);
        bool Save();
        //bool DeleteBatch(BatchModel bObj);
    }
}
