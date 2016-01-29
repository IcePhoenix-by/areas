using BP.Areas.mvcProject.Abstract;
using BP.Areas.mvcProject.Context;
using BP.Areas.mvcProject.Models;
using BP.Areas.mvcProject.Repository;

namespace Beltelecom.Domain.Repository
{
   public class UserRepository:BaseRepository<SUser>,IUserRepository
    {
       public UserRepository(bdConnectionString context) : base(context)
        {

        }
    }
}
