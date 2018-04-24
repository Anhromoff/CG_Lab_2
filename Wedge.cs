using System;
using System.Windows.Media.Media3D;

namespace CG_Lab_2
{
    class Wedge
    {
        private Point3D A, B, C, A1, B1, C1;

        // Просчитываем каждую точку клина
        public Wedge(double a, double b, double c, double d)
        {
            double x = (a * a + b * b - c * c) / (2 * a);
            double y = Math.Sqrt(b * b - x * x);

            A = new Point3D(0, 0, 0);
            B = new Point3D(a, 0, 0);
            C = new Point3D(x, y, 0);

            A1 = new Point3D(0, 0, d);
            B1 = new Point3D(a, 0, d);
            C1 = new Point3D(x, y, d);
        }

        // Отрисовка
        public void Draw(GeometryModel3D geometry_model_3d)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Заносим все точки в массив
            mesh.Positions.Add(A);
            mesh.Positions.Add(B);
            mesh.Positions.Add(C);
            mesh.Positions.Add(A1);
            mesh.Positions.Add(B1);
            mesh.Positions.Add(C1);

            // По очереди для каждого теугольника пишем порядок соединения его вершин линиями
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(0);

            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);

            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(0);

            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(4);

            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(2);

            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);

            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(1);

            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(5);

            geometry_model_3d.Geometry = mesh;
        }
    }
}
