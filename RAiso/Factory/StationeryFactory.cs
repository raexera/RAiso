using RAiso.Model;
using System;

namespace RAiso.Factory
{
    public class StationeryFactory
    {
        public static MsStationery CreateStationery(int id, String name, int price)
        {
            MsStationery stationery = new MsStationery
            {
                StationeryID = id,
                StationeryName = name,
                StationeryPrice = price
            };

            return stationery;
        }
    }
}