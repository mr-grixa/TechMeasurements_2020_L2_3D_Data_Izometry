using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechMeasurements_2020_L2_3D_Data_Izometry;

namespace TechMeasurements_2020_L2_3D_Data_Izometry
{
 
    internal class Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    internal class Cluster
    {

        public int Id;// Идентификатор кластера
        public List<Point3D> Points; // Список точек кластера
        public Point3D Center; // Центр кластера
        public double Radius;
        public double RadiusX;
        public double RadiusY;
        public double RadiusZ;

        public Cluster(int id, List<Point3D> points, Point3D center)
        {
            Id = id;
            Points = points;
            Center = center;          
        }
    }

    internal static class KMeans
    {
        public static Cluster[] gen(List<Point3D> points, int k, int max)
        {
            List<List<Point3D>> clusters = new List<List<Point3D>>();

            // Step 1: Initialize k clusters randomly
            List<Point3D> centroids = InitializeClusters(points, k);
            int convergenceInt = 0;
            while (true)
            {
                
                // Step 2: Assign each point to the nearest centroid
                clusters.Clear();
                for (int i = 0; i < k; i++)
                {
                    clusters.Add(new List<Point3D>());
                }
                foreach (Point3D point in points)
                {
                    int nearestCentroidIndex = GetNearestCentroidIndex(point, centroids);
                    clusters[nearestCentroidIndex].Add(point);
                }

                // Step 3: Recalculate centroids
                List<Point3D> newCentroids = new List<Point3D>();
                for (int i = 0; i < k; i++)
                {
                    if (clusters[i].Count == 0)
                    {
                        newCentroids.Add(centroids[i]);
                    }
                    else
                    {
                        Point3D newCentroid = new Point3D(
                            clusters[i].Average(p => p.X),
                            clusters[i].Average(p => p.Y),
                            clusters[i].Average(p => p.Z)
                        );
                        newCentroids.Add(newCentroid);
                    }
                }

                // Step 4: Check for convergence
                bool converged = true;
                convergenceInt++;
                for (int i = 0; i < k; i++)
                {
                    if (centroids[i] != newCentroids[i])
                    {
                        converged = false;
                        break;
                    }
                }
                if (converged ||convergenceInt > max)
                {
                    break;
                }

                centroids = newCentroids;
            }
            Cluster[] cluster = new Cluster[k];
            for (int i = 0; i < clusters.Count; i++)
            {
                cluster[i] = new Cluster(i, clusters[i], centroids[i]);
            }
            return searchRadius(cluster);
        }

