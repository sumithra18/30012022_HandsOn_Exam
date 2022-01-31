using BookRecomendationDTO;
using BookRecomendationBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookReviewsAPI.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookReviewsController : ApiController
    {


        [HttpGet]
        public HttpResponseMessage GetRatingsForBook()
        {
            try
            {
                BookRecomendationBL blObj = new BookRecomendationBL();
                List<BookDTO> diplayIndex = blObj.GetAllReviews();
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


    }

}
}
