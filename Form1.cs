using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nummeth
{
    public partial class Form1 : Form
    {
        
        static double maxi = 6, max = 11, min = 1, a = 4, b = 10;
        Random rnd = new Random();
        static int N = 10000;



        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(maxi);
            textBox6.Text = Convert.ToString(a);
            textBox7.Text = Convert.ToString(b);
            textBox8.Text = Convert.ToString(max);
            textBox9.Text = Convert.ToString(min);
            textBox10.Text = Convert.ToString(N);
            comboBox2.SelectedIndex = 0;
            comboBox2.Text =Convert.ToString(comboBox2.SelectedIndex);
        }
        double getrnd(double max,double min)
        {
            max = max + min + 1;
            var random = rnd.NextDouble() * max-min;
            if (random <0) return getrnd(max,min);
            if (min < 0)
            {
                if (rnd.Next(0, 100) >= 50)
                    random = -(random);
                        }
            return random ;
        }
        double simpson(Func<double, double> f, double a, double b, int n)
        {
            double result = 0;
            /*  var h = (b - a) / n;
               var sum1 = 0d;
               var sum2 = 0d;
              double xk;
              double xk_1;
              for (var k = 1; k <= n; k++)
              {
                  xk = a + k * h;
                  if (k <= n - 1)
                  {
                      sum1 += f(xk);
                  }

                  xk_1 = a + (k - 1) * h;
                  sum2 += f((xk + xk_1) / 2);
              }

              result = h / 6d * (f(a) + 2*sum1 + 4 * sum2 +f(b));*/
            /*  
              double h = (b - a) / n;
              double x = a + h;

              while (x < b)
              {
                  result += 4 * f(x);
                  x += h;
                  result += 2 * f(x);
                  x += h;
              }
              result = (h / 3) * (result + f(a) - f(b));*/

             double h = (b - a) / n;
              double k1 = 0, k2 = 0;
              for (int i = 1; i < n; i ++)
              {
                  k1 += f(a + i * h);
                  k2 += f(a + (i + 1) * h);
              }
              result=h/6d*(f(a) + 4d * k1 + 2d * k2+f(b));
              

            /*    double h = (b - a) / n;
                for (int step = 0; step < n; step++)
                {
                    double x1 = a + step * h;
                    double x2 = a + (step + 1) * h;

                    result += (x2 - x1) / 6.0 * (f(x1) + 4.0 * f(0.5 * (x1 + x2)) + f(x2));
                }*/
           /* double h = (b - a) / n;
            double sum = 0;

            double x0 = a;
            double x1 = a + h;

            for (int i = 0; i <= n - 1; i++)
            {
                sum += f(x0) + 4 * f(x0 + h / 2) + f(x1);

                x0 += h;
                x1 += h;
            }

            result=(h / 6) * sum;*/
            textBox3.Text = Convert.ToString(result);

            return result;
        }
        double getpi()
        {
            
            double p = Math.PI;
            textBox2.Text =Convert.ToString(comboBox1.SelectedIndex);
            if (comboBox1.SelectedIndex == 0)
                p = Math.PI;
            if (comboBox1.SelectedIndex == 1)
                p = Math.PI/6;
            if (comboBox1.SelectedIndex == 2)
                p = Math.PI/4;
            if (comboBox1.SelectedIndex == 3)
                p = Math.PI/3;
            if (comboBox1.SelectedIndex == 4)
                p = Math.PI/2;
            return p;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                a = a * getpi();
                textBox6.Text = Convert.ToString(a);
            }
            if (checkBox2.Checked)
            {
                b = b * getpi();
               
                textBox7.Text = Convert.ToString(b);
            }
            if (checkBox1.CheckState ==CheckState.Unchecked && checkBox1.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("отметьте один или оба параметра", "чис.мет", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        double threeeight(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            double result;
            /*  var sum1 = 0d;
              var sum2 = 0d;
              var sum3 = 0d;
              for (var k = 1; k <= n; k++)
              {
                  var xk = a + k * h;
                  if (k <= n - 1)
                  {
                      sum1 += f(xk);
                  }

                  var xk_1 = a + (k - 1) * h;
                  sum2 += f((2*xk + xk_1) / 3);
                  sum3 += f((xk + 2*xk_1) / 3);
              }
             result =(h/8d)*(f(a)+sum1 + 3 * (sum2+sum3)+f(b));*/
            /*  var sum1 = 0d;
                var sum2 = 0d;
                var sum3 = 0d;
                for (var k = 1; k <= n; k++)
                {
                    var xk = a + k * h;
                    if (k <= n - 1)
                    {
                        sum1 += f(xk);
                    }

                    var xk_1 = a + (k - 1) * h;
                    sum2 += f((2 * xk + xk_1) / 3);
                    sum3 += f((xk + 2 * xk_1) / 3);
                }
                result = h* (1d/ 8d) * (f(a) + 2*sum1 + 3 * (sum2 + sum3) + f(b));*/
           float value;
            double interval_size = (b - a) / n;
            double sum = f(a) + f(b);
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0)
                    sum = sum + 2 * f(a + i * interval_size);
                else
                    sum = sum + 3 * f(a + i * interval_size);
            }
            result=(3 * interval_size / 8) * sum;
          
            textBox4.Text = Convert.ToString(result);
          
            return result;
          
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            maxi = Convert.ToDouble(textBox1.Text);
            min= Convert.ToDouble(textBox9.Text);
            max = Convert.ToDouble(textBox8.Text);
            b = getrnd(max, min+maxi);
            do
            {
                a = getrnd(b, min);
            }
            while ((b - a > maxi)||(a>b));

            textBox6.Text = Convert.ToString(a);
            textBox7.Text = Convert.ToString(b);
        }

        double fives(Func<double, double> f, double a, double b, int n)
        {
            double result;
            var h = (b - a) / n;
             double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
          
             for (var k = 1; k <= n; k++)
             {
                 var xk = a + k * h;
                 if (k <= n - 1)
                 {
                     sum1 += f(xk);
                 }

                 var xk_1 = a + (k - 1) * h;
                 sum2 += f((3 * xk + xk_1) / 4);
                 sum3 += f((xk + xk_1) / 2); ;
                 sum4 += f((xk + 3 * xk_1) / 4);
             }
            result = h * (7d * f(a) + 14d * sum1 + 32d * sum2 + 12d * sum3 + 32d * sum4 + 14d * f(b)) / 90d;

             /*    n -= n % 5; if (n < 5) n = 5;
                  int i;
                  double s = 0.0, x = a, h = (b - a) / (n - 1);
                  for (i = 0; i < n; i += 5)
                  {
                      s += 7.0 * f(x); x += h;
                      s += 32.0 * f(x); x += h;
                      s += 12.0 * f(x); x += h;
                      s += 32.0 * f(x); x += h;
                      s += 7.0 * f(x); x += h;
                  }
                  s *= (2.0 * h) / (45.0);
                  result = s*1.25;*/
             /*
             double sum = 14d * f(a); 
             double h = (b - a) / (n - 1); 
             double mod;
             int i = 1;
             for(i=1; i < n - 1;i++)
             {
                 mod = i % 4;
                 if (mod == 0)
                     sum += 14d * f(a + i * h);
                 else if (mod == 1)
                     sum += 32d * f(a + i * h);
                 else if (mod == 2)
                     sum += 12d * f(a + i * h);
                 else
                     sum += 32d * f(a + i * h);

             }
             result=2d * h / 45d * sum;
            */
            //  result = (b - a) * (7d * f(a) + 32d * f((3d * a + b) / 4d) + 12d * f((a + b) / 2d) + 32d * f((a + 3d * b) / 4d) + 7d * f(b)) / 90d;
            textBox5.Text = Convert.ToString(result);
            return result;
        }
        double sins(double a, double b)
        {
            double y=0;
           
            
            if (comboBox2.SelectedIndex == 0)
            {
                return y = Math.Cos(a) - Math.Cos(b);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                return Math.Sin(b) - Math.Sin(4);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                return Math.Log(Math.Cos(a)) - Math.Log(Math.Cos(b));
            }
            if (comboBox2.SelectedIndex == 3)
            {
                return Math.Log(b) - Math.Log(a);
            }
            if (comboBox2.SelectedIndex == 4)
            {
                return Math.Exp(b)-Math.Exp(a);
            }
            //textBox2.Text =Convert.ToString(y);
            return y;
        }
     
        void Checkf(Func<double, double> f)
        {
            double e,O,min=999999;
            O = 1d / 15d;
            richTextBox1.Clear();
          
           double s1 = Convert.ToDouble(textBox3.Text);
            
            double s2 = sins(a, b);
          //  richTextBox1.Text = "sin-" + Convert.ToString(s2)+'\n';
            e = Math.Abs(s2 - s1);
            min = e;
            textBox2.Text = "метод симпсона - "+Convert.ToString(min);
            
            richTextBox1.Text += "метод симпсона - "+Convert.ToString(e)+'\n';
            double t1 = Convert.ToDouble(textBox4.Text);
            double t2 = threeeight(f, a, b, 20000);
            O = 1d / 63d;
             e = Math.Abs(s2 - t1);
           
            if (e < min)
            {
                min = e;
                textBox2.Text = "метод симпсона 3/8 - " + Convert.ToString(min);
            }
            richTextBox1.Text += "метод симпсона 3/8 - " + Convert.ToString(e) + '\n';
            double f1 = Convert.ToDouble(textBox5.Text);
            double f2 = fives(f, a, b, 20000);
            O = 1d / 255d;
            e = Math.Abs(s2 - f1);
            if (e < min)
            {
                min = e;
                textBox2.Text = "метод пятиточий - " + Convert.ToString(min);
            }
            richTextBox1.Text += "метод пятиточий - " + Convert.ToString(e) ;
           

        }
        double f(double x)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                return Math.Sin(x);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                return Math .Cos(x);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                return Math.Tan(x);
            }
            if (comboBox2.SelectedIndex == 3)
            {
                return (1 / x);
            }
            if (comboBox2.SelectedIndex == 4)
            {
                return Math.Exp(x);
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
          
            a =Convert.ToDouble(textBox6.Text);
            b = Convert.ToDouble(textBox7.Text);
            N = Convert.ToInt32(textBox10.Text);
            if (a>b)
            {
                MessageBox.Show("a>b,введите корректное значение", "чис.мет", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            double sim = simpson(f, a, b, N);
            double three = threeeight(f, a, b,N);
            double five = fives(f, a, b,N);
            Checkf(f);
           
           
        }
    }
}
