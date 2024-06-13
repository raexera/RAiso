using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class StationeryRepository
    {
        private static readonly DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<MsStationery> GetAll()
        {
            return db.MsStationeries.ToList();
        }

        public static MsStationery GetStationery(string name)
        {
            return db.MsStationeries.FirstOrDefault(s => s.StationeryName == name);
        }

        public static MsStationery FindStationery(int id)
        {
            return db.MsStationeries.Find(id);
        }

        public static MsStationery GetLastStationery()
        {
            return (from s in db.MsStationeries
                    select s).ToList().LastOrDefault();
        }

        public static void InsertStationery(MsStationery s)
        {
            db.MsStationeries.Add(s);
            SaveChanges();
        }

        public static void DeleteStationery(MsStationery s)
        {
            db.MsStationeries.Remove(s);
            SaveChanges();
        }

        public static void UpdateStationery(MsStationery s, string name, int price)
        {
            s.StationeryName = name;
            s.StationeryPrice = price;
            SaveChanges();
        }

        private static void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
