using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementaion of product review management");


            ReviewManager review = new ReviewManager();
            List<ProductReview> list = review.AddReviews();
            //review.CreateDataTable(list);
            review.IterateMethod(review.RetriveTheRecordOfUserId(10));


            Console.Read();
        }

       

    }
}
