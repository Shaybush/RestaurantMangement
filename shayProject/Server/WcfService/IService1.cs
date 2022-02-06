using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Model;
using System.Text;


namespace WcfService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Worker LoginWorker(string uname, string pass);

        [OperationContract]
        WorkerList GetAll();

        [OperationContract]
        DeskList GetAllDesks();


        //[OperationContract]
        //DeskMenuList GetAllDeskMenu();

        [OperationContract]
        PositionList GetPosition();

        [OperationContract]
        TypeDishesList GetDish();

        [OperationContract]
        JobStatusList GetJobs();

        [OperationContract]
        MenuList GetAllDishes();

        [OperationContract]
        int InsertWorker(Worker worker);
        [OperationContract]
        int UpdateWorker(Worker worker);
        [OperationContract]
        int DeleteWorker(Worker worker);

        [OperationContract]
        int InsertDish(Menuu dish);
        [OperationContract]
        int UpdateDish(Menuu dish);
        [OperationContract]
        int DeleteDish(Menuu dish);

        [OperationContract]
        void WaitingWaiter(Desk desk);

        [OperationContract]
        byte[] GetImage(string fileName);
        [OperationContract]
        void SaveImage(byte[] imageArray, string fileName);


        [OperationContract]
        void DeskStatus(int n);

        [OperationContract]
        Desk GetFreeDesk(int n); // מחפש שולחן שהוא לא תפוס
        [OperationContract]
        void ChangeDeskStatus(Desk desk, JS status); // משנה את הסטטוס של שולחן בזמן הרצה
        [OperationContract]
        double GetBill(Desk desk); // מביא חשבון לשולחן
        [OperationContract]
        void AddDishToDesk(Menuu menu, Desk desk); //מוסיף מנה לשולחן

        [OperationContract]
        DeskMenuList GetDeskList(Desk desk); // מחזיר את כל המנות של השולחן הנ"ל

        [OperationContract]
        void ss(DeskMenuList dd);

        [OperationContract]
        double DeskOrder(DeskMenuList list);

        [OperationContract]
        DeskMenuList GetDeskMenuList(JS js);

        [OperationContract]
        int ChangeStatus(DeskMenu deskMenu, JS js);
    }
}
