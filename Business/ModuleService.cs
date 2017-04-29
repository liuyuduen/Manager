using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBusiness;
using Base.Entity;
using Base.Utility;

namespace Business
{
    public class ModuleService : IModuleService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }

        DataContext db = new DataContext();

        public int AddModule(T_Module module)
        {
            int result = -1;
            db.T_Module.Add(module);
            result = db.SaveChanges();
            return result;
        }
        public int UpdateModule(T_Module module)
        {
            int result = -1;
            T_Module obj = db.T_Module.Find(module.ModuleID);
            obj = module;
            result = db.SaveChanges();
            return result;
        }
        public int DeleteModule(string ModuleID)
        {
            int result = -1;
            T_Module obj = db.T_Module.Find(ModuleID);
            db.T_Module.Remove(obj);
            result = db.SaveChanges();
            return result;
        }



        public T_Module GetModuleByID(string ModuleID)
        {
            var module = db.T_Module.Select(t => t != null && t.ModuleID == ModuleID && t.SystemID == SystemID);
            return module as T_Module;
        }

        public List<T_Module> GetRoleList()
        {
            List<T_Module> modules = null;

            modules = db.T_Module.ToList();

            return modules;
        }
    }
}
