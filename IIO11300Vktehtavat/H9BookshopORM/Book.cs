using System.Collections.Generic;
using System.Data;

namespace H9BookshopORM
{
    public class Book
    {
        #region PROPERTIES
        private int id;
        public int ID
        {
            get { return id; }
        }



        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }



        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }




        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        #endregion



        #region CONSTRUCTORS
        public Book(int id)
        {
            this.id = id;
        }
    


        public Book(int id, string name, string author, string country, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.country = country;
            this.year = year;
        }
        #endregion



        #region METHODS
        public override string ToString()
        {
            return name + " written by " + author;
        }
        #endregion
    }



    public class BookShop
    {
        #region METHODS
        public static List<Book> GetTestBooks()
        {
            List<Book> temp = new List<Book>();
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            temp.Add(new Book(2, "Anna Karenina", "Leo Tolstoi", "Venäjä", 1877));
            return temp;
        }



        public static DataTable GetTestData()
        {
            // testaukseen oikeanlainen taulu
            DataTable td = new DataTable();

            // sarakkeiden määrittely
            td.Columns.Add("id", typeof(int));
            td.Columns.Add("name", typeof(string));
            td.Columns.Add("author", typeof(string));
            td.Columns.Add("country", typeof(string));
            td.Columns.Add("year", typeof(int));

            // rivit
            td.Rows.Add(11, "Pekka Lipposen seikkailut", "Outsider", "Suomi", 1950);
            td.Rows.Add(12, "Lucky Luke", "Renè Coscinny", "Belgia", 1946);
            
            return td;
        }
        #endregion
    }
}
