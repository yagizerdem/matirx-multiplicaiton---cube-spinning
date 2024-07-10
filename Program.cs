using System.Diagnostics.CodeAnalysis;

namespace matrix_multiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            double angle = Math.PI / 10;
            double[,] point = new double[3, 1] { { 1 }, { 1 } , { 1 } }; // x y z
            double[,] transformationMatrixY = new double[3, 3] { { Math.Cos(angle), 0 ,Math.Sin(angle) }, { 0, 1, 0}, { -Math.Sin(angle), 0, Math.Cos(angle) } };
            double[,] transformationMatrixZ = new double[3, 3] { { Math.Cos(angle), -Math.Sin(angle), 0 }, { Math.Sin(angle), Math.Cos(angle), 0 }, { 0, 0, 1 } };
            double[,] transformationMatrixX = new double[3, 3] { { 1, 0, 0 }, { 0, Math.Cos(angle), -Math.Sin(angle) }, { 0, Math.Sin(angle), Math.Cos(angle)} };

            List<double[,]> allPoints = new List<double[,]>();
            // back
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { i }, { j }, { 1 } });
                }
            }
            ////// front
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { i }, { j }, { 0 } });
                }
            }
            // left side
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { 0 }, { i }, { j } });
                }
            }
            // right
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { 10 }, { i }, { j } });
                }
            }
            //// bottom
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { i }, { 10 }, { j } });
                }
            }
            //// top
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allPoints.Add(new double[3, 1] { { i }, { 0 }, { j } });
                }
            }

            while (true)
            {
                // print all posint
                foreach (double[,] p in allPoints)
                {
                    printDot(p[0, 0], p[1, 0]);
                }

                List<double[,]> temp = new List<double[,]>();
                // multiplay
                foreach (double[,] p in allPoints)
                {

                    double[,] result = multiplication(transformationMatrixX, p); // Z axis transformation 
                    result = multiplication(transformationMatrixZ, result);
                    result = multiplication(transformationMatrixY, result);
                    temp.Add(result);
                
                }
                Thread.Sleep(100);
                Console.Clear();
             
                allPoints = temp;

            }
            


        }
        public static double[,] multiplication(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
            {
                throw new Exception("invalid input");
            }
            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    double sum = 0;
                    int l = m1.GetLength(1);
                    for (int k = 0; k < l; k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
        
        public static void printDot(double x , double y)
        {

            Console.SetCursorPosition((int)Math.Floor(x) + 30, (int)Math.Floor(y) + 15);
            Console.Write("*");
        }
    
    }
}
