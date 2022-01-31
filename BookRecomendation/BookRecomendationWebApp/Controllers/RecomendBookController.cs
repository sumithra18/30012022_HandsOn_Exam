using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;


namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        BookRecomendationBL blObj;
        private object apiResponse;
        public RecomendBookController()
        {
            blObj = new BookRecomendationBL();
        }
        // GET: RecomendBook

        public HttpResponseMessage Index()
        {
            try
            {
                BookRecomendationBL blObj = new BookRecomendationBL();
                List<BookDTO> diplayIndex = blObj.ShowReviewsForBook();
                if (diplayIndex.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, diplayIndex);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Book Recommended for you");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]

        public ActionResult AddReviews(BookViewModel fromUIObj)
        {
          
            {
                try
                {
                    if (fromUIObj != null)
                    {
                        BookDTO newDept = new BookDTO();
                        newDept.bookReviews = fromUIObj.bookReviews;
                        newDept.bookName = fromUIObj.bookName;
                        
                        int returnVal = blObj.AddReviews(newReview, out newReviewID);
                        if (returnVal == 1)
                        {
                            return RedirectToAction("DisplayAllDepartment");
                        }
                        else
                        {
                            return View("Error");
                        }
                        return View("Success");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

            }

        }
        [HttpGet]
        public HttpResponseMessage DisplayResultsUsingWebAPI()
        {
            try
            {
                List<BookDTO> displayReviews = blObj.ShowReviewsForBook();
                List<BookViewModel> lstReviewsModel = new List<BookViewModel>();
                foreach (var RecomendBook in displayReviews)
                {
                    BookViewModel newObj = new BookViewModel();
                    newObj.bookName = RecomendBook.bookName;
                    newObj.bookReviews = RecomendBook.bookReviews; 
                    newObj.bookRating = RecomendBook.bookRating;
                    lstReviewsModel.Add(newObj);
                }
                return View(lstReviewsModel);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }
    }
}



      