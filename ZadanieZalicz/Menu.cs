using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace ZadanieZalicz
{
    public struct Student
    {
        public string Name;
        public string Surname;
        public int Index;
        public int Semestr;
        public Dictionary<string, double> Note;
        public Student(string name, string surname, int index, int semestr, Dictionary<string, double> note)
        {
            Name = name;
            Surname = surname;
            Index = index;
            Semestr = semestr;
            Note = note;
        }
    }
    class Menu
    {
        public List<Student> list = new List<Student>();



        //    public string Text()
        //    {
        //        return $"{Name} {Surname}\n{Index}\n{Semestr}\n{Note}";
        //    }

        //    public static Student Konwersja(string csvLine)
        //    {
        //        string[] values = csvLine.Split(';');
        //        Student students = new Student
        //        {
        //            Name = (values[0]),
        //            Surname = (values[1]),
        //            Index = Convert.ToInt32(values[2]),
        //            Semestr = Convert.ToInt32(values[3]),
        //            Note = { }
        //        };
        //        return students;

        //    }
        //}

        int index;

        public void Add(List<Student> list)
        {


            Student student = new Student();

            Console.Write("Podaj imię: ");
            student.Name = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            student.Surname = Console.ReadLine();

            index = list.Capacity + 1;
            Console.Write("Indeks: " + index);

            Console.Write("\nPodaj semestr: ");
            student.Semestr = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj przedmiot: ");
            string subject = Console.ReadLine();

            Console.Write("Podaj ocenę:");
            double grade = double.Parse(Console.ReadLine());

            Dictionary<string, double> note = new Dictionary<string, double>();
            note.Add(subject, grade);
            student.Note = note;
            list.Add(student);
            Console.WriteLine("Możesz zakończyć lub wybrać inną opcję");

        }

        public void View(List<Student> list)
        {
            foreach (Student item in list)
            {
                Console.WriteLine(
                    $"Imię i nazwisko: {item.Name} {item.Surname}\n" +
                    $"Numer Indeksu: {item.Index}\n" +
                    $"Aktualny Semestr: {item.Semestr}\n" +
                    $"Oceny: {item.Note}\n");
                Console.WriteLine("Możesz wyjść lub wybrać inną opcję");
            }

        }

        public void Del(List<Student> list)
        {
            Console.WriteLine("Podaj imię studenta którego chcesz usunąć");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko studenta którego chcesz usunąć");
            string surrname = Console.ReadLine();

            foreach (Student item in list)
            {
                list.RemoveAll(r => r.Name.Contains(name) & r.Surname.Contains(surrname));
                break;
            }


        }

        public void Save(List<Student> list)
        {
            if (!File.Exists("Lista_Studentów.xml"))
            {
                //XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.Load(File.WriteAllLines());

                XmlTextWriter xmlTextWriter = new XmlTextWriter("Lista_Studentów", null);
                //xmlTextWriter.Formatting = Formatting.Indented;
                //xmlDocument.Save(xmlTextWriter);
            }

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute();
            xmlRootAttribute.ElementName = "lista_Studentów";
            xmlRootAttribute.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>), xmlRootAttribute);

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("Lista_Studentów.xml");
                xmlSerializer.Serialize(sw, list);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Wystąpił następujący wyjątek: " + exception.Message);
            }
            finally
            {
                if (null != sw)
                {
                    sw.Dispose();
                }
            }
        }

        public void Research(List<Student> list)
        {
            Console.WriteLine("Wybierz według czego mam szukać\n" +
                "1 - Imię\n" +
                "2 - Nazwisko\n" +
                "3 - Indeks\n" +
                "4 - Semestr\n" +
                "5 - Ocena\n");
            Console.WriteLine();
            ConsoleKeyInfo klw = Console.ReadKey();

            if (klw.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Podaj imię:");
                string imie = Console.ReadLine();

                foreach (Student item in list)
                {
                    if (item.Name.Contains(imie))
                    {
                        Console.WriteLine(
                            $"Imię i nazwisko: {item.Name} {item.Surname}\n" +
                            $"Numer Indeksu: {item.Index}\n" +
                            $"Aktualny Semestr: {item.Semestr}\n" +
                            $"Oceny: {item.Note}\n");
                        break;
                    }
                }
            }
            else if (klw.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Podaj nazwisko");
                string nazwisko = Console.ReadLine();

                foreach (Student item in list)
                {
                    if (item.Surname.Contains(nazwisko))
                    {
                        Console.WriteLine(
                            $"Imię i nazwisko: {item.Name} {item.Surname}\n" +
                            $"Numer Indeksu: {item.Index}\n" +
                            $"Aktualny Semestr: {item.Semestr}\n" +
                            $"Oceny: {item.Note}\n");
                        break;
                    }

                }
            }
            else if (klw.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Podaj indeks");
                int ind = int.Parse(Console.ReadLine());

                foreach (Student item in list)
                {
                    if (item.Index.Equals(ind))
                    {
                        Console.WriteLine($"Imię i nazwisko: {item.Name} {item.Surname}\n " +
                            $"Numer Indeksu: {item.Index}\n" +
                            $"Aktualny Semestr: {item.Semestr}\n" +
                            $"Oceny: {item.Note}\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie ma studenta o podanym indeksie");
                        break;
                    }
                }
            }
            else if (klw.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Podaj semestr studenta");
                int sem = int.Parse(Console.ReadLine());

                foreach (Student item in list)
                {
                    if (item.Semestr.Equals(sem))
                    {
                        Console.WriteLine($"Imię i nazwisko: {item.Name} {item.Surname}\n " +
                            $"Numer Indeksu: {item.Index}\n" +
                            $"Aktualny Semestr: {item.Semestr}\n" +
                            $"Oceny: {item.Note}\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie ma studentów w danym semestrze");
                        break;
                    }
                }

            }
            else if (klw.Key == ConsoleKey.D5)
            {
                Console.WriteLine("Wybierz według czego chcesz szukać:");
                Console.WriteLine("(O)cena");
                Console.WriteLine("(P)rzedmiot");
                ConsoleKeyInfo keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.O)
                {
                    Console.WriteLine("Podaj ocenę:");
                    double ocena = double.Parse(Console.ReadLine());
                    foreach (Student item in list)
                    {
                        if (item.Note.Values.Equals(ocena))
                        {
                            Console.WriteLine($"Imię i nazwisko: {item.Name} {item.Surname}\n " +
                                $"Numer Indeksu: {item.Index}\n" +
                                $"Aktualny Semestr: {item.Semestr}\n" +
                                $"Oceny: {item.Note}\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Żaden student nie ma takiej oceny");
                            break;
                        }
                    }
                }
                else if (keyinfo.Key == ConsoleKey.P)
                {
                    Console.WriteLine("Podaj przedmiot:");
                    string przed = Console.ReadLine();

                    foreach (Student item in list)
                    {
                        if (item.Note.Keys.Contains(przed))
                        {
                            Console.WriteLine($"Imię i nazwisko: {item.Name} {item.Surname}\n " +
                                $"Numer Indeksu: {item.Index}\n" +
                                $"Aktualny Semestr: {item.Semestr}\n" +
                                $"Oceny: {item.Note}\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nie ma przedmiotu o danej nazwie");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nie podałeś żadnej z wymienionej opcji");
                }

            }
        }

        public void Load(List<Student> list)
        {
            list.Clear();

            Student student = new Student();

            XPathDocument pathDocument = new XPathDocument("Lista_Studentów.xml");
            XPathNavigator pathNavigator = pathDocument.CreateNavigator();
            XPathNodeIterator pathNodeIterator = pathNavigator.Select("/Lista_Studentów/Student");

            foreach (XPathNavigator item in pathNodeIterator)
            {
                student.Name = item.SelectSingleNode("name").Value;
                student.Surname = item.SelectSingleNode("surname").Value;
                student.Index = item.SelectSingleNode("index").ValueAsInt;
                student.Semestr = item.SelectSingleNode("semestr").ValueAsInt;
                //student.Note = item.SelectSingleNode().Value;

            }

        }

        //public void Modification()
        //{
        //    Student
        //}

        public Menu()
        {
            Console.WriteLine("1.Pokaż listę studentów\n" +
                "2.Dodaj studenta\n" +
                "3.usuń studenta\n" +
                "4.Wyszukiwanie studenta\n" +
                "5.Wyświetl średnią medianę i odchylenia standardowe ocen wszystkich uczniów\n" +
                "");
            ConsoleKeyInfo ckl = Console.ReadKey();

            List<Student> list = new List<Student>();

            do
            {
                switch (ckl.Key)
                {
                    case ConsoleKey.D1:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Nie ma studentów");
                            Console.WriteLine("Wybierz inna opcje");
                            ckl = Console.ReadKey();
                            Console.WriteLine();
                        }
                        else
                        {
                            Load(list);
                            View(list);
                            ckl = Console.ReadKey();
                            Console.WriteLine();
                        }
                        continue;

                    case ConsoleKey.D2:
                        Add(list);
                        Save(list);
                        Console.WriteLine();
                        ckl = Console.ReadKey();
                        continue;
                    case ConsoleKey.D3:
                        Del(list);
                        Console.WriteLine();
                        ckl = Console.ReadKey();
                        continue;
                    case ConsoleKey.D4:
                        Research(list);
                        Console.WriteLine();
                        ckl = Console.ReadKey();
                        continue;
                    default:
                        break;
                }
            } while (ckl.Key != ConsoleKey.Escape);


        }
    }
}
