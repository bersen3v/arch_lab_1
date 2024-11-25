using DataAccessLayer;
using Model;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogic
{
    
    public class SimpleConfigModule : NinjectModule
    {        
        public override void Load()
        {
            //Bind<IRepository<Student>>().To<EntityRepository<Student>>().InSingletonScope();
            //Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();


            //Logic logic = Logic.GetInstance(new EntityRepository<Student>(new StudentContext()));
            Logic logic = Logic.GetInstance(new DapperRepository());
            Bind<ILogic>().ToConstant(logic).InSingletonScope();
        }
    }
}
