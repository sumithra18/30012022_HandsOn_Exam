using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {
        SqlConnection conObj;
        SqlCommand cmdObj;

        public BookRecomendationDAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["BookRecomendationConnectStr"].ConnectionString);
            //cmdObj = new BookRecomendationContext();
        }
        public int ConnectionToDB()
        {
            try
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -22;
            }
        }
        public List<BookDTO> FetchReviewsForBook()
        {
            try
            {
                cmdObj = new SqlCommand(@"SELECT title,review,rating FROM BookRecomendation", conObj);
                conObj.Open();
                SqlDataReader drDept = cmdObj.ExecuteReader();
               
                List<BookDTO> lstReviews = new List<BookDTO>();
                while (drDept.Read())
                {
                    BookDTO bookRecommendFromReader = new BookDTO();
                    bookRecommendFromReader.bookName = drDept["Name"].ToString();
                    bookRecommendFromReader.bookReviews = drDept["Reviews"].ToString();
                    //reviewFromReader.bookRating = drreview["Rating"].ToString();
                    lstReviews.Add(bookRecommendFromReader);
                    
                }
                return lstReviews;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conObj.Close();
            }
        }

    }

    public void SaveReviewForBookToDB(BookDTO newreviewobj, out int newreviewid)
        {
        throw new NotImplementedException();
    }


}


