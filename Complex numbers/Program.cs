using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Complex_numbers
{
    [Serializable]
    public class Complex
    {
        public int x;
        [NonSerialized]
        public int y;
            
        public Complex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    public Complex()
        {

        }

            public static Complex operator +(Complex c1, Complex c2)
        {
            int a = c1.x + c2.x;
            int b = c1.y + c2.y;
            Complex n = new Complex(a, b);
            return n;   
        }

            public static Complex operator *(Complex c1, Complex c2)
        {
            int a = (c1.x * c2.x) - (c1.y * c2.y);
            int b = (c1.x * c2.x) + (c1.y * c2.y);
            Complex m = new Complex(a, b);
            return m;
        }

        public override string ToString()
        {
            return x + "+" + y + "i"; 
        }
    }
    class Program
    {
        static void F1(Complex a)
        {
            FileStream fs = new FileStream(@"C:\Users\User_PC\Documents\PP2\Student\Week 4\Complex numbers\Complex numbers\maks1.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                xs.Serialize(fs, a);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("Done!");
        }

        static void F2()
        {
            FileStream fs = new FileStream(@"maks1.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex a = xs.Deserialize(fs) as Complex;
                Console.WriteLine(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 5);
            Complex c2 = new Complex(2, 5);
            Complex sum = c2 + c2;
            Complex product = c1 * c2;
            F1(sum);
            F1(product);
            F2();

        }
    }
}
