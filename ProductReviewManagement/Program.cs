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
            review.AddReviews();

            Console.Read();
        }
        
    }
}
