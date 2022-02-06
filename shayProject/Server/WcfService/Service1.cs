using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.IO;
using System.Drawing;

using Model;
using ViewModel;
using BL;
namespace WcfService
{
    public class Service1 : IService1
    {
        public PositionList GetPosition()
        {
            PositionDB db = new PositionDB();
            return db.SelectAll();
        }
        public TypeDishesList  GetDish()
        {
            TypeDishesDB db = new TypeDishesDB();
            return db.SelectAll();
        }
        public JobStatusList GetJobs()
        {
            JobStatusDB db = new JobStatusDB();
            return db.SelectAll();
        }





        public Worker LoginWorker(string name,string pas)
        {
            WorkerDB db = new WorkerDB();
            return db.Login(  name,   pas);
        }

        public int InsertWorker(Worker worker)
        {
            WorkerDB db = new WorkerDB();
            db.Insert(worker);
            int n = db.SaveChanges();
            if (n > 0) return worker.Id;
            else return -1;
        }
        public int InsertDish(Menuu dish)
        {
            MenuDB db = new MenuDB();
            db.Insert(dish);
            int n = db.SaveChanges();
            if (n > 0) return dish.Id;
            else return -1;
        }


        public int UpdateWorker(Worker worker)
        {
            WorkerDB db = new WorkerDB();
            db.Update(worker);
            int n = db.SaveChanges();
            if (n > 0) return worker.Id;
            else return -1;
        }
        public int UpdateDish(Menuu dish)
        {
            MenuDB db = new MenuDB();
            db.Update(dish);
            int n = db.SaveChanges();
            if (n > 0) return dish.Id;
            else return -1;
        }




        public int DeleteWorker(Worker worker)
        {
            WorkerDB db = new WorkerDB();
            db.Delete(worker);
            int n = db.SaveChanges();
            if (n > 0) return worker.Id;
            else return -1;
        }

        public int DeleteDish(Menuu dish)
        {
            MenuDB db = new MenuDB();
            db.Delete(dish);
            int n = db.SaveChanges();
            if (n > 0) return dish.Id;
            else return -1;
        }




        public WorkerList GetAll()
        {
            WorkerDB db = new WorkerDB();
            return db.SelectAll();
        }
        public MenuList GetAllDishes()
        {
            MenuDB db = new MenuDB();
            return db.SelectAll();
        }


        public int InsertImage(Menuu image)
        {
            MenuDB db = new MenuDB();
            db.Insert(image);
            int n = db.SaveChanges();
            if (n > 0) return image.Id;
            else return -1;
        }
        public byte[] GetImage(string fileName)
        {
            // הנחה: הקובץ המבוקש נמצא בתיקייה Images בתוך ViewModel
            // הפרמטר שמתקבל כולל רק שם הקובץ של התמונה 
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\" + "/ViewModel/Images/" + fileName);
            byte[] imgArray = File.ReadAllBytes(path);


            return imgArray;
        }

        public void SaveImage(byte[] imageArray, string fileName)
        {
            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            string localFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\" + "/ViewModel/Images/" + fileName);
            if (!File.Exists(localFilePath))
                 img.Save(localFilePath);
        }
        public void DeskStatus(int n)
        {

        }
       public void WaitingWaiter(Desk desk)
        {
            DeskDB db = new DeskDB();
            db.ChangeStatus(desk);
        }
        public void AddDishToDesk(Menuu menu, Desk desk)
        {
            BL.BL.Add(menu,desk);
        }
        public DeskMenuList GetDeskList(Desk desk)
        {
            return BL.BL.GetDeskList(desk);
        }
        public Desk GetFreeDesk(int n)
        {
            return BL.BL.GetFreeDesk(n);
        }
        public DeskList GetAllDesks()
        {
            return BL.BL.GetAllDesks();
        }


        public void ChangeDeskStatus(Desk desk, JS status)
        {
            BL.BL.ChangeDeskStatus(desk, status);
        }

        public double GetBill(Desk desk)// מביא חשבון שולחן 
        {
            return BL.BL.GetDeskBill(desk);
        }
        //// השאלה אם זה צריך להיות double או משהו אחר
        //public DeskMenuList GetAllDeskMenu()
        //{
        //    return BL.BL.GetCheffList();
        //}

        public void ss(DeskMenuList dd)
        { }

        public double DeskOrder(DeskMenuList list)
        {
          
            return   BL.BL.DeskOrder( list);;
        }

        public DeskMenuList GetDeskMenuList(JS js)
        {
            return BL.BL.GetDeskMenuList(js);
        }

        public int ChangeStatus(DeskMenu deskMenu,JS js)
        {
            return BL.BL.ChangeStatus(deskMenu, js);
        }

        
    }
}
