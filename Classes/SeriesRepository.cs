using System;
using System.Collections.Generic;
using Bootcamps.Avenade.Series.Interfaces;

namespace Bootcamps.Avenade.Series
{
    public class SeriesRepository : IRepositorio<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public void Add(Series obj)
        {
            seriesList.Add(obj);
        }

        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public List<Series> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Series ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Series obj)
        {
            seriesList[id] = obj;
        }
    }
}