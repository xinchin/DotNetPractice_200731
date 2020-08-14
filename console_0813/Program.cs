using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace console_0813
{
    class Program
    {
        static int size = 500000;


        static void Main(string[] args)
        {
            test3();
            test4();
            Console.ReadKey();
        }

        #region test1
        static void test1()
        {
            useGenericList();
            useArrayList();
        }


        static void useArrayList()
        {
            ArrayList list = new ArrayList();
            long startDT = DateTime.Now.Ticks;

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < size; i++)
            {
                int value = (int)list[i];
            }
            long endDT = DateTime.Now.Ticks;
            Console.WriteLine((endDT - startDT).ToString());
        }

        static void useGenericList()
        {
            List<int> list = new List<int>();
            long startDT2 = DateTime.Now.Ticks;

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < size; i++)
            {
                int value = list[i];
            }
            long endDT2 = DateTime.Now.Ticks;
            Console.WriteLine((endDT2 - startDT2).ToString());

        }

        #endregion

        #region test2
        public delegate void GreetingDelegate(string name);
        static void test2()
        {

            GreetingDelegate g;
            g = greet1;
            g += greet2;

            show("Nelson Huang", g);
            //show("Nelson", greet1);
            //show("Nelson", greet2);

        }

        static void show(string name, GreetingDelegate f)
        {
            f(name);
        }

        static void greet1(string name)
        {
            Console.WriteLine($"greet 1 : {name}");
        }

        static void greet2(string name)
        {
            Console.WriteLine($"greet 2 : {name}");
        }

        #endregion

        #region test3
        static void test3()
        {


            IFormatter formatter = new BinaryFormatter();
            Product item = new Product();
            item.Name = "book";
            Stream fs = File.OpenWrite(@"D:\RD_2020\product.obj");
            formatter.Serialize(fs, item);
            fs.Dispose();



        }
        [Serializable]
        public class Product
        {
            private int id;
            public string Name { get; set; }
        }


        #region test4
        static void test4()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream fs = File.OpenRead(@"D:\RD_2020\product.obj");
            Product item = (Product)formatter.Deserialize(fs);
            fs.Dispose();
            Console.WriteLine(item.Name);
        }
        #endregion

        #endregion

    }
}
