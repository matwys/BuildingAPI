﻿using MongoDB.Bson.Serialization.Attributes;

namespace BuildingAPI.Data
{
    public class Floor
    {
        public int Number { get; set; }
        public decimal HeightOfCeiling { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

        /**
        * method responsible for calculating Height of Floor
        *
        * @return float value of max of all height of the rooms + HseightOfCeiling
        */
        public decimal calculateHeight()
        {
            return HeightOfCeiling + Rooms.Max(item => item.calculateHeight());
        }

        public decimal calculateSurface()
        {
            return Rooms.Sum(item => item.calculateSurface());
        }
    }
}
