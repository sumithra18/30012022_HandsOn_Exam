﻿using System;
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



        public void AddReviews()
        {

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




