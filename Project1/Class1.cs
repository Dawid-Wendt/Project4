using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Class1
    {
        // data classes
        public class Data
        {
            public List<User> Users;
            public List<Order> Orders;

        }
        public class User
        {
            public string Email;
            public string FullName;
            public int Age;
        }
        public class Order
        {
            public string Name;
        }
        // other stuff
        public static bool Compare_Strings(string x, string y, bool Equal)
        {
            if (Equal)
            {
                if (x.Equals(y))
                {
                    return true;
                }
            }
            else
            {
                if (!x.Equals(y))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Compare_Int(int x, int y, int Equal)
        {
            switch(Equal)
            {
                case 0:       // =
                    if(x==y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 1:       // !=
                    if (x != y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:       // >
                    if (x > y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:       // >=
                    if (x >= y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4:       // <
                    if (x < y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 5:       // <=
                    if (x <= y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }
        public static string Full_String(int i,string[] splited)
        {
            string output = "";
            for(int x=i;x<splited.Length;x++)
            {
                if (splited[x].StartsWith("'") && splited[x].EndsWith("'"))
                {
                    string outc = splited[x].Remove(0, 1);
                    output += outc.Remove(outc.Length - 1);
                    break;
                }
                else if (splited[x].StartsWith("'"))
                {
                    output += splited[x].Remove(0, 1);
                }
                else if (splited[x].EndsWith("'"))
                {
                    output += " ";
                    output += splited[x].Remove(splited[x].Length - 1);
                    break;
                }
                else
                {
                    output += " ";
                    output += splited[x];
                }
            }
            return output;
        }

        // check expressions
        public static bool Check_Expression_Orders(string[] splited, Order ord)
        {
            int i = 2;
            bool status = true;
            bool was_or = false;
            int was_true = 0;
            int was = 0;
            if (splited[i] != "where")
            {
                return true;
            }
            i++;
            while (true)
            {
                status = true;
                if (splited[i] == "select")
                {
                    break;
                }
                switch (splited[i])
                {
                    case "Name":
                        i++;
                        switch (splited[i])
                        {
                            case "=":
                                i++;
                                if (!Compare_Strings(ord.Name, Full_String(i, splited), true))
                                {
                                    status = false;
                                }
                                break;
                            case "!=":
                                i++;
                                if (!Compare_Strings(ord.Name, Full_String(i, splited), false))
                                {
                                    status = false;
                                }
                                break;
                        }
                        break;
                }
                for (int x = i; x > 0; x++)
                {
                    if (splited[x].ToUpper().Equals("AND") || splited[x].ToUpper().Equals("OR"))
                    {
                        i = x + 1;
                        break;
                    }
                    else if (splited[x].Equals("select"))
                    {
                        i = x;
                        break;
                    }
                }
                if (splited[i - 1].ToUpper().Equals("OR"))
                {
                    was_or = true;
                }
                if (was_or && status)
                {
                    return true;
                }
                was++;
                if (status)
                {
                    was_true++;
                }
            }
            if (was_true.Equals(was))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool Check_Expression_Users(string[] splited, User usr)
        {
            int i = 2;
            bool status = true;
            bool was_or = false;
            int was_true = 0;
            int was = 0;
            if (splited[i]!="where")
            {
                return true;
            }
            i++;
            while(true)
            {
                status = true;
                if(splited[i]=="select")
                {
                    break;
                }
                switch (splited[i])
                {
                    case "Email":
                        i++;
                        switch(splited[i])
                        {
                            case "=":
                                i++;
                                if(!Compare_Strings(usr.Email, Full_String(i, splited),true))
                                {
                                    status = false;
                                }
                                break;
                            case "!=":
                                i++;
                                
                                if (!Compare_Strings(usr.Email, Full_String(i, splited), false))
                                {
                                    status = false;
                                }
                                
                                break;
                        }
                        break;
                    case "FullName":
                        i++;
                        switch (splited[i])
                        {
                            case "=":
                                i++;
                                if (!Compare_Strings(usr.FullName, Full_String(i, splited), true))
                                {
                                    status = false;
                                }
                                break;
                            case "!=":
                                i++;
                                if (!Compare_Strings(usr.FullName, Full_String(i, splited), false))
                                {
                                    status = false;
                                }
                                
                                break;
                        }
                        break;
                    case "Age":
                        i++;
                        switch (splited[i])
                        {
                            case "=":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 0))
                                {
                                    status = false;
                                }
                                break;
                            case "!=":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 1))
                                {
                                    status = false;
                                }
                                break;
                            case ">":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 2))
                                {
                                    status = false;
                                }
                                break;
                            case ">=":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 3))
                                {
                                    status = false;
                                }
                                break;
                            case "<":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 4))
                                {
                                    status = false;
                                }
                                break;
                            case "<=":
                                i++;
                                if (!Compare_Int(usr.Age, int.Parse(splited[i]), 5))
                                {
                                    status = false;
                                }
                                break;
                        }
                        break;
                }
                for (int x = i; x < splited.Length; x++)
                {
                    if (splited[x].ToUpper().Equals("AND") || splited[x].ToUpper().Equals("OR"))
                    {
                        i = x + 1;
                        break;
                    }
                    else if(splited[x].Equals("select"))
                    {
                        i = x;
                        break;
                    }
                }
                if (splited[i - 1].ToUpper().Equals("OR"))
                {
                    was_or = true;
                }
                if (was_or && status)
                {
                    return true;
                }
                was++;
                if (status)
                {
                    was_true++;
                }

            }
            if (was_true.Equals(was))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // select fields
        public static string Select_User(string[] splited, User usr)
        {
            string output = "";
            int x = 0;
            for(int i = 0;i<splited.Length;i++)
            {
                if(splited[i].Equals("select"))
                {
                    x = i + 1;
                    break;
                }
            }
            for(int i=x;i<splited.Length;i++)
            {
                string virable = splited[i];
                if(i!=splited.Length-1)
                {
                    virable = virable.Remove(virable.Length - 1);
                }
                output += " ";
                switch(virable)
                {
                    case "Email":
                        output += usr.Email;
                        break;
                    case "FullName":
                        output += usr.FullName;
                        break;
                    case "Age":
                        output += usr.Age.ToString();
                        break;
                }   
            }
            output += "\n";
            return output;
        }
        public static string Select_Order(string[] splited, Order ord)
        {
            string output = "";
            int x = 0;
            for (int i = 0; i < splited.Length; i++)
            {
                if (splited[i].Equals("select"))
                {
                    x = i + 1;
                    break;
                }
            }
            for (int i = x; i < splited.Length; i++)
            {
                string virable = splited[i];
                if (i != splited.Length - 1)
                {
                    virable = virable.Remove(virable.Length - 1);
                }
                output += " ";
                switch (virable)
                {
                    case "Email":
                        output += ord.Name;
                        break;
                }
            }
            output += "\n";
            return output;
        }
        // check global
        public static string Check(string input, Data data)
        {
            string output="";
            string[] splited = input.Split(' ');
            string Source = splited[1];
            if (Source != "Users" && Source != "Orders")
            {
                return "Source does not exist";
            }
            else if (Source=="Users")
            {
                foreach (User usr in data.Users)
                {
                    //Console.WriteLine(" usr: Email:" + usr.Email + " FullName:" + usr.FullName + " Age:" + usr.Age+"\n");
                    if (Check_Expression_Users(splited, usr))
                    {
                        output += Select_User(splited, usr);
                    }
                }
            }
            else if (Source == "Orders")
            {
                foreach (Order ord in data.Orders)
                {
                    if (Check_Expression_Orders(splited, ord))
                    {
                        output += Select_Order(splited, ord);
                    }
                }
            }
            return output;

        }
        static void Main()
        {

            // exmaple data
            var User1 = new User
            {
                Email = "xyz@gmail.com",
                FullName = "John Doe",
                Age = 30                                                            
            };
            var User2 = new User
            {
                Email = "xyz2@gmail.com",
                FullName = "John Deo",
                Age = 36
            };
            Data data = new Data()
            {
                Users = new List<User>()
                {
                    User1,
                    User2
                }
            };
            // end of example data


            string input = "from Users where FullName != 'John Doe' or Age >= 36 or Email = 'example@gmail.com' select FullName, Email"; //example query
            Console.WriteLine(Check(input, data));
        }

    }
}
