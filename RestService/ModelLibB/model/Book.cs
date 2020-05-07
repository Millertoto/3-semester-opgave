using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibB.model
{
    public class Book
    {
        private string _title;
        private string _author;
        private int _pageNr;
        private string _iSBN;


        public Book()
        {

        }
        public Book(string title, string author, int pageNR, string iSBN)
        {
            _title = title;
            _author = author;
            _pageNr = pageNR;
            _iSBN = iSBN;

        }
        public string Title
        {
            get => _title;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _title = value;
            }
        }

        public string Author
        {
            get => _author;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _author = value;
                }
            }


        }

        public int PageNR
        {
            get => _pageNr;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                else if (value < 4 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _pageNr = value;
                }
            }
        }

        public string ISBN
        {
            get => _iSBN;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length != 13)
                {
                    throw new ArgumentOutOfRangeException();

                }
                else
                {
                    _iSBN = value;
                }
            }
        }

        public string ToString()
        {
            return Title + " " + Author + " " + PageNR + " " + ISBN;
        }
    }
}
