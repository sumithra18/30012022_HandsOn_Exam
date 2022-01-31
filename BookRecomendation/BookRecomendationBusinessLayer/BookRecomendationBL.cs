using BookRecomendationDataAccessLayer;
using BookRecomendationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookRecomendationBusinessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required. 
    public class BookRecomendationBL
    {
        BookRecomendationDAL dalObj;

        public BookRecomendationBL()
        {
            dalObj = new BookRecomendationDAL();
        }
        public int ConnectToDB()
        {
            try
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public List<BookDTO> ShowReviewsForBook()
        {
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                List<BookDTO> showReviewBook = dalObj.FetchReviewsForBook();
                dalObj.FetchReviewsForBook();
                return showReviewBook;
            }

        }

       
            public int AddReviewForBook(BookDTO newreviewobj, out int newreviewid)
        {
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.AddReview(newreviewobj, out newreviewid);
            }
        }
      
    }
}



