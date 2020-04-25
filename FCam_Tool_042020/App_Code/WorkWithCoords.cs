using MapOpennet.Models;
using System;
using System.Collections.Generic;

namespace MapOpennet.App_Code
{
    public class WorkWithCoords
    {
        public static Coord convertStringToCoord(string str)
        {
            string[] point = str.Replace(" ", "").Replace("(", "").Replace(")", "").Split(',');
            return new Coord()
            {
                lat = double.Parse(point[0]),
                lng = double.Parse(point[1])
            };
        }

        public static double distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            return (dist);
        }

        public static bool IsPointInPolygon(Coord[] polygon, Coord p)
        {
            double minX = polygon[0].lat;
            double maxX = polygon[0].lat;
            double minY = polygon[0].lng;
            double maxY = polygon[0].lng;
            for (int i = 1; i < polygon.Length; i++)
            {
                if (p == polygon[i])
                    return true;
                Coord q = polygon[i];
                minX = Math.Min(q.lat, minX);
                maxX = Math.Max(q.lat, maxX);
                minY = Math.Min(q.lng, minY);
                maxY = Math.Max(q.lng, maxY);
            }

            if (p.lat < minX || p.lat > maxX || p.lng < minY || p.lng > maxY)
            {
                return false;
            }

            bool inside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if ((polygon[i].lng > p.lng) != (polygon[j].lng > p.lng) &&
                     p.lat < (polygon[j].lat - polygon[i].lat) * (p.lng - polygon[i].lng) / (polygon[j].lng - polygon[i].lng) + polygon[i].lat)
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        public static double computeArea(List<Coord> path)
        {
            return Math.Abs(computeSignedArea(path));
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private static double polarTriangleArea(double tan1, double lng1, double tan2, double lng2)
        {
            double deltaLng = lng1 - lng2;
            double t = tan1 * tan2;
            return 2 * Math.Atan2(t * Math.Sin(deltaLng), 1 + t * Math.Cos(deltaLng));
        }

        private static double computeSignedArea(List<Coord> path)
        {
            double radius = 6378137;
            int size = path.Count;
            if (size < 3) { return 0; }
            double total = 0;
            Coord prev = path[size - 1];
            double prevTanLat = Math.Tan((Math.PI / 2 - deg2rad(prev.lat)) / 2);
            double prevLng = deg2rad(prev.lng);
            // For each edge, accumulate the signed area of the triangle formed by the North Pole
            // and that edge ("polar triangle").
            foreach (Coord point in path)
            {
                double tanLat = Math.Tan((Math.PI / 2 - deg2rad(point.lat)) / 2);
                double lng = deg2rad(point.lng);
                total += polarTriangleArea(tanLat, lng, prevTanLat, prevLng);
                prevTanLat = tanLat;
                prevLng = lng;
            }
            return total * radius * radius;
        }
    }
}