        private static Cluster[] searchRadius(Cluster[] clusters)
        {
            foreach(Cluster cluster in clusters)
            {
                double maxDistance = 0;
                foreach (Point3D point in cluster.Points)
                {
                    double distance = Math.Sqrt(Math.Pow(point.X - cluster.Center.X, 2) + 
                                                Math.Pow(point.Y - cluster.Center.Y, 2) +
                                                Math.Pow(point.Z - cluster.Center.Z, 2));
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
                cluster.Radius = maxDistance;
                maxDistance = 0;
                foreach (Point3D point in cluster.Points)
                {
                    double distance = Math.Abs(point.X - cluster.Center.X);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
                cluster.RadiusX = maxDistance;
                maxDistance = 0;
                foreach (Point3D point in cluster.Points)
                {
                    double distance = Math.Abs(point.Y - cluster.Center.Y);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
                cluster.RadiusY = maxDistance;
                maxDistance = 0;
                foreach (Point3D point in cluster.Points)
                {
                    double distance = Math.Abs(point.Z - cluster.Center.Z);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
                cluster.RadiusZ = maxDistance;
            }
            return clusters;
        }

        private static List<Point3D> InitializeClusters(List<Point3D> points, int k)
        {
            List<Point3D> centroids = new List<Point3D>();
            Random random = new Random();
            for (int i = 0; i < k; i++)
            {
                int randomIndex = random.Next(points.Count);
                centroids.Add(points[randomIndex]);
            }
            return centroids;
        }

        private static int GetNearestCentroidIndex(Point3D point, List<Point3D> centroids)
        {
            double minDistance = double.MaxValue;
            int nearestCentroidIndex = 0;
            for (int i = 0; i < centroids.Count; i++)
            {
                double distance = Math.Sqrt(Math.Pow(point.X - centroids[i].X, 2) + Math.Pow(point.Y - centroids[i].Y,2) + Math.Pow(point.Z - centroids[i].Z, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCentroidIndex = i;
                }
            }
            return nearestCentroidIndex;
        }
    }
    internal static class Draw
    {
        public static void Cube(OpenGL gl, double x, double y, double z, double size)
        {
            double halfSize = size / 2;

            gl.Begin(OpenGL.GL_QUADS);

            //front face
            gl.Vertex(x - halfSize, y - halfSize, z + halfSize);
            gl.Vertex(x + halfSize, y - halfSize, z + halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z + halfSize);
            gl.Vertex(x - halfSize, y + halfSize, z + halfSize);

            //back face
            gl.Vertex(x - halfSize, y - halfSize, z - halfSize);
            gl.Vertex(x - halfSize, y + halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y - halfSize, z - halfSize);

            //top face
            gl.Vertex(x - halfSize, y + halfSize, z - halfSize);
            gl.Vertex(x - halfSize, y + halfSize, z + halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z + halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z - halfSize);

            //bottom face
            gl.Vertex(x - halfSize, y - halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y - halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y - halfSize, z + halfSize);
            gl.Vertex(x - halfSize, y - halfSize, z + halfSize);

            //left face
            gl.Vertex(x - halfSize, y - halfSize, z - halfSize);
            gl.Vertex(x - halfSize, y + halfSize, z - halfSize);
            gl.Vertex(x - halfSize, y + halfSize, z + halfSize);
            gl.Vertex(x - halfSize, y - halfSize, z + halfSize);

            //right face
            gl.Vertex(x + halfSize, y - halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z - halfSize);
            gl.Vertex(x + halfSize, y + halfSize, z + halfSize);
            gl.Vertex(x + halfSize, y - halfSize, z + halfSize);

            gl.End();
        }

        public static void Rectangle(OpenGL gl, double x, double y, double z, double widthX, double widthY, double widthZ)
        {
            // Вычисляем координаты углов прямоугольника
            double x1 = x - widthX;
            double y1 = y - widthY;
            double z1 = z - widthZ;
            double x2 = x + widthX;
            double y2 = y + widthY;
            double z2 = z + widthZ;

            // Рисуем прямоугольник
            gl.Begin(OpenGL.GL_QUADS);
            // Грань X1
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x1, y2, z1);
            gl.Vertex(x1, y2, z2);
            gl.Vertex(x1, y1, z2);
            // Грань X2
            gl.Vertex(x2, y1, z1);
            gl.Vertex(x2, y2, z1);
            gl.Vertex(x2, y2, z2);
            gl.Vertex(x2, y1, z2);
            // Грань Y1
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x2, y1, z1);
            gl.Vertex(x2, y1, z2);
            gl.Vertex(x1, y1, z2);
            // Грань Y2
            gl.Vertex(x1, y2, z1);
            gl.Vertex(x2, y2, z1);
            gl.Vertex(x2, y2, z2);
            gl.Vertex(x1, y2, z2);
            // Грань Z1
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x2, y1, z1);
            gl.Vertex(x2, y2, z1);
            gl.Vertex(x1, y2, z1);
            // Грань Z2
            gl.Vertex(x1, y1, z2);
            gl.Vertex(x2, y1, z2);
            gl.Vertex(x2, y2, z2);
            gl.Vertex(x1, y2, z2);
            gl.End();
        }

    }
}

