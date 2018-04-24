using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace CG_Lab_2
{
    public partial class MainWindow : Window
    {
        Wedge w; // клин
        PerspectiveCamera pcam; // изометрическая проекция
        OrthographicCamera ocam; // ортогональная проекция
        const int MARGIN = 15;

        // Инициализация окна
        public MainWindow()
        {
            InitializeComponent();
            pcam = new PerspectiveCamera();
            ocam = new OrthographicCamera();
        }

        // Отрисовка клина
        public void DrawWedge()
        {
            if((textbox_a != null) && (textbox_b != null) && (textbox_c != null) && (textbox_d != null))
            {
                // считываем стороны клина
                double a = Convert.ToDouble(textbox_a.Text);
                double b = Convert.ToDouble(textbox_b.Text);
                double c = Convert.ToDouble(textbox_c.Text);
                double d = Convert.ToDouble(textbox_d.Text);

                // Вызываем конструктор и функцию отрисовки
                w = new Wedge(a, b, c, d);
                w.Draw(geometry_model_3d);

                // Располагаем камеру в зависимости от размеров изображения
                pcam.Position = new Point3D(b + MARGIN, a + MARGIN, d + MARGIN);
                pcam.LookDirection = new Vector3D(-b - MARGIN, -a - MARGIN, -d - MARGIN);

                ocam.Position = new Point3D(b + MARGIN, a + MARGIN, d + MARGIN);
                ocam.LookDirection = new Vector3D(-b - MARGIN*5, -a - MARGIN*5, -d - MARGIN*5);
                ocam.Width = 20;
            }
        }

        // Обработчики нажатия
        private void Build_perspective_Click(object sender, RoutedEventArgs e)
        {
            DrawWedge();
            my_viewport.Camera = pcam;
        }

        private void Build_ortogonal_Click(object sender, RoutedEventArgs e)
        {
            DrawWedge();
            my_viewport.Camera = ocam;
        }
    }
}
