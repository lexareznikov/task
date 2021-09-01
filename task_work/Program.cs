using BusinessLayer.Domain;
using Domain.Classes;
using Infrastructure.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace task_work
{
    static class Program
    {

        static private IUnitOfWork unitOfWork = new UnitOfWork(new Domain.EFDbContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New Job!");


            //var model = GetById(1);
            //model.TypeId = 1;
            //model.Childrens.Add(new ObjectClass { TypeId = 3 });
            //model.AreaChangings.Add(new AreaChanging { Val1 = 3,Val2=1,Area=3,ChangingDate = DateTime.Now });
            //  Update(model);


            //var model = new ObjectClass
            //{
            //    AreaChangings = new List<AreaChanging> {
            //        new AreaChanging {
            //            Val1 = 100,
            //            Val2 = 100,
            //            ChangingDate = DateTime.Now,
            //            Area = 10000} },
            //    TypeId = 3
            //};
            //Create(model);

            //Delete(5);
        }
        static bool Update(ObjectClass model)
        {
            try
            {
                unitOfWork.ObjectClasses.Update(model);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        static bool Create(ObjectClass model)
        {
            try
            {
                unitOfWork.ObjectClasses.Create(model);
                unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        static bool Delete(int id)
        {
            var model = GetById(id);
            if (model != null)
            {
                try
                {
                    if (model.Childrens.Any())
                    {
                        foreach (var item in model.Childrens.ToArray())
                        {
                            item.ParentId = null;
                            Update(item);
                        }
                    }
                    model.Childrens = null;
                    model.AreaChangings = null;
                    unitOfWork.ObjectClasses.Delete(model);
                    unitOfWork.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        static ObjectClass GetById(int id)
        {
            return unitOfWork.ObjectClasses.Filter(x => x.Id == id).FirstOrDefault();
        }
        //static public IUnitOfWork GetUnitOfWork()
        //{
        //    return unitOfWork == null ? unitOfWork = new UnitOfWork(new Domain.EFDbContext()) : unitOfWork;
        //}
    }
}

