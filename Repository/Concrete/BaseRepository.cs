using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository.Concrete
{
    public class BaseRepository
    {
        protected AppContext context;

        public BaseRepository()
        {
            context = AppContext.Create();
        }
    }
}
