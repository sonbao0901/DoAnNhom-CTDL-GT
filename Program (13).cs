using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csdl
{
    class Program
    {
        static string find(WareHouse[] a, int year)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].GetYear() == year) s = a[i].ToString();
            }
            return s;
        }
        static string form(string a)
        {
            string b = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != ' ')
                    b = b + a[i];
            }
            return b;
        }
        static bool check(string a)
        {
            int d = 0;
            bool bol = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > '9' || a[i] < '0')
                    d++;
            }
            if (d > 0) bol = false;
            else bol = true;
            return bol;
        }

        static void Input(int n, Graph thegraph, List<string> a)
        {
        nhap:
            int i = 0;
            while (true)
            {
                i++;
                Console.Write("Nhà kho đi :"); int diemdau = int.Parse(Console.ReadLine());
                Console.Write("Nhà kho đến :"); int diemcuoi = int.Parse(Console.ReadLine());
                Console.Write("Chí phí di chuyển  :"); int chiphi = int.Parse(Console.ReadLine());
                thegraph.AddEdge(diemdau, diemcuoi, chiphi);
                string cau = "Chi phí di chuyển từ nhà kho " + diemdau + " đến nhà kho " + diemcuoi + " là " + chiphi;
                a.Add(cau);
                Console.WriteLine("*************");
                Console.WriteLine("Nhập số 1 để tiếp tục nhập dữ liệu \nHoặc nhập số khác bất kì để ngừng việc nhập dữ liệu!");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("*************");
                if (choice == 1) goto nhap;
                else break;
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n1 = 0;
            List<string> a = new List<string>();
            List<WareHouse> mylist = new List<WareHouse>();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t      ĐỒ ÁN :CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT \n\n \t\t\tDANH SÁCH NHÓM : PHAN TRẦN SƠN BẢO \n\t\t\t\t\t ĐỖ XUÂN ĐỨC         \n\t\t\t\t\t lÊ HUỲNH HOÀNG KHANG         \n\t\t\t\t\t TRƯƠNG VĂN KIỆT         \n\t\t\t\t\t NGUYỄN ĐÌNH ĐẠI NHƠN         \n\t\t\t\t      **************************************");
            Console.WriteLine("> Bạn đang không biết nên đi đường nào để tiết kiệm và thông minh nhất . HÃY ĐỂ CHÚNG TÔI GIÚP BẠN ! \n MENU: \n\t Phím 1 : Hãy cho chúng tối các số liệu về kho .\n\t\t Từ nhà kho : 0,1,2... \n\t\t Đến nhà kho : 0,1,2... \n\t\t Chi phí : 0,1,2... \n\t Phím 2 : Cho chúng tôi kho bạn bắt đầu vận chuyển và điểm đến của bạn .\n\t Phím 3 : Hiển thị thông tin của kho .");
            
            Graph thegraph = new Graph();
        batdau:
            Console.WriteLine();
            Console.Write("> Vui lòng chọn yêu cầu của bạn:  ");
            int key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 1: // nhập dữ liệu kho mới
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        thegraph = new Graph();
                        Console.Write(">> Nhập số lượng kho : ");
                        int n = int.Parse(Console.ReadLine());
                        
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write("Mời bạn nhập tên nhà kho: ");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Mời bạn nhập năm thuê: ");
                            int namthue = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            int id = i + 1;
                            mylist.Add(new WareHouse(id, name, namthue));
                        }
                        n1 = n;
                        WareHouse[] b = new WareHouse[n];
                        string ten = "nhà kho";
                        Random random = new Random();
                        for (int i = 0; i < b.Length; i++)
                        {
                            b[i] = new WareHouse(i, ten + " " + (i + 1), random.Next(2015, 2025));
                        }
                        for (int i = 0; i < n; i++)
                        {
                            thegraph.AddVertex(b[i].GetName());
                        }
                        Input(n, thegraph, a);
                        Console.WriteLine();
                    }
                    goto batdau;
                case 2:
                    {
                        Console.WriteLine("*************");
                        Console.WriteLine(" >>> Với:");
                        foreach (string val in a)
                        {
                            Console.WriteLine(val);
                        }
                        Console.WriteLine(" >>> Ta có:");
                        Console.Write("Vận chuyển từ nhà kho: ");
                        int khodi = int.Parse(Console.ReadLine());
                        while (khodi > n1)
                        {
                            Console.WriteLine("Vui lòng nhập lại!");
                            khodi = int.Parse(Console.ReadLine());
                        }
                        Console.Write("Đến nhà kho: ");
                        int khoden = int.Parse(Console.ReadLine());
                        while (khoden > n1)
                        {
                            Console.WriteLine("Vui lòng nhập lại!");
                            khodi = int.Parse(Console.ReadLine());
                        }
                        thegraph.Path(khodi, khoden);
                    }
                    goto batdau;
                case 3:
                    {
                        Console.WriteLine("Nhập kho bạn muốn hiển thị thông tin");
                        int hienthi = int.Parse(Console.ReadLine());
                        Console.WriteLine(mylist[hienthi-1]);
                    }
                    goto batdau;
                default:
                    Console.WriteLine("Nhập sai !");
                    Console.Write("Nhấn 1 để quay lại menu lựa chọn \nnhấn số bất kỳ để thoát chương trình \n >> ");
                    int error = int.Parse(Console.ReadLine());
                    if (error == 1) goto batdau;
                    else break;
            }
            Console.ReadKey();
        }
    }
}