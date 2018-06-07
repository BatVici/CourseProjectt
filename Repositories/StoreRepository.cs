using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    class StoreRepository : BaseRepository<Store>
    {

        public override void Save(Store store)
        {
            if (store.ID == 0)
            {
                base.Create(store);
            }
            else
            {
                base.Update(store, item => item.ID == store.ID);
            }
        }

    }
}
