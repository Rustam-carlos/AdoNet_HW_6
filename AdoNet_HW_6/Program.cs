using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductContext DB = new ProductContext())
            {
                // создаем объект 
                Product product1 = new Product { Name = "Milk", Firm_name = "Родина", Price = 150 };
                Product product2 = new Product { Name = "Water", Firm_name = "Tassay", Price = 100 };

                //Init_product(prod);

                // добавляем их в бд                
                DB.products.Add(product1);
                DB.products.Add(product2);
                DB.products.Add(product2);
                DB.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var Products = DB.products;
                Console.WriteLine("Список объектов:");
                foreach (Product i in Products)
                {
                    Console.WriteLine("{0}.{1}.{2}.{3}", i.ID, i.Name, i.Firm_name, i.Price);
                }



                Console.WriteLine("Выберите действие: 1 - для добавления продукта, 2 - для изменения продукта, 3 - для удаления  и 4 - для вывода списка товаров");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введите название продукта");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите название фирмы производителя");
                        string firm = Console.ReadLine();
                        Console.WriteLine("Введите цену продукта");
                        int price = int.Parse(Console.ReadLine());
                        Product prod = new Product { Name = name, Firm_name = firm, Price = price };
                        DB.products.Add(prod);
                        DB.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Выберите параметр для изменения");
                        Console.WriteLine("1-Name");
                        Console.WriteLine("2-Firm_name");
                        Console.WriteLine("3-Price");
                        int Param = int.Parse(Console.ReadLine());
                        switch (Param)
                        {
                            case 1:
                                Console.WriteLine("Введите название товара, которого хотите изменить");
                                string _name = Console.ReadLine();
                                var getID = (from Product in DB.products
                                             where Product.Name.Contains(_name)
                                             select Product).FirstOrDefault();
                                Console.WriteLine("Введите новое название товара");
                                string New_name = Console.ReadLine();
                                getID.Name = New_name;
                                DB.SaveChanges();
                                break;
                            case 2:
                                Console.WriteLine("Введите название фирмы товара, которого хотите изменить");
                                string _Firm_name = Console.ReadLine();
                                var ID = (from Product in DB.products
                                          where Product.Firm_name.Contains(_Firm_name)
                                          select Product).FirstOrDefault();
                                Console.WriteLine("Введите новое название фирмы");
                                string New_Firm_name = Console.ReadLine();
                                ID.Firm_name = New_Firm_name;
                                DB.SaveChanges();
                                break;
                            case 3:
                                Console.WriteLine("Введите название товара, цену которого хотите изменить");
                                _name = Console.ReadLine();
                                getID = (from Product in DB.products
                                         where Product.Name.Contains(_name)
                                         select Product).FirstOrDefault();
                                Console.WriteLine("Введите новую цену");
                                int New_price = int.Parse(Console.ReadLine());
                                getID.Price = New_price;
                                DB.SaveChanges();
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите название товара, которого хотите удалить");
                        string name_ = Console.ReadLine();
                        var _getID = (from Product in DB.products
                                      where Product.Name.Contains(name_)
                                      select Product).FirstOrDefault();
                        if (_getID != null)
                        {
                            DB.products.Remove(_getID);
                            DB.SaveChanges();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Список объектов:");
                        foreach (Product i in Products)
                        {
                            Console.WriteLine("{0}.{1}.{2}.{3}", i.ID, i.Name, i.Firm_name, i.Price);
                        }
                        break;
                }



                Console.Read();
            }
        }

    }
}
