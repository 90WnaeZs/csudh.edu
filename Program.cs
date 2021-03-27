using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csudh
{

    // Központi feladat - csudh.edu

    class csudh_class
    {
        public string domain_név { get; set; }

        public string IP_cím { get; set; }
    }

    class Program
    {
        private string elso_sor;
        private string sor;
        private int counter = 0;
        private string IPcím = "155.135.1.15";

        List<csudh_class> csudh_list = new List<csudh_class>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Beolvasas();
            Console.WriteLine(p.Szamlalo());
            Console.WriteLine();
            Console.WriteLine("4. feladat: ");
            Console.WriteLine("Adjon meg egy számot!");
            int szint = int.Parse(Console.ReadLine());
            Console.WriteLine();
            p.Domain(szint);
            p.HTML_iras();
            Console.ReadLine();
        }
        private void Beolvasas()    // 2. feladat: olvassa be az adatokat
        {
            string filePath = @"C:\Users\Zs\Desktop\csudh.txt";

            elso_sor = File.ReadLines(filePath).First();
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    if (counter == 0)
                    {
                        elso_sor = sr.ReadLine();
                    }
                    else
                    {
                        sor = sr.ReadLine();
                        string[] tomb = sor.Split(';');
                        csudh_class new_csudh = new csudh_class();

                        new_csudh.domain_név = tomb[0];
                        new_csudh.IP_cím = tomb[1];

                        csudh_list.Add(new_csudh);
                    }

                    counter++;
                }
            }
        }
        private int Szamlalo()  // 3. feladat: hány domain-ip páros található
        {
            Console.WriteLine("3. feladat: ");
            counter = 0;
            foreach (var item in csudh_list)
            {
                counter++;
            }
            
            return counter;
            
        }
        private void Domain(int szint)   // 4. feladat: adjon meg egy értéket, és leellenőrzi, hogy van-e olyan szintű domain név
        {
            // 4. feladat

            foreach (var item in csudh_list)
            {
                if(item.IP_cím==IPcím)
                {
                    string[] tomb = item.domain_név.Split('.');

                    if(tomb.Length>szint)
                    {
                        Console.WriteLine(tomb[szint]);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Nincs");
                        Console.WriteLine();
                    }
                }
            }

            // 5. feladat

            Console.WriteLine("5. feladat: "); 
            int counter = 0;
            foreach (var item in csudh_list)
            {
                if (counter==0)
                {
                    string elsosor = item.domain_név + item.IP_cím;
                }
                if(counter==1)
                {
                    string[] tomb2 = item.domain_név.Split('.');

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"{i + 1}. szint: ");
                        if (tomb2.Length > i)
                        {
                            Console.Write($"{tomb2[i]} ");
                        }
                        else
                        {
                            Console.Write($"nincs ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                counter++;
            }

            /*using (StreamReader sr=new StreamReader(filePath,Encoding.UTF8))
            {
                string[] tomb = sr.ReadLine().Split(';');
                string[]tomb1 = sr.ReadLine().Split(';');
                csudh_class cs = new csudh_class();

                cs.domain_név = tomb1[0];
                cs.IP_cím = tomb1[1];

                csudh_list.Add(cs);


                foreach (var item in csudh_list)
                {
                    string[] tomb2= item.domain_név.Split('.');

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"{i+1}. szint: ");
                        if(tomb2.Length>i)
                        {
                            Console.Write($"{tomb2[i]} ");
                        }
                        else
                        {
                            Console.Write($"nincs ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            */
        }



        private void HTML_iras()  // 6. feladat
        {
            string filePath = @"C:\Users\Zs\Desktop\table.html";
            int counter = 1;
            using (StreamWriter sw=new StreamWriter(filePath))
            {
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th style='text-align: left'>Ssz</th>");
                sw.WriteLine("<th style='text-align: left'>Host domain neve</th>");
                sw.WriteLine("<th style='text-align: left'>Host IP címe</th>");
                sw.WriteLine("<th style='text-align: left'>1. szint</th>");
                sw.WriteLine("<th style='text-align: left'>2. szint</th>");
                sw.WriteLine("<th style='text-align: left'>3. szint</th>");
                sw.WriteLine("<th style='text-align: left'>4. szint</th>");
                sw.WriteLine("<th style='text-align: left'>5. szint</th>");
                sw.WriteLine("</tr>");
                foreach (var item in csudh_list)
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine($"<th style='text-align: left'>{counter}</th>");
                    sw.WriteLine($"<td>{item.domain_név}</td>");
                    sw.WriteLine($"<td>{item.IP_cím}</td>");

                    string[] tomb2 = item.domain_név.Split('.');
                    for (int i = 0; i < 5; i++)
                    {
                        if (tomb2.Length > i)
                        {
                            sw.WriteLine($"<td>{tomb2[i]}</td>");
                        }
                        else
                        {
                            sw.WriteLine($"<td>nincs</td>");
                        }
                        Console.WriteLine();
                    }
                    sw.WriteLine("</tr>");
                    Console.WriteLine();
                    counter++;
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
        }
    }
}
