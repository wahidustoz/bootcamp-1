using System.Collections.Generic;

namespace lesson6
{
    public interface IStorage
    {
        List<Point> GetAllPoints();
        void InsertPoint(Point point);
        List<Point> FindPoints(string search);
    }
}